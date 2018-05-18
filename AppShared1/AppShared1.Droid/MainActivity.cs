using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using XLabs.Ioc;
using XLabs.Platform.Device;
using Akavache;
using Acr.UserDialogs;
using Android.Content;

using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Shared.Classes;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace AppShared1.Droid
{
	[Activity(Label = "PasarSurya", MainLauncher = true, NoHistory = true, Theme = "@android:style/Theme.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashActivity : Activity
	{

		System.Timers.Timer timer = null;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.splashscreen);

			timer = new System.Timers.Timer();
			timer.Interval = 1000;
			timer.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
			timer.Start();
		}

		void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			timer.Stop();
			StartActivity(typeof(MainActivity));
			Finish();
		}

	}

	[Activity (Label = "PasarSurya", Icon = "@drawable/ic_logo", LaunchMode = LaunchMode.SingleTop, ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		string filename, fullPath;
		string path = Android.OS.Environment.ExternalStorageDirectory.ToString();
//		MobileBarcodeScanner scanner;

		protected override void OnCreate (Bundle bundle)
		{
			global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
			global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;

			base.OnCreate (bundle);

			BlobCache.ApplicationName = "com.collexe.app";
            global::Xamarin.Forms.Forms.SetTitleBarVisibility(Xamarin.Forms.AndroidTitleBarVisibility.Never);
			global::Xamarin.Forms.Forms.Init (this, bundle);

//			MobileBarcodeScanner.Initialize (new Android.App.Application());
//			scanner = new MobileBarcodeScanner ();

			SetIoc();
			           
			UserDialogs.Init(this);
            ImageCircleRenderer.Init();

			LoadApplication (new AppShared1.App ());
		}

		private void SetIoc()
		{
			try{
				var resolverContainer = new SimpleContainer();

				resolverContainer.Register<IDevice>(r => AndroidDevice.CurrentDevice);
			
				Resolver.SetResolver(resolverContainer.GetResolver());
			}
			catch(Exception ex){
				string message = ex.ToString ();
			}
		}

		protected override void OnStart ()
		{
			base.OnStart ();
			filename = "PDPS_TIMER_LOGOUT.txt";
			fullPath = Path.Combine(path, filename);
			if(!File.Exists(fullPath)){
				DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().SaveTextAsync(filename, "15");
			}
		}
	}
}

