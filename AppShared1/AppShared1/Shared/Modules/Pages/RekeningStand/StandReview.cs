using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;
using Shared.Classes.Cache;
using System.Linq;
using System.Linq.Expressions;
using Shared.Classes;

namespace Shared.Modules.Pages.RekeningStand
{
	public class StandReview : ContentPage
	{
		public ListView StandSearchResultLV { get; set; }
		StackLayout AlamatStandLayout, NmpedLayout, allLayout, counterLayout, btnLanjut;
		cxLabel counter;

		//Shared.Services.Table.REKENINGSTAND items = new Shared.Services.Table.REKENINGSTAND();
		List<Shared.Services.Table.REKENING_STAND> listSelectedRekStand = new List<Shared.Services.Table.REKENING_STAND> ();
		List<string> listNoStand = new List<string>();
		string[] arrNoStand = new string[3];
		Shared.Classes.Cache.IAccessCredential cachedAccessCredential;

		public StandReview (List<Shared.Services.Table.REKENING_STAND> stand, string kdpasar, string alamat, string nmped)
		{
			try
			{
				Title = "Review Stand";
				listSelectedRekStand = stand;

				AlamatStandLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(5, 5, 5, 5),
					HorizontalOptions = LayoutOptions.CenterAndExpand, 
					VerticalOptions = LayoutOptions.CenterAndExpand, 
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					Children = {
						new cxLabel {
							Text = "Alamat",
							TextColor = Color.White,
							FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi, 
							FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle, 
							HorizontalTextAlignment = TextAlignment.Center,
							VerticalTextAlignment = TextAlignment.Center
						}
					}
				};

				NmpedLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(5, 5, 5, 5),
					HorizontalOptions = LayoutOptions.CenterAndExpand, 
					VerticalOptions = LayoutOptions.CenterAndExpand, 
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					Children = {
						new cxLabel {
							Text = "Pedagang",
							TextColor = Color.White,
							FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi, 
							FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle, 
							HorizontalTextAlignment = TextAlignment.Center,
							VerticalTextAlignment = TextAlignment.Center
						}
					}
				};

				allLayout = new StackLayout {
					Spacing = 2,
					Padding = new Thickness(5, 5, 5, 5),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Children = {
						AlamatStandLayout, 
						NmpedLayout
					}
				};

				StandSearchResultLV = new Shared.Classes.Components.ListViews.SearchResult(typeof(Shared.Modules.DataTemplates.RekeningStand.StandSearchResult));
				StandSearchResultLV.IsPullToRefreshEnabled = false;

				counter = new cxLabel
				{
					Text = "0",
					TextColor = Color.Black,
					FontSize = 16,
					FontFamily = Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};

				var counterDetail = new cxLabel
				{
					Text = "stand ditandai",
					TextColor = Color.Black,
					FontSize = 16,
					FontFamily = Settings.Styles.Fonts.BaseLight,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};

				counterLayout = new StackLayout
				{
					HeightRequest = 20,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.End,
					BackgroundColor = Color.White,
					Padding = new Thickness(10, 5, 10, 5),
					Orientation = StackOrientation.Horizontal,
					Children = {
						counter, 
						counterDetail
					}
				};

				var Lanjut = new cxLabel
				{
					Text = "Lanjut",
					TextColor = Color.White,
					FontSize = 20,
					FontFamily = Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};

				btnLanjut = new StackLayout
				{
					HeightRequest = 40,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.End,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Padding = new Thickness(0, 5, 0, 5),
					Children = {
						Lanjut
					}
				};

				Content = new StackLayout { 
					Spacing = 0,
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Color.White,
					Children = {
						allLayout,
						StandSearchResultLV,
						counterLayout, 
						btnLanjut
					}
				};

				var tool = Shared.Classes.Components.Toolbar.Toolbar.Secondary(
					"Hapus Semua",
					"",
					new Command(() =>
						{
							listSelectedRekStand.Clear();
							this.StandSearchResultLV.ItemsSource = null;
							this.StandSearchResultLV.ItemsSource = listSelectedRekStand;
							counter.Text = listSelectedRekStand.Count.ToString();
						})
				);

