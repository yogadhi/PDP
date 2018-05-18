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
using YAP.Core;
using Acr.UserDialogs;
using System.Globalization;

namespace Shared.Modules.Pages
{
	public class LoginPage : ContentPage
	{
		Image imgBG, imgLogo, imgUsername, imgPassword;
		cxEntry txtUsername, txtPassword;
		cxButton BtnLogin;
		cxLabel versionLabel;
		cxPicker pasarPicker;
		string version = "";
		string strKdPasar = "";
		List<Shared.Services.Table.REKENING_PASAR> contPasar = new List<Shared.Services.Table.REKENING_PASAR>();
		string strKdpasar = "";
		string strUserID = "";
		string strUsername = "";
		string strPassword = "";
		DateTime dateStart;
		DateTime dateEnd;
		string status = "";
		string tgl_close = "";

		public LoginPage()
		{
			try
			{				
				AbsoluteLayout peakLayout = new AbsoluteLayout
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Color.Transparent
				};

				imgBG = new Image()
				{
					Source = Shared.Classes.Optimizer.Image.FromFile("coffee_mug.9"),
					Aspect = Aspect.AspectFill,
				};

				imgLogo = new Image()
				{
					Source = Shared.Classes.Optimizer.Image.FromFile("ic_logo"),
					Aspect = Aspect.AspectFit,
					HeightRequest = 120, 
					WidthRequest = 170
				};

				pasarPicker = new cxPicker{
					Title = "Pilih Pasar", 
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi, 
					Alignment = TextAlignment.Center, 
					FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.StartAndExpand, 
					TextColor = Color.White, 
					BackgroundColor = Color.FromHex("7fffffff"),
				};

				#region Username
				var boxImgUsername = new AbsoluteLayout
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
				};

				var boxUsername = new BoxView()
				{
					Color = Color.FromHex("7fffffff"),
					HeightRequest = 60,
					WidthRequest = 60,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
				};

				imgUsername = new Image()
				{
					Source = Shared.Classes.Optimizer.Image.FromFile("username_icon"),
					Aspect = Aspect.AspectFill
				};

