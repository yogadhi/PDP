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
using Shared.Classes;

namespace Shared.Modules.Pages.Transaksi
{
	public class Pembayaran : ContentPage
	{
		cxLabel txtTransaksi, txtTotal ;
		StackLayout totalLayout, btnBayar;
		Shared.Modules.Pages.Transaksi.PembayaranTab tabView;
		private cxPopupLayout PopUpBase;
		RelativeLayout roundPopup;
		Shared.Modules.PromptProses pp;

		Shared.Classes.Cache.IAccessCredential cached;
		string kdPasar, uid, uname, printerPort;
		List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT> listRTPay = new List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT>();
		List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK> listRLPay = new List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK>();
		List<Shared.Services.Table.CONTAINER_REKENING_AIR> listRAPay = new List<Shared.Services.Table.CONTAINER_REKENING_AIR>();
		List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT> listRTPrint = new List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT>();
		List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK> listRLPrint = new List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK>();
		List<Shared.Services.Table.CONTAINER_REKENING_AIR> listRAPrint = new List<Shared.Services.Table.CONTAINER_REKENING_AIR>();
		Shared.Services.Table.CONTAINER_REKENING_TEMPAT arrRT = new Shared.Services.Table.CONTAINER_REKENING_TEMPAT ();
		Shared.Services.Table.CONTAINER_REKENING_LISTRIK arrRL = new Shared.Services.Table.CONTAINER_REKENING_LISTRIK ();
		Shared.Services.Table.CONTAINER_REKENING_AIR arrRA = new Shared.Services.Table.CONTAINER_REKENING_AIR ();
		List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED> contRekTempat = new List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED>();
		List<Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED> contRekAir = new List<Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED>();
		List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED> contRekListrik = new List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED>();

		public Pembayaran (List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED> rekTempat, List<Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED> rekAir, List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED> rekListrik)
		{
			try{
				Title = "Pembayaran";
				tabView = new PembayaranTab();
				pp = new Shared.Modules.PromptProses();

				contRekTempat = rekTempat;
				contRekAir = rekAir;
				contRekListrik = rekListrik;

				txtTransaksi = new cxLabel {
					Text = "0",
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					TextColor = Color.Black,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.End
				};

				txtTotal = new cxLabel {
					Text = "0",
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					TextColor = Color.Black,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.End
				};

				totalLayout = new StackLayout{ 
					Spacing = 0, 
					Padding = new Thickness(20,5,20,5),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.End,
					Orientation = StackOrientation.Horizontal,
					Children = {
						txtTransaksi,
						new Label {
							Text = " Transaksi = Rp. ",
							FontSize = Shared.Settings.Styles.Sizes.Font.Base,
							TextColor = Color.Black,
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
							HorizontalOptions = LayoutOptions.Start,
							VerticalOptions = LayoutOptions.End
						},
						txtTotal
					}
				};

				btnBayar = new StackLayout{ 
					Spacing = 0, 
					Padding = new Thickness(0,5,0,5),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.End,
					HeightRequest = 70,
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Children = {
						new Label {
							Text = "Bayar",
							FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
							TextColor = Color.White,
							FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
							HorizontalOptions = LayoutOptions.Center,
							VerticalOptions = LayoutOptions.CenterAndExpand
						}
					}
				};

				var MainLayout = new StackLayout{
					BackgroundColor = Shared.Settings.Styles.Colors.Background.Dark,
					Spacing = 0,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					Children = {
						tabView,
						totalLayout,
						btnBayar
					}
				};

				PopUpBase = new cxPopupLayout()
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Content = new StackLayout()
					{
						Children = { 
							MainLayout
						}
					}
				};

				var contentPopup = pp.Print();
				roundPopup = cxRoundLayout.Inflate(contentPopup, 275, 100, 30, 1, Color.White, Color.White);

				Content = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Color.White,
					Children = {
						PopUpBase
					}
				};

				this.tabView.RekTempatLV.ItemSelected += (sender, e) => {
					OnSelectionRekTempat(sender, e);
				};

				this.tabView.RekListrikLV.ItemSelected += (sender, e) => {
					OnSelectionRekListrik(sender, e);
				};

				this.tabView.RekAirLV.ItemSelected += (sender, e) => {
					OnSelectionRekAir(sender, e);
				};

