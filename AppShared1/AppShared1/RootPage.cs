using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Shared.Classes;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace AppShared1
{
    public class RootPage : MasterDetailPage
    {
		Shared.Classes.Cache.IAccessCredential cachedAccessCredential;
        Shared.Modules.Pages.Drawer.MainDrawer mainDrawer; 
		NavigationPage NavigateLogin;
		string filename, fullPath;
		DateTime dateNow = DateTime.Now;
		bool isLoginPage = false;
		string path = Android.OS.Environment.ExternalStorageDirectory.ToString();
		string timerlogout = DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().LoadText(Android.OS.Environment.ExternalStorageDirectory.ToString(), "PDPS_TIMER_LOGOUT.txt");
		double dblTimerLogout;
		 
        public RootPage()
        {
			try{
				NavigateLogin = new NavigationPage(new Shared.Modules.Pages.LoginPage());
				mainDrawer = new Shared.Modules.Pages.Drawer.MainDrawer();

				mainDrawer.Menu.ItemSelected += (sender, e) =>
				{
					NavigateTo(e.SelectedItem as Shared.Modules.Binds.Drawer.MainDrawer);
				};

				Master = mainDrawer;

				NavigateTo(Shared.Classes.Components.ListViews.Drawer.Main.data[0]);

				var logoutTap = new TapGestureRecognizer();
				logoutTap.Tapped += (s, e) =>
				{
					IsPresented = false; 
					PromptLogout();
				};
				mainDrawer.Logout.GestureRecognizers.Add(logoutTap);

				MessagingCenter.Subscribe<Shared.Classes.ParamPasser>(this, "Timer", (param) =>
					{
						if (param.DateParameter != null)
						{
							dateNow = param.DateParameter;
							isLoginPage = false;
						}
					});

				Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("RootPage", ex);
				throw ex;
			}
        }

		bool OnTimerTick()
		{
			try{
				var datediff = (DateTime.Now - dateNow).TotalMinutes;

				if(!string.IsNullOrWhiteSpace(timerlogout)){
					dblTimerLogout = Convert.ToDouble(timerlogout.Trim());

					if (datediff >= dblTimerLogout) {
						Logout ();
						dateNow = DateTime.Now;
						return false;
					}
				}
				return true;
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("OnTimerTick", ex);
				isLoginPage = false;
				return false;
			}
		}

        protected async override void OnAppearing()
        {
            try{
				cachedAccessCredential = await Shared.Classes.Cache.cxCache.AccessCredential.Collect();

				if(cachedAccessCredential == null){
					isLoginPage = true;
					await Navigation.PushModalAsync(NavigateLogin);
				}else{
					isLoginPage = false;
					mainDrawer.profileName.Text = cachedAccessCredential.Username.ToUpper();
				}

				MessagingCenter.Subscribe<Shared.Classes.ParamPasser>(this, "User", (param) =>
					{
						if (param.stringParameter != null)
						{
							isLoginPage = true;
							mainDrawer.profileName.Text = param.stringParameter.ToString();
						}
					});

				filename = "PDPS_PRINTER_PORT.txt";
				fullPath = Path.Combine(path, filename);
				if(!File.Exists(fullPath)){
					DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().SaveTextAsync(filename, "");
				}

				filename = "_REKENING.txt";
				fullPath = Path.Combine(path, filename);
				DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().SaveTextAsync(filename, "");
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("OnAppearing", ex);
				throw ex;
			}
        }
			
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
		}
			
        public void NavigateTo(Shared.Modules.Binds.Drawer.MainDrawer menu)
        {
            try
            {
                if (menu == null)
                    return;

                Page _page = (Page)Activator.CreateInstance(menu.TargetType);

                Detail = new NavigationPage(_page);
                mainDrawer.Menu.SelectedItem = menu;

                IsPresented = false;
            }
            catch (Exception ex)
            {
                Shared.Services.Logs.Insights.Send("NavigateTo", ex);
				throw ex;
            }
        }
			
		async void PromptLogout()
		{
			try
			{
				Logout();
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("PromptLogout", ex);
				//throw;
			}
		}

		private async void Logout()
		{
			try
			{
				isLoginPage = true;
				await Shared.Classes.Cache.cxCache.AccessCredential.Dump();
				await Shared.Settings.Panels.LoadingTask.ShowLoading();
				await Navigation.PushModalAsync(NavigateLogin);
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("Logout", ex);
			}
		}


    }
}