				AbsoluteLayout.SetLayoutFlags(boxUsername, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(boxUsername, new Rectangle(0, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
				AbsoluteLayout.SetLayoutFlags(imgUsername, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(imgUsername, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

				boxImgUsername.Children.Add(boxUsername);
				boxImgUsername.Children.Add(imgUsername);

				var boxTxtUsername = new AbsoluteLayout
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
				};

				var BoxLabelUsername = new BoxView()
				{
					Color = Color.FromHex("7fffffff"),
					HeightRequest = 60,
					WidthRequest = 200,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
				};

				txtUsername = new cxEntry()
				{
					Placeholder = "Username",
					TextColor = Color.Black,
					WidthRequest = Device.OnPlatform(175,195,0),
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					PlaceholderTextColor = Color.Black,
					FontSize = 20,
					MaxLength = 30,
				};

				AbsoluteLayout.SetLayoutFlags(BoxLabelUsername, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(BoxLabelUsername, new Rectangle(0, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
				AbsoluteLayout.SetLayoutFlags(txtUsername, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(txtUsername, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

				boxTxtUsername.Children.Add(BoxLabelUsername);
				boxTxtUsername.Children.Add(txtUsername);

				var UsernameLayout = new StackLayout()
				{
					Spacing = 4,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						boxImgUsername,
						boxTxtUsername
					}
				};
				#endregion

				#region Password
				var boxImgPassword = new AbsoluteLayout
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
				};

				var boxPassword = new BoxView()
				{
					Color = Color.FromHex("7fffffff"),
					HeightRequest = 60,
					WidthRequest = 60,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
				};

				imgPassword = new Image()
				{
					Source = Shared.Classes.Optimizer.Image.FromFile("password_icon"),
					Aspect = Aspect.AspectFill
				};

				AbsoluteLayout.SetLayoutFlags(boxPassword, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(boxPassword, new Rectangle(0, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
				AbsoluteLayout.SetLayoutFlags(imgPassword, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(imgPassword, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

				boxImgPassword.Children.Add(boxPassword);
				boxImgPassword.Children.Add(imgPassword);

				var boxTxtPassword = new AbsoluteLayout
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
				};

				var BoxLabelPassword = new BoxView()
				{
					Color = Color.FromHex("7fffffff"),
					HeightRequest = 60,
					WidthRequest = 200,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
				};

				txtPassword = new cxEntry()
				{
					Placeholder = "Password",
					TextColor = Color.Black,
					WidthRequest = Device.OnPlatform(175,195,0),
					IsPassword = true,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					PlaceholderTextColor = Color.Black,
					FontSize = 20,
					MaxLength = 30,
				};

				AbsoluteLayout.SetLayoutFlags(BoxLabelPassword, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(BoxLabelPassword, new Rectangle(0, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
				AbsoluteLayout.SetLayoutFlags(txtPassword, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(txtPassword, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

				boxTxtPassword.Children.Add(BoxLabelPassword);
				boxTxtPassword.Children.Add(txtPassword);

				var PasswordLayout = new StackLayout()
				{
					Spacing = 4,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						boxImgPassword,
						boxTxtPassword
					}
				};
				#endregion

				#region button
				BtnLogin = new cxButton
				{
					Text = "LOGIN",
					TextColor = Color.White,
					FontSize = 20,
					FontFamily = Shared.Settings.Styles.Fonts.Base,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					HeightRequest = 50,
					WidthRequest = 265,
				};
				#endregion

				var fields = new StackLayout()
				{
					Spacing = 8,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Children = {
						pasarPicker,
						UsernameLayout,
						PasswordLayout
					}
				};

				versionLabel = new cxLabel
				{
					Text = "",
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					TextColor = Color.White, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
				};

				var buttons = new StackLayout()
				{
					Spacing = 8,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Children = {
						BtnLogin,
						versionLabel
					}
				};

				AbsoluteLayout.SetLayoutFlags(imgBG, AbsoluteLayoutFlags.All);
				AbsoluteLayout.SetLayoutBounds(imgBG, new Rectangle(0, 0, 1f, 1f));

				AbsoluteLayout.SetLayoutFlags(imgLogo, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(imgLogo,
					new Rectangle(0.5, 0.15, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

				AbsoluteLayout.SetLayoutFlags(fields, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(fields,
					new Rectangle(0.5, 0.55, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

				AbsoluteLayout.SetLayoutFlags(buttons, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(buttons,
					new Rectangle(0.5, 0.9, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

				peakLayout.Children.Add(imgBG);
				peakLayout.Children.Add(imgLogo);
				peakLayout.Children.Add(fields);
				peakLayout.Children.Add(buttons);

				var MainLayout = new StackLayout{
					BackgroundColor = Shared.Settings.Styles.Colors.Background.Accent,
					Spacing = 0,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					Children = {
						peakLayout
					}
				};
						
				Content = new StackLayout()
				{
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Spacing = 0,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					Children = {
						peakLayout
					}
				};

				pasarPicker.SelectedIndexChanged += (sender, e) => {
					if(pasarPicker.SelectedIndex != -1){
						strKdPasar = contPasar[pasarPicker.SelectedIndex].kdpasar.ToString();
					}
				};
						
				txtUsername.Completed += (sender, e) => {
					txtPassword.Focus();
				};

				txtPassword.Completed += (sender, e) => {
					if(pasarPicker.SelectedIndex != -1 ){
						Login(txtUsername.Text.Trim(), txtPassword.Text.Trim());
					}else{
						Shared.Settings.Panels.Alert.Display("Mohon pilih pasar yang akan dituju", "Pasar Tidak Ditemukan", "OK");
					}
				};

				BtnLogin.Clicked += (sender, e) =>
				{
					if(pasarPicker.SelectedIndex != -1 ){
						Login(txtUsername.Text.Trim(), txtPassword.Text.Trim());
					}else{
						Shared.Settings.Panels.Alert.Display("Mohon pilih pasar yang akan dituju", "Pasar Tidak Ditemukan", "OK");
					}
				};
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("Layout", ex);
			}
		}

		private async void Login(string username, string password)
		{
			try
			{
				var task = AppShared1.App.Database.GetUser(username, password);

				if(task != null && task.Count == 1){
					strKdpasar = strKdPasar;
					strUserID = task[0].IDLogin.ToString();
					strUsername = task[0].UserLogin.ToString();
					strPassword = task[0].PassLogin.ToString();
					dateStart = Shared.Classes.Optimizer.Converter.StringToDateTime(task[0].Date_Start.ToString(), Shared.Settings.Libraries.Enumerables.ConvertDateMode.Login);
					dateEnd = DateTime.Now.AddDays(Convert.ToInt32(task[0].Duration.ToString()));
					status = task[0].Status.ToString();
					tgl_close = task[0].tgl_close.ToString();

					await CheckActiveSession(strKdPasar, strUserID, strUsername, strPassword, dateStart, dateEnd, status, tgl_close);
				}else{
					Shared.Settings.Panels.Alert.Display(Shared.Settings.Libraries.Strings.InvalidUserPassMessage, Shared.Settings.Libraries.Strings.InvalidUserPassTitle, "OK");
				}
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("Login", ex);
			}
		}

		private async Task CheckActiveSession(string kdpasar, string userid, string username, string password, DateTime datestart, DateTime dateend, string status, string tglclose){
			try{
				if(DateTime.Now >= datestart && DateTime.Now <= dateend){
					string printerPort = DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().LoadText(Android.OS.Environment.ExternalStorageDirectory.ToString(), "PDPS_PRINTER_PORT.txt");

					if(printerPort == ""){
						await Shared.Settings.Panels.LoadingTask.ShowLoading();
						await Navigation.PushAsync(new Shared.Modules.Pages.BluetoothPage(kdpasar, userid, username, password, datestart, dateend, status, tglclose), true);
					}else{
						var data = Shared.Classes.Cache.cxCache.AccessCredential.container(kdpasar, userid, username, password, datestart.ToString("dd/MM/yyyy hh:mm:ss"), dateend.ToString("dd/MM/yyyy hh:mm:ss"), status, tglclose, printerPort.Trim());
						await Shared.Classes.Cache.cxCache.AccessCredential.Store(data);

						MessagingCenter.Send<ParamPasser> (new ParamPasser () { stringParameter = txtUsername.Text }, "User");
						MessagingCenter.Send<ParamPasser> (new ParamPasser () { boolParameter = true }, "Update");
						MessagingCenter.Send<ParamPasser> (new ParamPasser () { DateParameter = DateTime.Now }, "Timer");

						await Shared.Settings.Panels.LoadingTask.ShowLoading();
						Shared.Settings.Panels.Alert.Display("Hak akses Anda berakhir pada " + dateend.ToString("dd/MM/yyyy hh:mm:ss"), "Login Berhasil", "OK");
						await Navigation.PopModalAsync(true);
					}
				}else{
					Shared.Settings.Panels.Alert.Display("Hak akses Anda kadaluarsa. Mohon hubungi administrator", "Login Gagal", "OK");
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send("CheckActiveSession", ex);
			}
		}

		private async void GetRekPasar()
		{
			try
			{
				if(pasarPicker.Items.Count <= 0){
					var task = AppShared1.App.Database.GetRekPasar();

					if(task != null && task.Count > 0){
						contPasar = task;
						await PopulateRekPasar(task);
					}
				}
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("GetRekPasar", ex);
			}
		}

		private async Task PopulateRekPasar(List<Shared.Services.Table.REKENING_PASAR> pasar){
			try{
				foreach(var index in pasar){
					pasarPicker.Items.Add(index.nmpasar.ToString());
				}
				await Shared.Settings.Panels.LoadingTask.ShowLoading();
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send("PopulateRekPasar", ex);
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

		protected override async void OnAppearing()
		{
			try
			{
				NavigationPage.SetHasNavigationBar(this, false);
				version = DependencyService.Get<Shared.Classes.Dependencies.Interfaces.IMyDevice>().AppVersionName();
				versionLabel.Text = "v" + version;
			
				GetRekPasar();

				if(pasarPicker.Items.Count > 0)
				{
					pasarPicker.SelectedIndex = -1;
				}				

				MessagingCenter.Subscribe<Shared.Classes.ParamPasser>(this, "Done", (param) =>
					{
						if (param.boolParameter == true)
						{
							Shared.Settings.Panels.Alert.Display("Hak akses Anda berakhir pada " + dateEnd.ToString("dd/MM/yyyy hh:mm:ss"), "Login Berhasil", "OK");
							Navigation.PopModalAsync(true);
						}
					});

				txtUsername.Text = "";
				txtPassword.Text = "";
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("OnAppearing", ex);
			}
		}

		private async void CloseLogin()
		{
			await this.Navigation.PopModalAsync(false);
		}
	}
}