				var btnBayarTap = new TapGestureRecognizer ();
				btnBayarTap.NumberOfTapsRequired = 1;
				btnBayarTap.Tapped += async (s, e) => {
					PopUpBase.ShowPopup(roundPopup);
				};
				btnBayar.GestureRecognizers.Add (btnBayarTap);

				var btnYaTap = new TapGestureRecognizer ();
				btnYaTap.NumberOfTapsRequired = 1;
				btnYaTap.Tapped += async (s, e) => {
					MessagingCenter.Send<ParamPasser> (new ParamPasser () { DateParameter = DateTime.Now }, "Timer");
					PayAndPrintProcess(listRTPay, listRLPay, listRAPay, printerPort);
				};
				pp.layoutYa.GestureRecognizers.Add (btnYaTap);

				var btnTidakTap = new TapGestureRecognizer ();
				btnTidakTap.NumberOfTapsRequired = 1;
				btnTidakTap.Tapped += async (s, e) => {
					MessagingCenter.Send<ParamPasser> (new ParamPasser () { DateParameter = DateTime.Now }, "Timer");
					PopUpBase.DismissPopup();
				};
				pp.layoutTidak.GestureRecognizers.Add (btnTidakTap);
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

		async void PayAndPrintProcess(List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT> listrt, List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK> listrl, List<Shared.Services.Table.CONTAINER_REKENING_AIR> listra, string printerport){
			try{
				PopUpBase.DismissPopup();
				listRTPrint = new List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT>();
				listRLPrint = new List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK>();
				listRAPrint = new List<Shared.Services.Table.CONTAINER_REKENING_AIR>();
				List<string> listNostand = new List<string>();
				string nostands = "";

				listRTPrint = listrt;
				listRLPrint = listrl;
				listRAPrint = listra;
				string dateNow = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

				foreach(var index in listRTPrint){
					AppShared1.App.Database.UpdateTglBayarRT(dateNow, uid, uname, kdPasar, index.nomor, index.alamat, index.bulan, index.tahun);
					index.uid = uid;
					index.uname = uname; 
					index.tglbayar = dateNow;
				}

				foreach(var index in listRLPrint){
					AppShared1.App.Database.UpdateTglBayarRL(dateNow, uid, uname, kdPasar, index.nomor, index.alamat, index.bulan, index.tahun);
					index.uid = uid;
					index.uname = uname; 
					index.tglbayar = dateNow;
				}

				foreach(var index in listRAPrint){
					AppShared1.App.Database.UpdateTglBayarRA(dateNow, uid, uname, kdPasar, index.nomor, index.alamat, index.bulan, index.tahun);
					index.uid = uid;
					index.uname = uname; 
					index.tglbayar = dateNow;
				}

				Shared.Classes.Optimizer.PrintOut.PrintTransaction(listRTPrint, listRLPrint, listRAPrint, printerport);

				foreach(var item in listrt){
					if(!listNostand.Contains(item.nostand)){
						listNostand.Add(item.nostand);
					}
				}
				nostands = string.Join("','", listNostand.ToArray());
				nostands = "'" + nostands + "'";

				this.tabView.RekTempatLV.ItemsSource = Shared.Classes.Optimizer.Converter.CRTtoCRTC(AppShared1.App.Database.GetRekTempat(kdPasar, nostands));
				this.tabView.RekListrikLV.ItemsSource = AppShared1.App.Database.GetRekListrik(kdPasar, nostands);
				this.tabView.RekAirLV.ItemsSource = AppShared1.App.Database.GetRekAir(kdPasar, nostands);

				listRTPrint.Clear();
				listRLPrint.Clear();
				listRAPrint.Clear();
				listRTPay.Clear();
				listRTPay.Clear();
				listRTPay.Clear();
				listNostand.Clear();
				sumTotal();
							
				MessagingCenter.Send<ParamPasser> (new ParamPasser () { boolParameter = true }, "Update");
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("PayAndPrintProcess", ex);
			}
		}

