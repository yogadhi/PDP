using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;
using Shared.Classes.Cache;
using MoreLinq;
using System.Linq;
using System.Linq.Expressions;

namespace Shared.Modules.Pages.DaftarLunas
{
	public class DaftarLunas : ContentPage
	{
		Shared.Modules.Pages.DaftarLunas.DaftarLunasTab tabView;
		List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED> RTList = new List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED>();
		List<Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED> RAList = new List<Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED>();
		List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED> RLList = new List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED>();
		cxLabel lblTot, lblTotAll;

		public DaftarLunas ()
		{
			try{
				Title = "Daftar Lunas";

				tabView = new DaftarLunasTab();

				lblTot = new cxLabel{
					Text = "",
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.White, 
				};

				lblTotAll = new cxLabel{
					Text = "",
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.White, 
				};

				Content = new StackLayout { 
					Padding = new Thickness(0,0,0,0), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Color.White,
					Children = {
						tabView, 
						new StackLayout{
							Spacing = 0,
							Padding = new Thickness(10,5,10,5), 
							HorizontalOptions = LayoutOptions.FillAndExpand, 
							VerticalOptions = LayoutOptions.End,
							HeightRequest = 40,
							BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
							Children = {
								lblTot, 
								lblTotAll,
							}
						}
					}
				};

				var tool = Shared.Classes.Components.Toolbar.Toolbar.Secondary(
					"Refresh",
					"",
					new Command(() =>
						{
							LoadData();
						})
				);
				ToolbarItems.Add(tool);

				this.tabView.RekTempatLV.ItemSelected += (sender, e) => {
					OnSelectionRekTempat(sender, e);
				};

				this.tabView.RekAirLV.ItemSelected += (sender, e) => {
					OnSelectionRekAir(sender, e);
				};

				this.tabView.RekListrikLV.ItemSelected += (sender, e) => {
					OnSelectionRekListrik(sender, e);
				};
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("Layout", ex);
			}
		}

		void OnSelectionRekTempat (object sender, SelectedItemChangedEventArgs e)
		{
			try
			{
				if (e.SelectedItem == null) {
					return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
				}

				RekTempatNavigateTo(e.SelectedItem as Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED);
				((ListView)sender).SelectedItem = null;
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("OnSelectionRekTempat", ex);
				//throw ex;
			}
		}

		void OnSelectionRekAir (object sender, SelectedItemChangedEventArgs e)
		{
			try
			{
				if (e.SelectedItem == null) {
					return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
				}

				RekAirNavigateTo(e.SelectedItem as Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED);
				((ListView)sender).SelectedItem = null;
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("OnSelectionRekAir", ex);
				//throw ex;
			}
		}

		void OnSelectionRekListrik (object sender, SelectedItemChangedEventArgs e)
		{
			try
			{
				if (e.SelectedItem == null) {
					return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
				}

				RekListrikNavigateTo(e.SelectedItem as Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED);
				((ListView)sender).SelectedItem = null;
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("OnSelectionRekAir", ex);
				//throw ex;
			}
		}

		async void RekTempatNavigateTo (Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED rt)
		{
			await Navigation.PushAsync (new Shared.Modules.Pages.RekeningTempat.RekeningTempatDetail(
				rt.alamat, 
				rt.tahun,
				rt.bulan,
				rt.pasar,
				rt.nmpasar,
				rt.nmped,
				rt.alamat,
				rt.luas, 
				rt.tarip,
				rt.biaya, 
				rt.sampah,
				rt.btu, 
				rt.materai, 
				rt.ppn, 
				rt.total,
				rt.tglbayar,
				rt.uid, 
				rt.uname
			), true);
		}

