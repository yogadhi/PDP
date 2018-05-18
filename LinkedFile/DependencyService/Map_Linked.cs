using System;
using Xamarin.Forms;
using ExternalMaps.Plugin;
using MyCloudTable;
#if __ANDROID__
using Android.Content;
using Android.Support.V4.App;
using MyCloudTable.Droid;
#endif
#if __IOS__
using Foundation;
using UIKit;
using MyCloudTable.iOS;
//using Google.Maps;
#endif

[assembly:   Dependency(typeof (Map_Linked))]
namespace MyCloudTable
{
	public class Map_Linked : 
	#if __ANDROID__
	Fragment, IMap
	#endif
	#if __IOS__
	UINavigationController, IMap
	#endif
	{
		#if __IOS__
		public static string _placename {get; set;}
		public static double _lat { get; set; }
		public static double _lng { get; set; }
		#endif

		public Map_Linked()
		{
		}

		public void LaunchExternalMap (string placename, double lat, double lng){
			try{
				CrossExternalMaps.Current.NavigateTo (placename, lat, lng);
			}
			catch (Exception ex)
			{
				AppStyle.Log.sendException("LauncExternalMap", ex);
			}
		}

		public void LaunchStreetView(string placename, double lat, double lng)
		{
			try
			{
				#if __ANDROID__
				var intent = new Intent (Forms.Context, typeof(PanoramaActivity));
				intent.PutExtra ("lat", lat);
				intent.PutExtra ("lng", lng);
				Forms.Context.StartActivity(intent);
				#endif
				#if __IOS__
				_placename = placename;
				_lat = lat;
				_lng = lng;

                //var panoramaService = new PanoramaService();
                //var location = new CoreLocation.CLLocationCoordinate2D(_lat, _lng);
                //panoramaService.RequestPanorama(location, PanoramaRequestCallback);
				#endif
			}
			catch (Exception ex)
			{
				string msg = ex.ToString();
			}

		}

		#if __IOS__
        //void PanoramaRequestCallback(Panorama panorama, NSError error)
        //{
        //    try 
        //    {
        //        if (error != null)
        //        {
        //            var alertController = UIAlertController.Create("Warning",
        //                "Street view for this location is not available", UIAlertControllerStyle.Alert);
        //            alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Destructive, null));
        //            PresentViewController(alertController, false, null);
        //            return;
        //        }

        //        var streetViewController = new StreetViewController(_placename, _lat, _lng);
        //        this.PresentViewController(streetViewController, true, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.ToString();
        //    }
        //}
		#endif
	}
}

