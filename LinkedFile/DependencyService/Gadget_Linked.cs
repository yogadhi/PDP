using System;
using Xamarin.Forms;
using Shared;

#if __ANDROID__
using Android.OS;
using Android.Locations;
using Android.Content;
using Android.Support.V4.App;
#endif
#if __IOS__
using EventKit;
using UIKit;
using System.Linq;
using System.Collections.Generic;
//using MonoTouch.Dialog;
using Foundation;
#endif

[assembly: Dependency(typeof(Gadget_Linked))]
namespace Shared
{
    public class Gadget_Linked : 
#if __ANDROID__
        FragmentActivity, 
#endif        
        Classes.Dependencies.Interfaces.IGadget
    {
#if __IOS__
        // event controller delegate
        //protected CreateEventEditViewDelegate eventControllerDelegate;

		string[] splitdate = new string[3];
		string[] splittime = new string[3];
		public static DateTime reference;
#endif
        public Gadget_Linked()
        {
        }

#if __ANDROID__
        protected override void OnCreate(Bundle bundle)
        {
            GpsDetected();
        }
#endif

        public void Close_App()
        {
#if __ANDROID__
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#endif
        }

        public void PhoneDial(string phone)
        {
            try
            {
#if __ANDROID__
                var intent = new Intent(Forms.Context, typeof(PhoneActivity));
                intent.PutExtra("phone", phone);
                Forms.Context.StartActivity(intent);
#endif
#if __IOS__
				string phoneuri =  phone.Replace("-","").Replace(" ","");
				var url = new NSUrl ("tel:" + phoneuri);

				// Use URL handler with tel: prefix to invoke Apple's Phone app, 
				// otherwise show an alert dialog                


				if (!UIApplication.SharedApplication.OpenUrl (url)) {
					var av = new UIAlertView ("Not supported",
						"Scheme 'tel:' is not supported on this device",
						null,
						"OK",
						null);
					av.Show ();


				};
#endif
            }
            catch (Exception ex)
            {
                Services.Logs.Insights.Send("PhoneDial", ex);
            }
        }

        public bool GPSstatus()
        {
			bool loc = false;
#if __ANDROID__
            LocationManager lm = (LocationManager)GetSystemService(Context.LocationService);
            loc = lm.IsProviderEnabled(LocationManager.GpsProvider);
#endif

            return loc;
        }

        public void GpsDetected()
        {
            try
            {
#if __ANDROID__
                var intent = new Intent(Forms.Context, typeof(GPSActivity));
                Forms.Context.StartActivity(intent);
#endif
            }
            catch (Exception ex)
            {
                Services.Logs.Insights.Send("GPSDetected", ex);
            }
        }

        public void settingLocationService()
        {
            try
            {
#if __ANDROID__
                var intent = new Intent(Forms.Context, typeof(SettingDisplayActivity));
                Forms.Context.StartActivity(intent);
#endif
            }
            catch (Exception ex)
            {
                Services.Logs.Insights.Send("settingLocationService", ex);
            }
        }

		public void SaveEventToCalendar(string Title, string Desc, string Date, string Time, string location, int reservation_id)
        {
            try
            {
#if __ANDROID__

                var intent = new Intent(Forms.Context, typeof(CalendarActivity));
                intent.PutExtra("title", Title);
                intent.PutExtra("desc", Desc);
                intent.PutExtra("date", Date);
                intent.PutExtra("time", Time);
				intent.PutExtra("location", location);
				intent.PutExtra("reservation_id", reservation_id);
                Forms.Context.StartActivity(intent);
#endif
#if __IOS__

				RequestAccess (EKEntityType.Event, () => {
					SaveAndRetrieveEvent (Title, Desc, Date, Time, location, reservation_id);
				});
#endif

            }
            catch (Exception ex)
            {
				Services.Logs.Insights.Send("SaveEventToCalendar", ex);
            }
        }

		public  void DeleteEventCalendar(string _eventid)
		{
			try
			{
				#if __ANDROID__

				var intent = new Intent(Forms.Context, typeof(CalendarActivity));
				intent.PutExtra("event_id", _eventid);
				Forms.Context.StartActivity(intent);
				#endif
				#if __IOS__
				deleteCalendarIOS(_eventid);
				#endif

			}
			catch (Exception ex)
			{
				Services.Logs.Insights.Send("DeleteEventCalendar", ex);
			}
		}

		public void SetNotification(string Title, string Desc, string date, string time, int reservation_id)
		{
			try
			{
#if __ANDROID__

				var intent = new Intent(Forms.Context, typeof(NotificationActivity));
				intent.PutExtra("title", Title);
				intent.PutExtra("desc", Desc);
				intent.PutExtra("date", date);
				intent.PutExtra("time", time);
				intent.PutExtra("reservation_id", reservation_id);
				Forms.Context.StartActivity(intent);
#endif
#if __IOS__
				setNotif(Title, Desc, date, time, 0);
				//setNotif(Title, Desc, date, time, -60);
#endif
			}
			catch (Exception ex)
			{
				Services.Logs.Insights.Send("SetNotification", ex);
			}
		}

		public  void DeleteNotification(string id_notif, int reservation_id)
		{
			try
			{
#if __ANDROID__
				var intent = new Intent(Forms.Context, typeof(NotificationActivity));
				intent.PutExtra("id_notif", id_notif);
				intent.PutExtra("reservation_id", reservation_id);
				Forms.Context.StartActivity(intent);
#endif
#if __IOS__

#endif

			}
			catch (Exception ex)
			{
				Services.Logs.Insights.Send("DeleteEventCalendar", ex);
			}
		}

#if __IOS__
	#region calendar
        public EKEventStore EventStore
        {
			get { return new EKEventStore ( ); }
        }
		public EKEventStore eventStore;
		public void RequestAccess (EKEntityType type, Action completion)
		{
			try{
				Apps.Current.EventStore.RequestAccess (type,
					(bool granted, NSError e) => {
						//NSObject.InvokeOnMainThread (() => {
							if (granted)
								completion.Invoke ();
							else
								new UIAlertView ("Access Denied", "User Denied Access to Calendars/Reminders", null, "ok", null).Show ();
						//});
					});
			}
			catch (Exception ex)
			{
			Services.Logs.Insights.Send("GetDateTimeMS", ex);
			}
		}
		public void SaveAndRetrieveEvent (string Title, string Desc, string Date, string Time, string location, int reservation_id)
		{
			try{
				EKEvent newEvent = EKEvent.FromStore (Apps.Current.EventStore);
				// set the alarm for 5 minutes from now
				newEvent.AddAlarm (EKAlarm.FromDate (ConvertDateTimeToNSDate(Date, Time, -120)));
				// make the event start 10 minutes from now and last 30 minutes
				newEvent.StartDate = (ConvertDateTimeToNSDate(Date, Time, 0));
				newEvent.EndDate = (ConvertDateTimeToNSDate(Date, Time, 120));
				newEvent.Title = Title;
				newEvent.Notes = Desc;
				newEvent.Location = location;
				newEvent.Calendar = Apps.Current.EventStore.DefaultCalendarForNewEvents;

				// save the event
				NSError e;
				Apps.Current.EventStore.SaveEvent (newEvent, EKSpan.ThisEvent, out e);
				if (e != null) {
					//new UIAlertView ("Err Saving Event", e.ToString (), null, "ok", null).Show ();
					return;
				} else {
					//new UIAlertView ("Event Saved", "Event ID: " + newEvent.EventIdentifier, null, "ok", null).Show ();
					Console.WriteLine ("Event Saved, ID: " + newEvent.EventIdentifier);
				}

				App.Database.saveCalendar(reservation_id, newEvent.EventIdentifier.ToString(),  Date); 
				var calendar = App.Database.getCalendar("-1");
			}
			catch (Exception ex)
			{
				Services.Logs.Insights.Send("GetDateTimeMS", ex);
			}
		}

		public void deleteCalendarIOS(string event_id){
			try{
				// to retrieve the event you can call
				EKEvent mySavedEvent = Apps.Current.EventStore.EventFromIdentifier (event_id);
				Console.WriteLine ("Retrieved Saved Event: " + mySavedEvent.Title);

				// to delete, note that once you remove the event, the reference will be null, so
				// if you try to access it you'll get a null reference error.
				NSError e;
				Apps.Current.EventStore.RemoveEvent (mySavedEvent, EKSpan.ThisEvent, true, out e);
				Console.WriteLine ("Event Deleted.");
				App.Database.deleteCalendar(event_id);
			}
			catch(Exception ex){
				Services.Logs.Insights.Send("deleteCalendarIOS", ex);
			}
		}
	#endregion

		public NSDate ConvertDateTimeToNSDate(string date, string time, int addminutes)
		{
			try{
				DateTime reference = Convert.ToDateTime (date + " " + ConvertTime(time)).AddMinutes(addminutes);

				DateTime newDate = TimeZone.CurrentTimeZone.ToLocalTime(
					new DateTime(2001, 1, 1, 0, 0, 0) );
				return NSDate.FromTimeIntervalSinceReferenceDate(
					(reference - newDate).TotalSeconds);
			}
			catch (Exception ex)
			{
			Services.Logs.Insights.Send("GetDateTimeMS", ex);
				return null;
			}
		}
        
		public string ConvertTime(string time){
			try{
				string convert;
				splittime = time.Split (':');
				var timespan = Convert.ToInt32 (splittime [0].ToString ()) - 12;
				if(timespan >= 0){
					convert = timespan + ":" + splittime [1].ToString () + ":" + "00 PM";
				}else{
					convert = splittime[0].ToString() + ":" + splittime [1].ToString () + ":" + "00 AM";
				}
				return convert;
			}
			catch (Exception ex)
			{
			Services.Logs.Insights.Send("GetDateTimeMS", ex);
				return null;
			}
		}

		#region notification

		public void setNotif(string Title, string Desc, string date, string time, int interval){
			try{
				//---- create the notification
				var notification = new UILocalNotification();

				//---- set the fire date (the date time in which it will fire)
				notification.FireDate = ConvertDateTimeToNSDate(date, time, interval);

				//---- configure the alert stuff
				notification.AlertTitle = Title;
				notification.AlertBody = date + " " + time;

				//---- modify the badge
				notification.ApplicationIconBadgeNumber = 1;

				//---- set the sound to be the default sound
				notification.SoundName = UILocalNotification.DefaultSoundName;



				//---- schedule it
				UIApplication.SharedApplication.ScheduleLocalNotification(notification);
			}
			catch (Exception ex)
			{
			Services.Logs.Insights.Send("GetDateTimeMS", ex);
			}

		}
		#endregion

#endif
    }
}