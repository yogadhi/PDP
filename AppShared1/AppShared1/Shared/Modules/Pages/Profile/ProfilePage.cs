using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;
using Shared.Classes.Cache;
using Shared.Classes;

namespace Shared.Modules.Pages.Profile
{
	public class ProfilePage : ContentPage
	{
		StackLayout headerLayout, lblBluetoothPort, lblTimerLogout, btnSimpan;
		Image imgLogo;
		cxLabel txtUid, txtUname;
		cxEntry txtBluetoothport, txtTimerLogout;
		string printerPort;
		string timerlogout;
		string strKdpasar = "";
		string strUserID = "";
		string strUsername = "";
		string strPassword = "";
		string dateStart;
		string dateEnd;
		string Stts = "";
		string tgl_close = "";

		Shared.Classes.Cache.IAccessCredential cachedAccessCredential;

		public ProfilePage ()
		{
			try{
				Title = "Profil Pengguna";

				imgLogo = new Image()
				{
					Source = Shared.Classes.Optimizer.Image.FromFile("ic_profile"),
					Aspect = Aspect.AspectFit,
					HeightRequest = 100, 
					WidthRequest = 100
				};

				txtUid = new cxLabel {
					Text = "",
					FontSize = 24,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.White
				};

				txtUname = new cxLabel {
					Text = "",
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.White,
				};

				txtBluetoothport = new cxEntry {
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					TextColor = Color.Black, 
					Alignment = TextAlignment.Center, 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.Start, 
					BackgroundColor = Color.White,
					Placeholder = "Port", 
					PlaceholderTextColor = Color.Gray, 
					Text = ""
				};

				txtTimerLogout = new cxEntry {
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					TextColor = Color.Black, 
					Alignment = TextAlignment.Center, 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.Start, 
					BackgroundColor = Color.White,
					Placeholder = "durasi (menit)", 
					PlaceholderTextColor = Color.Gray, 
					Keyboard = Keyboard.Numeric,
					Text = ""
				};

				lblBluetoothPort = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.StartAndExpand, 
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.FillAndExpand, 
							VerticalOptions = LayoutOptions.Start, 
							Children = {
								new cxLabel {
									Text = "Bluetooth Port",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
									HorizontalOptions = LayoutOptions.Center,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (30, 0, 30, 0), 
							HorizontalOptions = LayoutOptions.FillAndExpand, 
							VerticalOptions = LayoutOptions.Start, 
							Children = {
								txtBluetoothport,
								Shared.Settings.Styles.Pages.LayoutLine.borderX(Color.Blue, 1)
							}
						}
					}
				};

				lblTimerLogout = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.StartAndExpand, 
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 3, 
							Padding = new Thickness (30, 0, 30, 0), 
							HorizontalOptions = LayoutOptions.FillAndExpand, 
							VerticalOptions = LayoutOptions.Start, 
							Children = {
								new cxLabel {
									Text = "Timer Logout",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
									HorizontalOptions = LayoutOptions.Center,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								},
								new cxLabel {
									Text = "Rentang waktu aplikasi akan logout otomatis",
									FontSize = 14,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.Center,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								},
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (30, 0, 30, 0), 
							HorizontalOptions = LayoutOptions.FillAndExpand, 
							VerticalOptions = LayoutOptions.Start, 
							Children = {
								txtTimerLogout,
								Shared.Settings.Styles.Pages.LayoutLine.borderX(Color.Blue, 1)
							}
						}
					}
				};

				headerLayout = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.StartAndExpand, 
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 15, 0, 15),
							HorizontalOptions = LayoutOptions.FillAndExpand, 
							VerticalOptions = LayoutOptions.Start, 
							BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
							Children = {
								imgLogo, 
								txtUid, 
								txtUname
							}
						},
						lblBluetoothPort,
						lblTimerLogout
					}
				};

				var Simpan = new cxLabel
				{
					Text = "Simpan",
					TextColor = Color.White,
					FontSize = 20,
					FontFamily = Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};

				btnSimpan = new StackLayout
				{
					HeightRequest = 40,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.End,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Padding = new Thickness(0, 5, 0, 5),
					Children = {
						Simpan
					}
				};

				Content = new StackLayout { 
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					BackgroundColor = Color.White,
					Children = {
						headerLayout,
						btnSimpan
					}
				};

				var btnLanjutTap = new TapGestureRecognizer ();
				btnLanjutTap.NumberOfTapsRequired = 1;
				btnLanjutTap.Tapped += async (s, e) => {
					MessagingCenter.Send<ParamPasser> (new ParamPasser () { DateParameter = DateTime.Now }, "Timer");
					SaveChanges();
				};
				btnSimpan.GestureRecognizers.Add (btnLanjutTap);
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("Layout", ex);
			}
		}

		async void SaveChanges(){
			try{
				var data = Shared.Classes.Cache.cxCache.AccessCredential.container(strKdpasar, strUserID, strUsername, strPassword, dateStart, dateEnd, Stts, tgl_close, txtBluetoothport.Text.Trim());
				await Shared.Classes.Cache.cxCache.AccessCredential.Store(data);
				await DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().SaveTextAsync("PDPS_PRINTER_PORT.txt", txtBluetoothport.Text.Trim());
				await DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().SaveTextAsync("PDPS_TIMER_LOGOUT.txt", txtTimerLogout.Text.Trim());
				await Shared.Settings.Panels.LoadingTask.ShowLoading();
				Shared.Settings.Panels.Alert.Display("Bluetooth port berhasil disimpan", "Bluetooth Port", "OK");
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("SaveBluetoothPort", ex);
			}
		}

		protected override async void OnAppearing ()
		{
			try{
				cachedAccessCredential = await Shared.Classes.Cache.cxCache.AccessCredential.Collect();
				printerPort = DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().LoadText(Android.OS.Environment.ExternalStorageDirectory.ToString(), "PDPS_PRINTER_PORT.txt");
				timerlogout = DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().LoadText(Android.OS.Environment.ExternalStorageDirectory.ToString(), "PDPS_TIMER_LOGOUT.txt");

				txtUid.Text = cachedAccessCredential.UserID;
				txtUname.Text = cachedAccessCredential.Username;
				txtBluetoothport.Text = printerPort;
				txtTimerLogout.Text = timerlogout;

				strKdpasar = cachedAccessCredential.Kdpasar;
				strUserID = cachedAccessCredential.UserID;
				strUsername = cachedAccessCredential.Username;
				strPassword = cachedAccessCredential.Password;
				dateStart = cachedAccessCredential.DateStart;
				dateEnd = cachedAccessCredential.DateEnd;
				Stts = cachedAccessCredential.Status;
				tgl_close = cachedAccessCredential.Tgl_Close;
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("OnAppearing", ex);
			}
		}

		protected override bool OnBackButtonPressed()
		{
			PromptQuit();
			return true;
		}

		async void PromptQuit()
		{
			try
			{
				var answer = await Shared.Settings.Panels.Alert.Display(Shared.Settings.Libraries.Strings.promptQuitApp, "Quit", "Yes", "No");
				if (answer == true)
				{
					if (Device.OS == TargetPlatform.Android)
					{
						DependencyService.Get<Shared.Classes.Dependencies.Interfaces.IGadget>().Close_App();
					}
				}
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("PromptQuit", ex);
			}
		}
	}
}


