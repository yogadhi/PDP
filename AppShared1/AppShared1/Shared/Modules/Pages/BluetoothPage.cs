using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Shared.Classes.Components;
using System.Threading.Tasks;
using Shared.Classes;
using System.Globalization;

namespace Shared.Modules.Pages
{
	public class BluetoothPage : ContentPage
	{
		StackLayout remarkLayout, btnLayout;
		cxEntry txtRemark; 
		cxButton btnSubmit;
		string strKdpasar = "";
		string strUserID = "";
		string strUsername = "";
		string strPassword = "";
		DateTime dateStart;
		DateTime dateEnd;
		string Stts = "";
		string tgl_close = "";

		public BluetoothPage (string kdpasar, string userid, string username, string password, DateTime datestart, DateTime dateend, string status, string tglclose)
		{
			try{
				Title = "Bluetooth Printer Port";

				strKdpasar = kdpasar;
				strUserID = userid;
				strUsername = username;
				strPassword = password;
				dateStart = datestart;
				dateEnd = dateend;
				Stts = status;
				tgl_close = tglclose;
			
				txtRemark = new cxEntry {
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

				remarkLayout = new StackLayout{
					Spacing = 0, 
					Padding = new Thickness(15,15,15,15),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.Start, 
					BackgroundColor = Color.White, 
					HeightRequest = 150,
					Children = {
						txtRemark, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Color.Blue, 1)
					}
				};

				btnSubmit = new cxButton
				{
					Text = "SIMPAN",
					TextColor = Color.White,
					FontSize = 20,
					FontFamily = Shared.Settings.Styles.Fonts.Base,
					HeightRequest = 50,
					WidthRequest = 265,
				};
				btnSubmit.BackgroundColor = Shared.Settings.Styles.Colors.Background.DarkRed;

				btnLayout = new StackLayout{
					Spacing = 0, 
					Padding = new Thickness(10,20,10,0),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.Start, 
					HeightRequest = 50, 
					BackgroundColor = Color.White,
					Children = {
						btnSubmit
					}
				};

				Content = new StackLayout {
					Spacing = 0,
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					BackgroundColor = Color.White, 
					Children = {
						new StackLayout {
							Spacing = 0,
							Padding = new Thickness(20, 10, 20, 10),
							HorizontalOptions = LayoutOptions.FillAndExpand, 
							VerticalOptions = LayoutOptions.Start, 
							BackgroundColor = Color.White, 
							Children = {
								new cxLabel{
									Text = "Silakan memasukkan Bluetooth Printer Port yang tertera pada printer Anda.", 
									FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
									TextColor = Color.Black,
									HorizontalOptions = LayoutOptions.FillAndExpand, 
									VerticalOptions = LayoutOptions.CenterAndExpand, 
									HorizontalTextAlignment = TextAlignment.Start, 
									VerticalTextAlignment = TextAlignment.Start
								}
							}
						},
						remarkLayout,
						btnLayout
					}
				};

				btnSubmit.Clicked += async (sender, e) => {
					if(txtRemark.Text != "" && txtRemark.Text.Length > 0){
						var data = Shared.Classes.Cache.cxCache.AccessCredential.container(strKdpasar, strUserID, strUsername, strPassword, dateStart.ToString("dd/MM/yyyy hh:mm:ss"), dateEnd.ToString("dd/MM/yyyy hh:mm:ss"), Stts, tgl_close, txtRemark.Text.Trim());
						await Shared.Classes.Cache.cxCache.AccessCredential.Store(data);
						await DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().SaveTextAsync("PDPS_PRINTER_PORT.txt", txtRemark.Text.Trim());
						MessagingCenter.Send<ParamPasser> (new ParamPasser () { boolParameter = true }, "Update");
						MessagingCenter.Send<ParamPasser> (new ParamPasser () { boolParameter = true }, "Done");
						MessagingCenter.Send<ParamPasser> (new ParamPasser () { stringParameter = strUsername }, "User");
						MessagingCenter.Send<ParamPasser> (new ParamPasser () { DateParameter = DateTime.Now }, "Timer");
						await Navigation.PopAsync(true);
					}else{
						Shared.Settings.Panels.Alert.Display("Mohon isi Bluetooth Printer Port", "Bluetooth Printer Port", "OK");
					}
				};
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send("Layout", ex);
			}
		}

		protected override void OnAppearing ()
		{
			try{

			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send("OnAppearing", ex);
			}
		}

		protected override bool OnBackButtonPressed()
		{
			PromptBack ();
			return true;
		}

		async void PromptQuit()
		{
			try
			{
				var answer = await Shared.Settings.Panels.Alert.Display(Shared.Settings.Libraries.Strings.promptQuitApp, Shared.Settings.Libraries.Strings.promptQuitApp, "Yes", "No");
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

		async void PromptBack()
		{
			try
			{
				await Navigation.PopAsync(true);
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("PromptBack", ex);
			}
		}
	}
}


