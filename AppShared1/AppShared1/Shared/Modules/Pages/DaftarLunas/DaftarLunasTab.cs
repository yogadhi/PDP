using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;
using Shared.Classes.Cache;

namespace Shared.Modules.Pages.DaftarLunas
{
	public class DaftarLunasTab : ContentView
	{
		StackLayout tab1, tab2, tab3, tabContainer1, tabContainer2, tabContainer3;
		public ListView RekAirLV { get; set; }
		public ListView RekListrikLV { get; set; }
		public ListView RekTempatLV { get; set; }
		BoxView activeBox1, activeBox2, activeBox3;
		cxLabel txt1, txt2, txt3;

		public TapGestureRecognizer tapTab1, tapTab2, tapTab3;

		public DaftarLunasTab ()
		{
			try{
				RekAirLV = new Shared.Classes.Components.ListViews.PembayaranResult (typeof(Shared.Modules.DataTemplates.RekeningAir.RekeningAir));
				RekListrikLV = new Shared.Classes.Components.ListViews.PembayaranResult (typeof(Shared.Modules.DataTemplates.RekeningListrik.RekeningListrik));
				RekTempatLV = new Shared.Classes.Components.ListViews.PembayaranResult (typeof(Shared.Modules.DataTemplates.RekeningTempat.RekeningTempat));

				txt1 = new cxLabel {
					Text = "Tempat",
					TextColor = Color.White,//Color.FromHex("4a6ea9"),
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					FontSize = 15,
				};
				txt2 = new cxLabel {
					Text = "Listrik",
					TextColor = Shared.Settings.Styles.Colors.Background.GrayLight,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					FontSize = 15,
				};
				txt3 = new cxLabel {
					Text = "Air",
					TextColor = Shared.Settings.Styles.Colors.Background.GrayLight,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					FontSize = 15,
				};

				var tabBox1 = new StackLayout () {
					Spacing = 0,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Padding = new Thickness(0,10,0,10),
					Children = {
						txt1,
					}	
				};
				var tabBox2 = new StackLayout () {
					Spacing = 0,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Padding = new Thickness(0,10,0,10),
					Children = {
						txt2,
					}	
				};
				var tabBox3 = new StackLayout () {
					Spacing = 0,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Padding = new Thickness(0,10,0,10),
					Children = {
						txt3,
					}	
				};

				activeBox1 = new BoxView () {
					BackgroundColor = Color.White,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					HeightRequest = 5,
				};
				activeBox2 = new BoxView () {
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					HeightRequest = 5,
				};
				activeBox3 = new BoxView () {
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					HeightRequest = 5,
				};

				tab1 = new StackLayout () {
					Spacing = 0,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Children = {
						tabBox1,
						activeBox1
					}	
				};

				tab2 = new StackLayout () {
					Spacing = 0,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Children = {
						tabBox2,
						activeBox2
					}	
				};

				tab3 = new StackLayout () {
					Spacing = 0,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Children = {
						tabBox3,
						activeBox3
					}	
				};

				var tabHeader = new StackLayout () {
					Spacing = 0,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						tab1,
						tab2,
						tab3
					}	
				};

				tabContainer1 = new StackLayout () {
					Spacing = 0,
					Padding = new Thickness(10,0,10,0), 
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Color.White,
					Children = {
						RekTempatLV
					}	
				};

				tabContainer2 = new StackLayout () {
					Spacing = 0,
					Padding = new Thickness(10,0,10,0),
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Color.White,
					Children = {
						RekListrikLV
					}	
				};
				tabContainer2.IsVisible = false;

				tabContainer3 = new StackLayout () {
					Spacing = 0,
					Padding = new Thickness(10,0,10,0),
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Color.White,
					Children = {
						RekAirLV
					}	
				};
				tabContainer3.IsVisible = false;

				Content = new StackLayout () {
					Spacing = 0, 
					BackgroundColor = Color.White,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					Children = {
						tabHeader,
						tabContainer1,
						tabContainer2,
						tabContainer3
					}	
				};

				tapTab1 = new TapGestureRecognizer();
				tapTab1.Tapped += (s, e) => {
					TabAction (1);
				};
				tab1.GestureRecognizers.Add(tapTab1);

				tapTab2 = new TapGestureRecognizer();
				tapTab2.Tapped += (s, e) => {
					TabAction (2);
				};
				tab2.GestureRecognizers.Add(tapTab2);

				tapTab3 = new TapGestureRecognizer();
				tapTab3.Tapped += (s, e) => {
					TabAction (3);
				};
				tab3.GestureRecognizers.Add(tapTab3);
			}
			catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("Layout", ex);
			}
		}

		public async void TabAction(int selectedTab) {
			try{
				if (selectedTab == 1) {
					txt1.TextColor = Color.White;
					txt2.TextColor = Shared.Settings.Styles.Colors.Background.GrayLight;
					txt3.TextColor = Shared.Settings.Styles.Colors.Background.GrayLight;
					activeBox1.BackgroundColor = Color.White;
					activeBox2.BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue;
					activeBox3.BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue;
					tabContainer1.IsVisible = true;
					tabContainer2.IsVisible = false;
					tabContainer3.IsVisible = false;
				} else if (selectedTab == 2) {
					txt1.TextColor = Shared.Settings.Styles.Colors.Background.GrayLight;
					txt2.TextColor = Color.White;
					txt3.TextColor = Shared.Settings.Styles.Colors.Background.GrayLight;
					activeBox1.BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue;
					activeBox2.BackgroundColor = Color.White;
					activeBox3.BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue;
					tabContainer1.IsVisible = false;
					tabContainer2.IsVisible = true;
					tabContainer3.IsVisible = false;
				} else if (selectedTab == 3) {
					txt1.TextColor = Shared.Settings.Styles.Colors.Background.GrayLight;
					txt2.TextColor = Shared.Settings.Styles.Colors.Background.GrayLight;
					txt3.TextColor = Color.White;
					activeBox1.BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue;
					activeBox2.BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue;
					activeBox3.BackgroundColor = Color.White;
					tabContainer1.IsVisible = false;
					tabContainer2.IsVisible = false;
					tabContainer3.IsVisible = true;
				}
			}
			catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("TabAction", ex);
			}
		}
	}
}

