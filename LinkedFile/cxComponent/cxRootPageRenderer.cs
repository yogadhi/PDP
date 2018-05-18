using System;
using Xamarin.Forms;
using Shared.Services.Logs;
using Shared.Classes.Components;
#if __ANDROID__
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Xamarin.Forms.Platform.Android;
#endif
#if __IOS__
using System.IO;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
#endif

[assembly: Xamarin.Forms.ExportRenderer(typeof(cxRootPage), typeof(cxRootPageRenderer))]
#if __ANDROID__
public class cxRootPageRenderer : MasterDetailRenderer
{

}
#endif

#if __IOS__
public class cxRootPageRenderer : PhoneMasterDetailRenderer
{

}
#endif