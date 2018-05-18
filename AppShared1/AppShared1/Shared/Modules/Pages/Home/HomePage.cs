using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Shared.Classes.Components;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using MoreLinq;
using System.IO;
using Shared.Classes;
using System.Globalization;

namespace Shared.Modules.Pages.Home
{
    public class HomePage : ContentPage
    {
		public ListView StandSearchResultLV { get; set; }

		StackLayout cariStandLayout, filterLayout, btnLanjutLayout, selectedItemLayout, allLayout;
		cxEntry txtAlamatStand, txtNmped;
		cxButton btnCariStand;
		cxLabel txtSelectedItem, txtSelectedItemDesc;

		Shared.Classes.Cache.IAccessCredential cachedAccessCredential;
		List<Shared.Services.Table.REKENING_STAND> contSelectedStand = new List<Shared.Services.Table.REKENING_STAND> ();
	
        public HomePage()
        {
			try{
				Title = "REKENING STAND";

				#region filter
				txtAlamatStand = new cxEntry{
					Placeholder = "Cari stand",
					PlaceholderTextColor = Color.White,
					TextColor = Color.White,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					BackgroundColor = Color.Transparent, 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.Center,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight
				};

				txtNmped = new cxEntry{
					Placeholder = "Cari pedagang",
					PlaceholderTextColor = Color.White,
					TextColor = Color.White,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					BackgroundColor = Color.Transparent, 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.Center,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight
				};

				btnCariStand = new cxButton{
					Text = "Cari",
					TextColor = Color.White,
					FontSize = 14,
					HorizontalOptions = LayoutOptions.EndAndExpand, 
					VerticalOptions = LayoutOptions.Center, 
					BackgroundColor = Color.FromHex("7fffffff"),
					BorderColor = Color.White, 
					Alignment = TextAlignment.Center,
				};

				cariStandLayout = new StackLayout{ 
					Spacing = 0, 
					Padding = new Thickness(20,5,20,5),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.Start,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Children = {
						txtAlamatStand, 
						txtNmped
					}
				};
				#endregion

				filterLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(0,0,20,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.Start,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Orientation = StackOrientation.Horizontal,
					Children = {
						cariStandLayout,
						btnCariStand
					}
				};

				#region selected item
				txtSelectedItem = new cxLabel {
					Text = "0",
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					TextColor = Color.Black,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
					FontAttributes = FontAttributes.Bold,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center
				};

				txtSelectedItemDesc = new cxLabel {
					Text = " stand ditandai",
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					TextColor = Color.Black,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center
				};

				selectedItemLayout = new StackLayout { 
					Spacing = 0, 
					Padding = new Thickness(0,5,0,5),
					BackgroundColor = Color.White, 
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.End,
					Orientation = StackOrientation.Horizontal,
					Children = {
						txtSelectedItem,
						txtSelectedItemDesc
					}
				};
				#endregion

				#region btnNextLayout
				btnLanjutLayout = new StackLayout{ 
					Spacing = 0, 
					Padding = new Thickness(0,5,0,5),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.End,
					HeightRequest = 50,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Children = {
						new Label {
							Text = "Lanjut",
							FontSize = 20,
							TextColor = Color.White,
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
							HorizontalOptions = LayoutOptions.Center,
							VerticalOptions = LayoutOptions.Center
						}
					}
				};
				btnLanjutLayout.IsVisible = false;
				#endregion

				StandSearchResultLV = new Shared.Classes.Components.ListViews.SearchResult(typeof(Shared.Modules.DataTemplates.RekeningStand.StandSearchResult));
				StandSearchResultLV.IsPullToRefreshEnabled = false;

				allLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(0,0,0,0), 
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Color.White,
					Children = {
						filterLayout,
						new StackLayout {
							Spacing = 0,
							Padding = new Thickness(20,0,20,0), 
							VerticalOptions = LayoutOptions.FillAndExpand,
							HorizontalOptions = LayoutOptions.FillAndExpand,
							BackgroundColor = Color.White,
							Children = {
								StandSearchResultLV
							}
						},
						selectedItemLayout, 
						btnLanjutLayout
					}
				};

				Content = allLayout;

				var tool = Shared.Classes.Components.Toolbar.Toolbar.Secondary(
					"Reset",
					"",
					new Command(() =>
						{
							txtAlamatStand.Text = "";
							txtNmped.Text = "";
						})
				);

				var tool1 = Shared.Classes.Components.Toolbar.Toolbar.Secondary(
					"Hapus Semua Tanda",
					"",
					new Command(() =>
						{
							contSelectedStand.Clear();
							txtSelectedItem.Text = contSelectedStand.Count.ToString();
							selectedItemLayout.IsVisible = false;
						})
				);

				ToolbarItems.Add(tool);
				ToolbarItems.Add(tool1);

				StandSearchResultLV.ItemSelected += (sender, e) => {
					OnSelection(sender, e);
				};

				btnCariStand.Clicked += async (sender, e) => {
					MessagingCenter.Send<ParamPasser> (new ParamPasser () { DateParameter = DateTime.Now }, "Timer");
					cachedAccessCredential = await Shared.Classes.Cache.cxCache.AccessCredential.Collect();
					GetRekStand(cachedAccessCredential.Kdpasar, txtAlamatStand.Text, txtNmped.Text);
				};


				var btnLanjutTap = new TapGestureRecognizer ();
				btnLanjutTap.NumberOfTapsRequired = 1;
				btnLanjutTap.Tapped += async (s, e) => {
					MessagingCenter.Send<ParamPasser> (new ParamPasser () { DateParameter = DateTime.Now }, "Timer");
					if(contSelectedStand.Count >= 1){
						cachedAccessCredential = await Shared.Classes.Cache.cxCache.AccessCredential.Collect();
						await Navigation.PushAsync(new Shared.Modules.Pages.RekeningStand.StandReview(contSelectedStand, cachedAccessCredential.Kdpasar, "", ""), true);
					}else{
						Shared.Settings.Panels.Alert.Display("Mohon tandai setidaknya satu stand", "Gagal Melanjutkan Proses", "OK");
					}
				};
				btnLanjutLayout.GestureRecognizers.Add (btnLanjutTap);
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("Layout", ex);
				throw ex;
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
				//throw ex;
			}
		}