		protected async override void OnAppearing ()
		{
			try{
				cached = await Shared.Classes.Cache.cxCache.AccessCredential.Collect();
				kdPasar = cached.Kdpasar; 
				uid = cached.UserID;
				uname = cached.Username;
				printerPort = cached.PrinterPort;

				this.tabView.RekTempatLV.ItemsSource = contRekTempat;

				this.tabView.tapTab1.Tapped += (s, e) => {
					this.tabView.RekTempatLV.ItemsSource = contRekTempat;
				};

				this.tabView.tapTab2.Tapped += (s, e) => {
					this.tabView.RekListrikLV.ItemsSource = contRekListrik;
				};

				this.tabView.tapTab3.Tapped += (s, e) => {
					this.tabView.RekAirLV.ItemsSource = contRekAir;
				};
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("OnAppearing", ex);
			}
		}

		async void RekTempatNavigateTo (Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED rt)
		{
			if(!listRTPay.Exists(x=> x.nomor == rt.nomor) || !listRTPay.Exists(x=> x.bulan == rt.bulan) || !listRTPay.Exists(x=> x.tahun == rt.tahun)){
				listRTPay.Add (new Shared.Services.Table.CONTAINER_REKENING_TEMPAT { 
					alamat = rt.alamat,
					biaya = rt.biaya,
					btu = rt.btu, 
					bulan = rt.bulan, 
					jns = rt.jns,
					luas = rt.luas, 
					materai = rt.materai,
					nmpasar = rt.nmpasar,
					nmped = rt.nmped, 
					nomor = rt.nomor,
					nostand = rt.nostand,
					pasar = rt.pasar,
					ppn = rt.ppn,
					sampah = rt.sampah,
					tahun = rt.tahun, 
					tarip = rt.tarip,
					tglbayar = rt.tglbayar, 
					total = rt.total, 
					uid = rt.uid, 
					uname = rt.uname
				});
			}else{
				listRTPay.RemoveAll(y=>y.nostand == rt.nostand && y.bulan == rt.bulan);
			}
			sumTotal();
			checkedRow(rt.nomor, rt.bulan, rt.jns);
		}

		async void RekListrikNavigateTo (Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED rl)
		{
			var answer = await Shared.Settings.Panels.ActionSheet.Display("MENU : ", "Tambah", "Kurang", "Lihat Detail");
			if (answer == "Lihat Detail") {
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
			} else if(answer == "Tambah"){
				arrRL.akhir = rl.akhir;
				arrRL.alamat = rl.alamat;
				arrRL.awal = rl.awal;
				arrRL.beban = rl.beban;
				arrRL.biaya = rl.biaya;
				arrRL.btu = rl.btu;
				arrRL.bulan = rl.bulan;
				arrRL.daya = rl.daya;
				arrRL.jasa = rl.jasa;
				arrRL.jns = rl.jns;
				arrRL.materai = rl.materai;
				arrRL.nmpasar = rl.nmpasar;
				arrRL.nmped = rl.nmped;
				arrRL.nomor = rl.nomor;
				arrRL.nostand = rl.nostand;
				arrRL.pakai = rl.pakai;
				arrRL.pasar = rl.pasar;
				arrRL.ppj = rl.ppj;
				arrRL.ppn = rl.ppn;
				arrRL.tahun = rl.tahun;
				arrRL.tglbayar = rl.tglbayar;
				arrRL.total = rl.total;
				arrRL.ttlb = rl.ttlb;
				arrRL.uid = rl.uid;
				arrRL.uname = rl.uname;
				addToProcessRL (arrRL);
			} else if(answer == "Kurang"){
				arrRL.nostand = rl.nostand;
				removeFromProcessRL (arrRL);
			}
		}

		async void RekAirNavigateTo (Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED ra)
		{
			var answer = await Shared.Settings.Panels.ActionSheet.Display("MENU : ", "Tambah", "Kurang", "Lihat Detail");
			if (answer == "Lihat Detail") {
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
			} else if(answer == "Tambah"){
				arrRA.akhir = ra.akhir;
				arrRA.alamat = ra.alamat;
				arrRA.awal = ra.awal;
				arrRA.biaya = ra.biaya;
				arrRA.btu = ra.btu;
				arrRA.bulan = ra.bulan;
				arrRA.jasa = ra.jasa;
				arrRA.jns = ra.jns;
				arrRA.materai = ra.materai;
				arrRA.nmpasar = ra.nmpasar;
				arrRA.nmped = ra.nmped;
				arrRA.nomor = ra.nomor;
				arrRA.nostand = ra.nostand;
				arrRA.pakai = ra.pakai;
				arrRA.pasar = ra.pasar;
				arrRA.ppn = ra.ppn;
				arrRA.sewameter = ra.sewameter;
				arrRA.tahun = ra.tahun;
				arrRA.tglbayar = ra.tglbayar;
				arrRA.total = ra.total;
				arrRA.uid = ra.uid;
				arrRA.uname = ra.uname;
				addToProcessRA (arrRA);
			} else if(answer == "Kurang"){
				arrRA.nostand = ra.nostand;
				removeFromProcessRA (arrRA);
			}
		}

