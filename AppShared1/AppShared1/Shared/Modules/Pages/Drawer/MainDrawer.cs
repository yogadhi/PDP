using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Shared.Classes.Components;
using AppShared1;
using ImageCircle.Forms.Plugin.Abstractions;

namespace Shared.Modules.Pages.Drawer
{
    public class MainDrawer : ContentPage
	{
		public ListView Menu { get; set; }
		public StackLayout Logout { get; set; }
		public cxLabel profileName { get; set; }
		public StackLayout profileContent { get; set; }

        public MainDrawer()
		{
			try{
                NavigationPage.SetHasNavigationBar(this, false);
                Title = "Menu";

				Menu = new Classes.Components.ListViews.Drawer.Main();

                var profileImg = new CircleImage
                {
                    BorderThickness = 0,
                    HeightRequest = 70,
                    WidthRequest = 70,
                    Aspect = Aspect.AspectFill,
                    HorizontalOptions = LayoutOptions.Start,
					Source = Shared.Classes.Optimizer.Image.FromFile("ic_profile") //UriImageSource.FromUri(new Uri("http://upload.wikimedia.org/wikipedia/commons/5/55/Tamarin_portrait.JPG"))
                };

                profileName = new cxLabel
                {
                    Text = "",
                    TextColor = Color.White,
                    //FontAttributes = FontAttributes.Bold, 
                    FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi, 
					HorizontalOptions = LayoutOptions.StartAndExpand
                };

                profileContent = new StackLayout
                {
                    Spacing = 5,
                    Padding = Shared.Settings.Styles.Paddings.Drawer.Profile,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children = { 
                        profileImg, 
                        profileName
                    }
                };

                var profileLayout = new StackLayout
                {
                    Spacing = 0,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
                    Children = { profileContent }
                };

				var logoutImage = new Image {
					HeightRequest = 30,
					WidthRequest = 30,
					Aspect = Aspect.AspectFill,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					Source = "logout_icon",
				};

				var imageLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness (15, 0, 15, 0),
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.Start,
					Children = { logoutImage }
				};

				var imgLogo = new Image()
				{
					Source = Shared.Classes.Optimizer.Image.FromFile("ic_logo"),
					Aspect = Aspect.AspectFit,
					HeightRequest = 70,
					WidthRequest = 70,
					BackgroundColor = Color.Transparent
				};

				var versionLabel = new cxLabel {
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					TextColor = Shared.Settings.Styles.Colors.Font.Base,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					Text = "v" + DependencyService.Get<Shared.Classes.Dependencies.Interfaces.IMyDevice>().AppVersionName()
				};


				var logoutLabel = new cxLabel {
                    FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
                    FontSize = Shared.Settings.Styles.Sizes.Font.Base,
                    TextColor = Shared.Settings.Styles.Colors.Font.Base,
					HorizontalOptions = LayoutOptions.End,
					VerticalOptions = LayoutOptions.Center,
					Text = "Logout"
				};

				var signoutLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness (10, 10, 10, 10),
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Children = { imageLayout, logoutLabel }
				};

				Logout = new StackLayout {
					Spacing = 0,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.End,
					Children = { 
						new BoxView() {
							HeightRequest = 1,
							BackgroundColor = Shared.Settings.Styles.Colors.Background.Dark,
						},
						signoutLayout 
					}
				};

				Content = new StackLayout {
                    Spacing = 0,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Padding = new Thickness (0,Device.OnPlatform(10,0,0),0,0),
					BackgroundColor = Color.White,
					Children = {
						profileLayout,
						Menu,
						new StackLayout {
							Spacing = 0,
							Padding = new Thickness (10, 5, 10, 5),
							HorizontalOptions = LayoutOptions.Center,
							VerticalOptions = LayoutOptions.Center,
							Children = { imgLogo, versionLabel }
						},
						Logout
					}
				};

			}
			catch(Exception ex){
                Shared.Services.Logs.Insights.Send("Layout", ex);
			}
		}

        protected override void OnAppearing()
        {
			try
			{
				
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("OnAppearing", ex);
				//throw ex;
			}
        }
	}
}