				ToolbarItems.Add(tool);

				StandSearchResultLV.ItemSelected += (sender, e) => {
					OnSelection(sender, e);
				};

				var btnLanjutTap = new TapGestureRecognizer ();
				btnLanjutTap.NumberOfTapsRequired = 1;
				btnLanjutTap.Tapped += async (s, e) => {
					MessagingCenter.Send<ParamPasser> (new ParamPasser () { DateParameter = DateTime.Now }, "Timer");
					GetNoStand(listSelectedRekStand);
				};
				btnLanjut.GestureRecognizers.Add (btnLanjutTap);
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("Layout", ex);
			}
		}

		private async void GetNoStand(List<Shared.Services.Table.REKENING_STAND> rekStand){
			try{
				arrNoStand = listNoStand.ToArray();

				if(arrNoStand != null && arrNoStand.Length > 0){
					string nostands = string.Join("','", arrNoStand);
					nostands = "'" + nostands + "'";

					cachedAccessCredential = await Shared.Classes.Cache.cxCache.AccessCredential.Collect();
					await GetAllRekening(cachedAccessCredential.Kdpasar, nostands);
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("GetNoStand", ex);
			}
		}

		private async Task GetAllRekening(string kdPasar, string nostands){
			try{
				var rekTempat = AppShared1.App.Database.GetRekTempat(kdPasar, nostands);
				var rekListrik = AppShared1.App.Database.GetRekListrik(kdPasar, nostands);
				var rekAir = AppShared1.App.Database.GetRekAir(kdPasar, nostands);
			
				await Shared.Settings.Panels.LoadingTask.ShowLoading();
				await Navigation.PushAsync(new Shared.Modules.Pages.Transaksi.Pembayaran(Shared.Classes.Optimizer.Converter.CRTtoCRTC(rekTempat), Shared.Classes.Optimizer.Converter.CRAtoCRAC(rekAir), Shared.Classes.Optimizer.Converter.CRLtoCRLC(rekListrik)), true);
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("GetAllRekening", ex);
			}
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			try
			{
				if (e.SelectedItem == null) {
					return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
				}
				NavigateTo(e.SelectedItem as Shared.Services.Table.REKENING_STAND);
				((ListView)sender).SelectedItem = null;
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("OnSelection", ex);
			}
		}

		async void NavigateTo(Shared.Services.Table.REKENING_STAND stand)
		{
			try
			{

				MessagingCenter.Send<ParamPasser> (new ParamPasser () { DateParameter = DateTime.Now }, "Timer");
				var answer = await Shared.Settings.Panels.Alert.Display("Hapus stand ini?", "Hapus", "Ya", "Tidak");
				if(answer == true){
					if(removeSelection(stand.nostand) == true){
						listSelectedRekStand.RemoveAll(x=>x.nostand == stand.nostand);
					}
					StandSearchResultLV.ItemsSource = null;
					StandSearchResultLV.ItemsSource = listSelectedRekStand;
					counter.Text = listSelectedRekStand.Count.ToString();
					MessagingCenter.Send<ParamPasser> (new ParamPasser () { Stands = listSelectedRekStand }, "CheckRow");
				}
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("NavigateTo", ex);
			}
		}
			
		bool removeSelection(string nostand){
			try{
				if(listNoStand.Contains(nostand)){
					listNoStand.Remove(nostand);

					if(!listNoStand.Contains(nostand)){
						return true;
					}else{
						return false;
					}
				}else{
					return true;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("removeSelection", ex);
				return false;
			}
		}

		protected override void OnAppearing ()
		{
			try
			{
				base.OnAppearing ();
				StandSearchResultLV.ItemsSource = listSelectedRekStand;
				counter.Text = listSelectedRekStand.Count.ToString();
			
				foreach(var item in listSelectedRekStand){
					listNoStand.Add(item.nostand.ToString());
				}
			}
			catch (Exception ex)
			{
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