		async void RekAirNavigateTo (Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED ra)
		{
			await Navigation.PushAsync (new Shared.Modules.Pages.RekeningAir.RekeningAirDetail(
				ra.alamat, 
				ra.tahun,
				ra.bulan,
				ra.pasar,
				ra.nmpasar,
				ra.nmped,
				ra.alamat, 
				ra.awal, 
				ra.akhir, 
				ra.pakai, 
				ra.biaya, 
				ra.jasa, 
				ra.sewameter, 
				ra.btu, 
				ra.materai, 
				ra.ppn, 
				ra.total, 
				ra.tglbayar, 
				ra.uid, 
				ra.uname
			), true);
		}

		async void RekListrikNavigateTo (Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED rl)
		{
			await Navigation.PushAsync (new Shared.Modules.Pages.RekeningListrik.RekeningListrikDetail (
				rl.alamat, 
				rl.tahun,
				rl.bulan,
				rl.pasar,
				rl.nmpasar,
				rl.nmped,
				rl.alamat, 
				rl.daya, 
				rl.awal,
				rl.akhir,
				rl.pakai,
				rl.biaya,
				rl.beban,
				rl.ttlb,
				rl.ppj,
				rl.jasa,
				rl.btu,
				rl.materai,
				rl.ppn,
				rl.total,
				rl.tglbayar,
				rl.uid,
				rl.uname
			), true);
		}

		protected async override void OnAppearing ()
		{
			try{
				await LoadData();

				MessagingCenter.Subscribe<Shared.Classes.ParamPasser>(this, "Update", (param) =>
					{
						if (param.boolParameter == true)
						{
							LoadData();
						}
					});
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("OnAppearing", ex);
			}
		}

		private async Task LoadData(){
			try{
				RTList = Shared.Classes.Optimizer.Converter.CRTtoCRTC(AppShared1.App.Database.GetRekTempatLunas());
				RLList = Shared.Classes.Optimizer.Converter.CRLtoCRLC(AppShared1.App.Database.GetRekListrikLunas());
				RAList = Shared.Classes.Optimizer.Converter.CRAtoCRAC(AppShared1.App.Database.GetRekAirLunas());

				var totTransaksiRT = RTList.Count;
				var totRT = RTList.Select(x=> decimal.Parse(x.total)).Sum();
				var totTransaksiRL = RLList.Count;
				var totRL = RLList.Select(x=> decimal.Parse(x.total)).Sum();
				var totTransaksiRA = RAList.Count;
				var totRA = RAList.Select(x=> decimal.Parse(x.total)).Sum();

				var totTransaksiAll = totTransaksiRT + totTransaksiRL + totTransaksiRA;
				var totTotal = totRT + totRL + totRA;
				lblTotAll.Text = totTransaksiAll.ToString() + " Transaksi = Rp. " + Shared.Classes.Optimizer.Converter.DecimalToRupiah(totTotal.ToString());

				this.tabView.RekTempatLV.ItemsSource = RTList;
				lblTot.Text = totTransaksiRT.ToString() + " Rekening Tempat = Rp. " + Shared.Classes.Optimizer.Converter.DecimalToRupiah(totRT.ToString());

				this.tabView.tapTab1.Tapped += (s, e) => {
					this.tabView.RekTempatLV.ItemsSource = RTList;
					lblTot.Text = totTransaksiRT.ToString() + " Rekening Tempat = Rp. " + Shared.Classes.Optimizer.Converter.DecimalToRupiah(totRT.ToString());
				};

				this.tabView.tapTab2.Tapped += (s, e) => {
					this.tabView.RekListrikLV.ItemsSource = RLList;
					lblTot.Text = totTransaksiRL.ToString() + " Rekening Listrik = Rp. " + Shared.Classes.Optimizer.Converter.DecimalToRupiah(totRL.ToString());
				};

				this.tabView.tapTab3.Tapped += (s, e) => {
					this.tabView.RekAirLV.ItemsSource = RAList;
					lblTot.Text = totTransaksiRA.ToString() + " Rekening Air = Rp. " + Shared.Classes.Optimizer.Converter.DecimalToRupiah(totRA.ToString());
				};
				await Shared.Settings.Panels.LoadingTask.ShowLoading();
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("LoadData", ex);
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


