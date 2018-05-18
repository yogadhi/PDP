//using System;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Android.Content.PM;
//using System.Threading;
//using Android.Support.V4;
//using ZXing;
//using ZXing.Mobile;
//using System.Security.Cryptography;
//using System.IO;
//using System.Globalization;
//using AppShared1.Droid;
//using AppShared1;
//using YAP.Core;
//
//[assembly: Xamarin.Forms.Dependency (typeof (Shared.Code.DependencyService.Barcode_Android))]
// 
//namespace Shared.Code.DependencyService
//{
//	public class Barcode_Android: Shared.Classes.Dependencies.Interfaces.IBarcode
//	{
//		View barcodelayout;
//		Button flashButton;
//
//		async public Task<string[]> Scan ()
//		{
//			try{
//				MobileBarcodeScanner.Initialize (new Android.App.Application());
//				barcodelayout = LayoutInflater.FromContext (Xamarin.Forms.Forms.Context).Inflate (AppShared1.Droid.Resource.Layout.BarcodeLayout, null);
//				//NOTE: On Android you MUST pass a Context into the Constructor!
//				var scanner = new ZXing.Mobile.MobileBarcodeScanner () {
//					UseCustomOverlay = true,
//					CustomOverlay = barcodelayout
//				};
//
//				flashButton = barcodelayout.FindViewById<Button>(AppShared1.Droid.Resource.Id.buttonZxingFlash);
//				flashButton.Click += (sender, e) => scanner.ToggleTorch();
//
//				var result = await scanner.Scan();
//				string[] scanResult = HandleScanResult (result);
//				return scanResult;	
//			}catch(Exception ex){
//				Services.Logs.Insights.Send("Scan", ex);
//				return null;
//			}
//		}
//
//		protected string[] HandleScanResult (ZXing.Result result)
//		{
//			try{
//				string strScanRes = string.Empty;
//				string[] arrScanRes = new string[3];
//
//				if (result != null && !string.IsNullOrEmpty (result.Text)) {
//					strScanRes = PrintEncryptor.Decrypt(result.Text.ToString());
//
//					if (!string.IsNullOrEmpty (strScanRes)) {
//						if (strScanRes.Contains ("|")) {
//							arrScanRes = strScanRes.Split ('|');
//						} else if ((strScanRes.Contains ("-"))) {
//							arrScanRes = strScanRes.Split ('-');
//						} else {
//							arrScanRes [0] = strScanRes;
//						}
//					} else {
//						return null;
//					}
//				} else {
//					return null;
//				}
//				return arrScanRes;
//			}catch(Exception ex){
//				Services.Logs.Insights.Send("HandleScanResult", ex);
//				return null;
//			}
//		}
//	}
//}
//
