using System;
using Xamarin.Forms;
using Shared;

#if __ANDROID__
using Android.Telephony;
using Android.OS;
using Android.Content;
using AppShared1.Droid;
using Android.Support.V4.App;
using Java.Util;
using Android.Runtime;
#endif

#if __IOS__
using AppShared1.iOS;
using UIKit;
#endif

[assembly: Dependency(typeof(Device_Linked))]

namespace Shared
{
	public class Device_Linked : Classes.Dependencies.Interfaces.IMyDevice
    {
        public Device_Linked()
        {
        }

        public string AppVersionCode()
        {
			try
			{
            	string str = string.Empty;

#if __ANDROID__
            	var context = Forms.Context.ApplicationContext;
            	str = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionCode.ToString();
#endif

#if __IOS__
				str = UIDevice.CurrentDevice.SystemVersion;
#endif

            	return str;
			}
			catch (Exception ex)
			{
				Services.Logs.Insights.Send("AppVersionCode", ex);
				return null;
			}
        }

        public string AppVersionName()
        {
			try{
            	string str = string.Empty;

#if __ANDROID__
            	var context = Forms.Context.ApplicationContext;
            	str = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName.ToString();
#endif

#if __IOS__

#endif

            	return str;
			}
			catch (Exception ex)
			{
				Services.Logs.Insights.Send("AppVersionName", ex);
				return null;
			}
        }

        public string Platform()
        {
			try{
#if __ANDROID__
            	return "ANDROID";
#endif

#if __IOS__
            	return "IOS";
#endif
			}
			catch (Exception ex)
			{
				Services.Logs.Insights.Send("Platform", ex);
				return null;
			}
        }

        public string PhoneModel()
        {
			try{
            	string manufacturer = string.Empty;
            	string model = string.Empty;

#if __ANDROID__
            	manufacturer = Build.Manufacturer;
            	model = Build.Model;
#endif
	            if (model.StartsWith(manufacturer))
	            {
	                return model.ToUpper();
	            }
	            else
	            {
	                return manufacturer.ToUpper() + " " + model;
	            }
			}
			catch (Exception ex)
			{
				Services.Logs.Insights.Send("PhoneModel", ex);
				return null;
			}
        }

        public string Codename()
        {
			try{
#if __ANDROID__
            	return Android.OS.Build.VERSION.Codename.ToString();
#endif

#if __IOS__
            	return "";
#endif
			}
			catch (Exception ex)
			{
				Services.Logs.Insights.Send("CodeName", ex);
				return null;
			}
        }

        public string APIlevel()
        {
			try{
#if __ANDROID__
            	return Android.OS.Build.VERSION.Sdk.ToString();
#endif

#if __IOS__
            	return "";
#endif
			}
			catch (Exception ex)
			{
				Services.Logs.Insights.Send("APIlevel", ex);
				return null;
			}
        }

        public string Version()
        {
			try{
#if __ANDROID__
            	return Android.OS.Build.VERSION.SdkInt.ToString();
#endif

#if __IOS__
            	return "";
#endif
			}
			catch (Exception ex)
			{
				Services.Logs.Insights.Send("Version", ex);
				return null;
			}
        }

		public string IMEI(){
			try{
				string strIMEI = "";

				var telephonyManager = (TelephonyManager)Forms.Context.GetSystemService(Android.Content.Context.TelephonyService);
				strIMEI = telephonyManager.DeviceId.ToString();

				return strIMEI; 
			}catch(Exception ex){
				Services.Logs.Insights.Send("IMEI", ex);
				return null;
			}
		}

		public string SerialNumber(){
			try{
				string strSerialNumber = "";

				strSerialNumber = Build.Serial.ToString();

				return strSerialNumber; 
			}catch(Exception ex){
				Services.Logs.Insights.Send("SerialNumber", ex);
				return null;
			}
		}

		public bool SendEmail(string receiver, string subject, string msg){
			try{
				Intent email = new Intent (Android.Content.Intent.ActionSend);
				email.SetType("message/rfc822");
				email.PutExtra(Android.Content.Intent.ExtraEmail, receiver);
				email.PutExtra(Android.Content.Intent.ExtraSubject, subject);
				email.PutExtra(Android.Content.Intent.ExtraText, msg);
				Forms.Context.StartActivity(email);
				return true;
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("SendEmail", ex);
				return false;
			}
		
		}
    }
}


