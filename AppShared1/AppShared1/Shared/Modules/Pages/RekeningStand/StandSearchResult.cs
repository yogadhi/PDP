//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xamarin.Forms;
//using System.Diagnostics;
//using System.Threading;
//using System.Threading.Tasks;
//using Shared.Classes.Components;
//using Shared.Classes.Cache;
//using System.Linq;
//using System.Linq.Expressions;
//using MoreLinq;
//using Shared.Classes;
//
//namespace Shared.Modules.Pages.RekeningStand
//{
//	public class StandSearchResult : ContentPage
//	{
//		public ListView StandSearchResultLV { get; set; }
//		cxLabel counter;
//		StackLayout AlamatStandLayout, NmpedLayout, allLayout, counterLayout, btnLanjut;
//		SearchBar searchbar;
//
//		List<Shared.Services.Table.REKENINGSTAND_CHECKED> contStand = new List<Shared.Services.Table.REKENINGSTAND_CHECKED>();
//		List<Shared.Services.Table.REKENINGSTAND_CHECKED> listSelectedRekStand = new List<Shared.Services.Table.REKENINGSTAND_CHECKED> ();
//		string contPageTitle = "";
//
//		public StandSearchResult (string pageTitle, List<Shared.Services.Table.REKENINGSTAND_CHECKED> stand, string kdpasar, string alamat, string nmped)
//		{
//			try
//			{
//				contPageTitle = pageTitle;
//				contStand = stand;
//
//				searchbar = new SearchBar () {
//					Placeholder = "Cari Alamat",
//					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
//					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
//					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
//					PlaceholderColor = Color.White, 
//					TextColor = Color.White,
//					HorizontalOptions = LayoutOptions.FillAndExpand, 
//					VerticalOptions = LayoutOptions.Start, 
//					HeightRequest = 50,
//				};
//
//				AlamatStandLayout = new StackLayout {
//					Spacing = 0,
//					Padding = new Thickness(5, 5, 5, 5),
//					HorizontalOptions = LayoutOptions.CenterAndExpand, 
//					VerticalOptions = LayoutOptions.CenterAndExpand, 
//					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
//					Children = {
//						new cxLabel {
//							Text = "Alamat",
//							TextColor = Color.White,
//							FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi, 
//							FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle, 
//							HorizontalTextAlignment = TextAlignment.Center,
//							VerticalTextAlignment = TextAlignment.Center
//						}
//					}
//				};
//
//				NmpedLayout = new StackLayout {
//					Spacing = 0,
//					Padding = new Thickness(5, 5, 5, 5),
//					HorizontalOptions = LayoutOptions.CenterAndExpand, 
//					VerticalOptions = LayoutOptions.CenterAndExpand, 
//					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
//					Children = {
//						new cxLabel {
//							Text = "Pedagang",
//							TextColor = Color.White,
//							FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi, 
//							FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle, 
//							HorizontalTextAlignment = TextAlignment.Center,
//							VerticalTextAlignment = TextAlignment.Center
//						}
//					}
//				};
//
//				allLayout = new StackLayout {
//					Spacing = 2,
//					Padding = new Thickness(5, 5, 5, 5),
//					HorizontalOptions = LayoutOptions.FillAndExpand, 
//					VerticalOptions = LayoutOptions.FillAndExpand, 
//					Orientation = StackOrientation.Horizontal,
//					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
//					Children = {
//						AlamatStandLayout, 
//						NmpedLayout
//					}
//				};
//
//				StandSearchResultLV = new Shared.Classes.Components.ListViews.SearchResult(typeof(Shared.Modules.DataTemplates.RekeningStand.StandSearchResult));
//				StandSearchResultLV.ItemsSource = contStand;
//				StandSearchResultLV.IsPullToRefreshEnabled = false;
//
//				counter = new cxLabel
//				{
//					Text = "0",
//					TextColor = Color.Black,
//					FontSize = 16,
//					FontFamily = Settings.Styles.Fonts.BaseBoldSemi,
//					HorizontalOptions = LayoutOptions.Start,
//					VerticalOptions = LayoutOptions.CenterAndExpand
//				};
//
//				var counterDetail = new cxLabel
//				{
//					Text = "stand ditandai",
//					TextColor = Color.Black,
//					FontSize = 16,
//					FontFamily = Settings.Styles.Fonts.BaseLight,
//					HorizontalOptions = LayoutOptions.StartAndExpand,
//					VerticalOptions = LayoutOptions.CenterAndExpand
//				};
//
//				counterLayout = new StackLayout
//				{
//					HeightRequest = 20,
//					HorizontalOptions = LayoutOptions.CenterAndExpand,
//					VerticalOptions = LayoutOptions.End,
//					BackgroundColor = Color.White,
//					Padding = new Thickness(10, 5, 10, 5),
//					Orientation = StackOrientation.Horizontal,
//					Children = {
//						counter, 
//						counterDetail
//					}
//				};
//
//				var Lanjut = new cxLabel
//				{
//					Text = "Lanjut",
//					TextColor = Color.White,
//					FontSize = 20,
//					FontFamily = Settings.Styles.Fonts.BaseBoldSemi,
//					HorizontalOptions = LayoutOptions.CenterAndExpand,
//					VerticalOptions = LayoutOptions.CenterAndExpand
//				};
//
//				btnLanjut = new StackLayout
//				{
//					HeightRequest = 40,
//					HorizontalOptions = LayoutOptions.FillAndExpand,
//					VerticalOptions = LayoutOptions.End,
//					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
//					Padding = new Thickness(0, 5, 0, 5),
//					Children = {
//						Lanjut
//					}
//				};
//
//				searchbar.SearchButtonPressed += (sender, e) => {
//					FilterLocations (searchbar.Text);
//				};
//
//				Content = new StackLayout { 
//					Spacing = 0,
//					Padding = new Thickness(0,0,0,0),
//					HorizontalOptions = LayoutOptions.FillAndExpand, 
//					VerticalOptions = LayoutOptions.FillAndExpand,
//					BackgroundColor = Color.White,
//					Children = {
//						searchbar,
//						allLayout,
//						StandSearchResultLV, 
//						counterLayout, 
//						btnLanjut
//					}
//				};
//						
//				var tool = Shared.Classes.Components.Toolbar.Toolbar.Secondary(
//					"Hapus Semua Tanda",
//					"",
//					new Command(() =>
//						{
//							listSelectedRekStand.Clear();
//							foreach(var item in contStand){
//								item.isChecked = "0";
//							}
//							this.StandSearchResultLV.ItemsSource = null;
//							this.StandSearchResultLV.ItemsSource = contStand;
//							counter.Text = listSelectedRekStand.Count.ToString();
//						})
//				);
//
//				var tool1 = Shared.Classes.Components.Toolbar.Toolbar.Secondary(
//					"Reset Cari",
//					"",
//					new Command(() =>
//						{
//							searchbar.Text = "";
//							this.StandSearchResultLV.ItemsSource = null;
//							this.StandSearchResultLV.ItemsSource = contStand;
//							counter.Text = contStand.Count.ToString();
//						})
//				);
//
//				var tool2 = Shared.Classes.Components.Toolbar.Toolbar.Secondary(
//					"Refresh List",
//					"",
//					new Command(() =>
//						{
//							this.StandSearchResultLV.ItemsSource = null;
//							this.StandSearchResultLV.ItemsSource = contStand;
//							counter.Text = contStand.Count.ToString();
//						})
//				);
//			
//				ToolbarItems.Add(tool);
//				ToolbarItems.Add(tool1);
//				ToolbarItems.Add(tool2);
//
//				StandSearchResultLV.ItemSelected += (sender, e) => {
//					OnSelection(sender, e);
//				};
//
//				var btnLanjutTap = new TapGestureRecognizer ();
//				btnLanjutTap.NumberOfTapsRequired = 1;
//				btnLanjutTap.Tapped += async (s, e) => {
//					MessagingCenter.Send<ParamPasser> (new ParamPasser () { DateParameter = DateTime.Now }, "Timer");
//					await GoToReview(kdpasar, alamat, nmped);
//				};
//				btnLanjut.GestureRecognizers.Add (btnLanjutTap);
//			}
//			catch (Exception ex)
//			{
//				Shared.Services.Logs.Insights.Send("Layout", ex);
//				//throw ex;
//			}
//		}
//
//		async Task GoToReview(string kdpasar, string alamat, string nmped){
//			try{
//				await Shared.Settings.Panels.LoadingTask.ShowLoading();
//				await Navigation.PushAsync(new Shared.Modules.Pages.RekeningStand.StandReview(listSelectedRekStand, kdpasar, alamat, nmped), true);
//			}catch(Exception ex){
//				Shared.Services.Logs.Insights.Send ("GoToReview", ex);
//			}
//		}
//				
//		public void FilterLocations (string filter)
//		{
//			this.StandSearchResultLV.BeginRefresh ();
//
//			this.StandSearchResultLV.ItemsSource = contStand
//				.Where (x => x.alamat.ToLower ()
//					.Contains (filter.ToLower ()));
//			
//			this.StandSearchResultLV.EndRefresh ();
//		}
//
//		void OnSelection (object sender, SelectedItemChangedEventArgs e)
//		{
//			try
//			{
//				if (e.SelectedItem == null) {
//					return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
//				}
//
//				NavigateTo(e.SelectedItem as Shared.Services.Table.REKENINGSTAND_CHECKED);
//				((ListView)sender).SelectedItem = null;
//			}
//			catch (Exception ex)
//			{
//				Shared.Services.Logs.Insights.Send("OnSelection", ex);
//				//throw ex;
//			}
//		}
//
//		async void NavigateTo(Shared.Services.Table.REKENINGSTAND_CHECKED stand)
//		{
//			try
//			{
//				if(listSelectedRekStand.Exists(x=> x.nostand == stand.nostand)){
//					Shared.Settings.Panels.Alert.Display("Tidak dapat menambahkan stand yang sudah ditandai", "Gagal Menambahkan", "OK");
//				}else{
//					listSelectedRekStand.Add(new Shared.Services.Table.REKENINGSTAND_CHECKED{
//						alamat = stand.alamat, 
//						nmped = stand.nmped, 
//						nostand = stand.nostand, 
//						pasar = stand.pasar, 
//					});
//					counter.Text = listSelectedRekStand.Count.ToString();
//					checkedRow(stand.nostand);
//				}
//			}
//			catch (Exception ex)
//			{
//				Shared.Services.Logs.Insights.Send("NavigateTo", ex);
//				//throw ex;
//			}
//		}
//
//		void checkedRow(string nostand){
//			try{
//				#region selected row
//				foreach(var item in contStand.Where(w=>w.nostand == nostand)){
//					if(item.isChecked == "0"){
//						item.isChecked = "1";
//					}else{
//						item.isChecked = "0";
//					}
//					StandSearchResultLV.ItemsSource = null;
//					StandSearchResultLV.ItemsSource = contStand;
//				}
//				#endregion
//			}catch(Exception ex){
//				Shared.Services.Logs.Insights.Send ("checkedRow", ex);
//			}
//		}
//
//		protected override void OnAppearing ()
//		{
//			try
//			{
//				base.OnAppearing ();
//				Title = contPageTitle;
//				counter.Text = listSelectedRekStand.Count.ToString();
//
//				MessagingCenter.Subscribe<Shared.Classes.ParamPasser>(this, "CheckRow", (param) =>
//					{
//						if (param.stringParameter != "")
//						{
//							ReloadChecked(param.stringParameter);
//						}
//					});
//			}
//			catch (Exception ex)
//			{
//				Shared.Services.Logs.Insights.Send("OnAppearing", ex);
//				//throw ex;
//			}
//		}
//
//		async void ReloadChecked(string nostand){
//			try{
//				checkedRow(nostand);
//				await Shared.Settings.Panels.LoadingTask.ShowLoading();
//			}catch(Exception ex){
//				Shared.Services.Logs.Insights.Send ("ReloadChecked", ex);
//			}
//		}
//			
//		protected override bool OnBackButtonPressed()
//		{
//			PromptBack ();
//			return true;
//		}
//
//		async void PromptQuit()
//		{
//			try
//			{
//				var answer = await Shared.Settings.Panels.Alert.Display(Shared.Settings.Libraries.Strings.promptQuitApp, "Quit", "Yes", "No");
//				if (answer == true)
//				{
//					if (Device.OS == TargetPlatform.Android)
//					{
//						DependencyService.Get<Shared.Classes.Dependencies.Interfaces.IGadget>().Close_App();
//					}
//				}
//			}
//			catch (Exception ex)
//			{
//				Shared.Services.Logs.Insights.Send("PromptQuit", ex);
//			}
//		}
//
//		async void PromptBack()
//		{
//			try
//			{
//				await Navigation.PopAsync(true);
//			}
//			catch (Exception ex)
//			{
//				Shared.Services.Logs.Insights.Send("PromptBack", ex);
//			}
//		}
//	}
//}
//
//