		protected override bool OnBackButtonPressed()
		{
			PromptBack ();
			return true;
		}

		void checkedRow(string nomor, string bulan, string jns){
			try{
				#region selected row
				if(jns == "1"){
					foreach(var item in contRekTempat.Where(w=>w.nomor == nomor && w.bulan == bulan && w.jns == jns)){
						if(item.isChecked == "0"){
							item.isChecked = "1";
						}else{
							item.isChecked = "0";
						}
						this.tabView.RekTempatLV.ItemsSource = null;
						this.tabView.RekTempatLV.ItemsSource = contRekTempat;
					}
				}else if(jns == "2"){
					foreach(var item in contRekListrik.Where(w=>w.nomor == nomor && w.bulan == bulan && w.jns == jns)){
						if(item.isChecked == "0"){
							item.isChecked = "1";
						}else{
							item.isChecked = "0";
						}
						this.tabView.RekListrikLV.ItemsSource = null;
						this.tabView.RekListrikLV.ItemsSource = contRekListrik;
					}
				}else if(jns == "3"){
					foreach(var item in contRekAir.Where(w=>w.nomor == nomor && w.bulan == bulan && w.jns == jns)){
						if(item.isChecked == "0"){
							item.isChecked = "1";
						}else{
							item.isChecked = "0";
						}
						this.tabView.RekAirLV.ItemsSource = null;
						this.tabView.RekAirLV.ItemsSource = contRekAir;
					}
				}
				#endregion
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("checkedRow", ex);
			}
		}

