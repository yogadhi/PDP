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

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Shared.Modules.Pages
{
	public class AboutPage : ContentPage
	{
		StackLayout headerLayout, informationLayout;
		Image logoImage;
		cxLabel txtVersion, txtEmailDeveloper, txtEmailDatabase;

		public AboutPage ()
		{
			try{
				Title = "Tentang Aplikasi";

				logoImage = new Image{
					Source = Shared.Classes.Optimizer.Image.FromFile("ic_logo"),
					Aspect = Aspect.AspectFit, 
					HeightRequest = 100, 
					WidthRequest = 100
				};

				txtVersion = new cxLabel {
					Text = "v" + DependencyService.Get<Shared.Classes.Dependencies.Interfaces.IMyDevice>().AppVersionName(), 
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					TextColor = Color.White,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				};
					
				txtEmailDeveloper = new cxLabel {
					Text = "yogadhiprananda@gmail.com", 
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					TextColor = Color.Blue,
					VerticalOptions = LayoutOptions.Start,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				};

				txtEmailDatabase = new cxLabel {
					Text = "krisnapkurniawan@gmail.com", 
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					TextColor = Color.Blue,
					VerticalOptions = LayoutOptions.Start,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				};

				informationLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(0,15,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Color.White,
					Children = {
						new cxLabel {
							Text = "Developer Team", 
							FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
							FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
							TextColor = Color.Black,
							VerticalOptions = LayoutOptions.Start,
							HorizontalOptions = LayoutOptions.CenterAndExpand
						},
						new StackLayout {
							Spacing = 10,
							Padding = new Thickness(20,10,20,0),
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.Start,
							BackgroundColor = Color.White,
							Children = {
								txtEmailDeveloper,
								Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
								txtEmailDatabase,
								Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
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
								logoImage, 
								txtVersion
							}
						},
						informationLayout
					}
				};

				Content = new StackLayout { 
					Spacing = 0,
					Padding = new Thickness (0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Color.White,
					Children = {
						headerLayout, 
					}
				};

				var informationLayoutTap = new TapGestureRecognizer ();
				informationLayoutTap.NumberOfTapsRequired = 1;
				informationLayoutTap.Tapped += async (s, e) => {
					var email = new Intent (Android.Content.Intent.ActionSend);
					email.PutExtra(Android.Content.Intent.ExtraEmail, new string[]{ txtEmailDeveloper.Text });
					email.PutExtra(Android.Content.Intent.ExtraCc, new string[]{ txtEmailDatabase.Text });
					email.PutExtra(Android.Content.Intent.ExtraSubject, "Hello PasarSurya Developers");
					email.PutExtra(Android.Content.Intent.ExtraText, "Hello, ");
					email.SetType("message/rfc822");
					Forms.Context.StartActivity(email);
				};
				informationLayout.GestureRecognizers.Add (informationLayoutTap);
				txtEmailDeveloper.GestureRecognizers.Add (informationLayoutTap);
				txtEmailDeveloper.GestureRecognizers.Add (informationLayoutTap);
			}
			catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("Layout", ex);
			}
		}

		protected override bool OnBackButtonPressed ()
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


