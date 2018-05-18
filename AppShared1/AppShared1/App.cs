using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppShared1
{
	public class App : Application
	{
		static Shared.Services.DBQuery database;

		public App ()
		{
            MainPage = new RootPage();
		}

		public static Shared.Services.DBQuery Database {
			get { 
				if (database == null) {
					database = new Shared.Services.DBQuery ();
				}
				return database; 
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected async override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