		void addToProcessRT(Shared.Services.Table.CONTAINER_REKENING_TEMPAT rt){
			try{
				if(!listRTPay.Exists(x=> x.nomor == rt.nomor) || !listRTPay.Exists(x=> x.bulan == rt.bulan) || !listRTPay.Exists(x=> x.tahun == rt.tahun)){
					listRTPay.Add (new Shared.Services.Table.CONTAINER_REKENING_TEMPAT { 
						alamat = rt.alamat,
						biaya = rt.biaya,
						btu = rt.btu, 
						bulan = rt.bulan, 
						jns = rt.jns,
						luas = rt.luas, 
						materai = rt.materai,
						nmpasar = rt.nmpasar,
						nmped = rt.nmped, 
						nomor = rt.nomor,
						nostand = rt.nostand,
						pasar = rt.pasar,
						ppn = rt.ppn,
						sampah = rt.sampah,
						tahun = rt.tahun, 
						tarip = rt.tarip,
						tglbayar = rt.tglbayar, 
						total = rt.total, 
						uid = rt.uid, 
						uname = rt.uname
					});
					sumTotal();
					checkedRow(rt.nomor, rt.bulan, rt.jns);
				}else{
					Shared.Settings.Panels.Alert.Display("Tidak dapat menambahkan rekening yang sudah ditandai", "Gagal Menambahkan", "OK");
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("addToProcessRT", ex);
			}
		}

		void addToProcessRL(Shared.Services.Table.CONTAINER_REKENING_LISTRIK rl){
			try{
				if(!listRLPay.Exists(x=> x.nomor == rl.nomor) || !listRLPay.Exists(x=> x.bulan == rl.bulan) || !listRLPay.Exists(x=> x.tahun == rl.tahun)){
					listRLPay.Add (new Shared.Services.Table.CONTAINER_REKENING_LISTRIK { 
						akhir = rl.akhir,
						alamat = rl.alamat,
						awal = rl.awal,
						beban = rl.beban,
						biaya = rl.biaya,
						btu = rl.btu,
						bulan = rl.bulan,
						daya = rl.daya,
						jasa = rl.jasa,
						jns = rl.jns,
						materai = rl.materai,
						nmpasar = rl.nmpasar,
						nmped = rl.nmped,
						nomor = rl.nomor,
						nostand = rl.nostand,
						pakai = rl.pakai,
						pasar = rl.pasar,
						ppj = rl.ppj,
						ppn = rl.ppn,
						tahun = rl.tahun,
						tglbayar = rl.tglbayar,
						total = rl.total,
						ttlb = rl.ttlb,
						uid = rl.uid,
						uname = rl.uname
					});
					sumTotal();
					checkedRow(rl.nomor, rl.bulan, rl.jns);
				}else{
					Shared.Settings.Panels.Alert.Display("Tidak dapat menambahkan rekening yang sudah ditandai", "Gagal Menambahkan", "OK");
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("addToProcessRL", ex);
			}
		}

		void addToProcessRA(Shared.Services.Table.CONTAINER_REKENING_AIR ra){
			try{
				if(!listRAPay.Exists(x=> x.nomor == ra.nomor) || !listRAPay.Exists(x=> x.bulan == ra.bulan) || !listRAPay.Exists(x=> x.tahun == ra.tahun)){
					listRAPay.Add (new Shared.Services.Table.CONTAINER_REKENING_AIR { 
						akhir = ra.akhir,
						alamat = ra.alamat,
						awal = ra.awal,
						biaya = ra.biaya,
						btu = ra.btu,
						bulan = ra.bulan,
						jasa = ra.jasa,
						jns = ra.jns,
						materai = ra.materai,
						nmpasar = ra.nmpasar,
						nmped = ra.nmped,
						nomor = ra.nomor,
						nostand = ra.nostand,
						pakai = ra.pakai,
						pasar = ra.pasar,
						ppn = ra.ppn,
						sewameter = ra.sewameter,
						tahun = ra.tahun,
						tglbayar = ra.tglbayar,
						total = ra.total,
						uid = ra.uid,
						uname = ra.uname
					});
					sumTotal();
					checkedRow(ra.nomor, ra.bulan, ra.jns);
				}else{
					Shared.Settings.Panels.Alert.Display("Tidak dapat menambahkan rekening yang sudah ditandai", "Gagal Menambahkan", "OK");
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("addToProcessRA", ex);
			}
		}

		void removeFromProcessRT(Shared.Services.Table.CONTAINER_REKENING_TEMPAT rt){
			try{
				if(listRTPay.Exists(x=> x.nomor == rt.nomor && x.bulan == rt.bulan)){
					listRTPay.RemoveAll(y=>y.nostand == rt.nostand && y.bulan == rt.bulan);
					sumTotal();
					checkedRow(rt.nomor, rt.bulan, rt.jns);
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("removeFromProcessRT", ex);
			}
		}

		void removeFromProcessRL(Shared.Services.Table.CONTAINER_REKENING_LISTRIK rl){
			try{
				if(listRLPay.Exists(x=> x.nomor == rl.nomor && x.bulan == rl.bulan)){
					listRLPay.RemoveAll(y=>y.nostand == rl.nostand && y.bulan == rl.bulan);
					sumTotal();
					checkedRow(rl.nomor, rl.bulan, rl.jns);
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("removeFromProcessRL", ex);
			}
		}

		void removeFromProcessRA(Shared.Services.Table.CONTAINER_REKENING_AIR ra){
			try{
				if(listRAPay.Exists(x=> x.nomor == ra.nomor && x.bulan == ra.bulan)){
					listRAPay.RemoveAll(y=>y.nostand == ra.nostand && y.bulan == ra.bulan);
					sumTotal();
					checkedRow(ra.nomor, ra.bulan, ra.jns);
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("removeFromProcessRA", ex);
			}
		}

		void sumTotal(){
			try{
				int totTransaksi;
				decimal sumRT, sumRL, sumRA, sumTot;

				sumRT = listRTPay.Select(item => decimal.Parse(item.total)).Sum();
				sumRL = listRLPay.Select(item => decimal.Parse(item.total)).Sum();
				sumRA = listRAPay.Select(item => decimal.Parse(item.total)).Sum();
				totTransaksi = listRTPay.Count + listRLPay.Count + listRAPay.Count;
				sumTot = sumRT + sumRL + sumRA;

				txtTransaksi.Text = totTransaksi.ToString();
				txtTotal.Text = Shared.Classes.Optimizer.Converter.DecimalToRupiah(sumTot.ToString());
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("sumTotal", ex);
			}
		
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