		async void NavigateTo(Shared.Services.Table.REKENING_STAND stand)
		{
			try
			{
				MessagingCenter.Send<ParamPasser> (new ParamPasser () { DateParameter = DateTime.Now }, "Timer");
				if(contSelectedStand.Exists(x=> x.nostand == stand.nostand)){
					Shared.Settings.Panels.Alert.Display("Tidak dapat menambahkan stand yang sudah ditandai", "Gagal Menambahkan", "OK");
				}else{
					contSelectedStand.Add(new Shared.Services.Table.REKENING_STAND{
						alamat = stand.alamat, 
						nmped = stand.nmped, 
						nostand = stand.nostand, 
						pasar = stand.pasar, 
					});
					txtSelectedItem.Text = contSelectedStand.Count.ToString();

					if(contSelectedStand.Count >= 1){
						btnLanjutLayout.IsVisible = true;
					}
				}
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("NavigateTo", ex);
				//throw ex;
			}
		}

		private async void GetRekStand(string kdpasar, string alamat, string nmped){
			try{
				var task = AppShared1.App.Database.GetRekStand(kdpasar, alamat, nmped);
				await CheckData(task);
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send("GetRekStand", ex);
				//throw ex;
			}	
		}

		private async Task CheckData(List<Shared.Services.Table.REKENING_STAND> result){
			try{
				if(result != null && result.Count > 0){
					cachedAccessCredential = await Shared.Classes.Cache.cxCache.AccessCredential.Collect();
					await Shared.Settings.Panels.LoadingTask.ShowLoading();
					StandSearchResultLV.ItemsSource = null;
					StandSearchResultLV.ItemsSource = result;
				}else{
					Shared.Settings.Panels.Alert.Display(Shared.Settings.Libraries.Strings.NoDataMessage, Shared.Settings.Libraries.Strings.NoDataTitle, "OK");
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send("CheckActiveSession", ex);
			}
		}

        protected override void OnAppearing()
        {
			try
			{
				txtAlamatStand.Text = "";
				txtNmped.Text = "";

				if(contSelectedStand.Count >= 1){
					btnLanjutLayout.IsVisible = true;
				}

				txtSelectedItem.Text = contSelectedStand.Count.ToString();

				MessagingCenter.Subscribe<Shared.Classes.ParamPasser>(this, "CheckRow", (param) =>
					{
						contSelectedStand = param.Stands;

						if(contSelectedStand.Count == 0){
							selectedItemLayout.IsVisible = false;
						}

						txtSelectedItem.Text = contSelectedStand.Count.ToString();
					});	
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("OnAppearing", ex);
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
