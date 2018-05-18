using System;
using Xamarin.Forms;
using Shared;
using Android.Telephony;

#if __ANDROID__
using System.IO;
using System.Threading.Tasks;
using Android.OS;
using Android.Content;
using AppShared1.Droid;
#endif

#if __IOS__
using AppShared1.iOS;
using UIKit;
#endif

[assembly: Dependency (typeof (Shared.Code.DependencyService.SaveAndLoad_Android))]

namespace Shared.Code.DependencyService
{
	public class SaveAndLoad_Android : Shared.Classes.Dependencies.Interfaces.ISaveAndLoad
	{
		public async Task SaveTextAsyncAppend (string filename, string text)
		{
			try{
				var docsPath = Android.OS.Environment.ExternalStorageDirectory.ToString();
				var path = Path.Combine(docsPath, filename);

//				using (StreamWriter sw = File.AppendText(path))
//				{
//					await sw.WriteAsync(text);
//				}

				System.IO.File.AppendAllText(path, text);
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("SaveTextAsyncAppend", ex);
			}
		}

		public async Task SaveTextAsync (string filename, string text)
		{
			try{
				var docsPath = Android.OS.Environment.ExternalStorageDirectory.ToString();
				var path = Path.Combine(docsPath, filename);

//				using (StreamWriter sw = File.CreateText(path))
//				{
//					await sw.WriteAsync(text);
//				}

				System.IO.File.WriteAllText(path, text);
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("SaveTextAsync", ex);
			}
		}

		public string LoadText (string path, string filename)
		{
			try{
				string fullPath = Path.Combine(path, filename);
				string text = "";	

				if(File.Exists(fullPath)){
					text = System.IO.File.ReadAllText(fullPath);

					if(text != ""){
						return text;
					}else{
						return "";
					}
				}else{
					return "";
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("LoadText", ex);
				return "";
			}
		}
	}
}

