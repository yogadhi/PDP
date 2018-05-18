using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;

using Shared.Classes.Cache;

namespace Shared.Modules.Pages.RekeningAir
{
	public class RekeningAirDetail : ContentPage
	{	
		string strUid, strUname, strTglBayar, strBulan, strTahun, strNmpasar, strKdpasar, 
		strAlamat, strNmped, strAwal, strAkhir, strPakai, strBiaya, strJasa, strSewaMeter, strBtu, strMaterai, strPpn, strTotal;
		ScrollView scroll;
		StackLayout headerLayout, lblTglBayar, lblPeriode, lblPasar, lblStand, lblPedagang, lblPemakaian, lblHargaAir, lblPemeliharaan, 
		lblSewaMeter, lblBtu, lblMaterai, lblPPn, lblTotal, allLayout, btnCetak;
		cxLabel txtUid, txtUname, txtTglBayar, txtBulan, txtTahun, txtNmpasar, txtKdpasar, txtAlamat, txtNmped, 
		txtAwal, txtAkhir, txtPakai, txtBiaya, txtJasa, txtSewaMeter, txtBtu, txtMaterai, txtPpn, txtTotal;

		public RekeningAirDetail (string pageTitle, string tahun, string bulan, string pasar, string nmpasar, string nmped, string alamat, string awal, string akhir, string pakai, string biaya, string jasa, string sewameter, string btu, string materai, string ppn, string total, string tglbayar, string uid, string uname)
		{
			try
			{
				Title = pageTitle;

				strUid = uid;
				strUname = uname;
				strTglBayar = tglbayar;
				strBulan = bulan;
				strTahun = tahun;
				strNmpasar = nmpasar;
				strKdpasar = pasar;
				strAlamat = alamat;
				strNmped = nmped;
				strAwal = awal;
				strAkhir = akhir;
				strPakai = pakai;
				strBiaya = biaya;
				strJasa = jasa;
				strSewaMeter = sewameter;
				strBtu = btu;
				strMaterai = materai;
				strPpn = ppn;
				strTotal = total;

				txtUid = new cxLabel {
					Text = strUid,
					FontSize = 24,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.White
				};

				txtUname = new cxLabel {
					Text = strUname,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.White,
				};

				txtTglBayar = new cxLabel {
					Text = strTglBayar,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtBulan = new cxLabel {
					Text = strBulan,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtTahun = new cxLabel {
					Text = strTahun,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtNmpasar = new cxLabel {
					Text = strNmpasar,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtKdpasar = new cxLabel {
					Text = strKdpasar,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtAlamat = new cxLabel {
					Text = strAlamat,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtNmped = new cxLabel {
					Text = strNmped,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtAwal = new cxLabel {
					Text = strAwal,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtAkhir = new cxLabel {
					Text = strAkhir,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtBiaya = new cxLabel {
					Text = strBiaya,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtPakai = new cxLabel {
					Text = strPakai,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtJasa = new cxLabel {
					Text = strJasa,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtSewaMeter = new cxLabel {
					Text = strSewaMeter,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtBtu = new cxLabel {
					Text = strBtu,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtMaterai = new cxLabel {
					Text = strMaterai,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtPpn = new cxLabel {
					Text = strPpn,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtTotal = new cxLabel {
					Text = strTotal,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				btnCetak  = new StackLayout{
					Spacing = 0,
					HeightRequest = 40,
					VerticalOptions = LayoutOptions.End, 
					HorizontalOptions = LayoutOptions.FillAndExpand,  
					BackgroundColor = Shared.Settings.Styles.Colors.Background.Dark, 
					Children = {
						new cxLabel {
							Text = "CETAK", 
							TextColor = Color.White,
							FontSize = 20, 
							HorizontalOptions = LayoutOptions.CenterAndExpand, 
							VerticalOptions = LayoutOptions.CenterAndExpand,
							FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi
						}
					}
				};
				btnCetak.IsVisible = true;

				headerLayout = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness(0,15,0,0), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.StartAndExpand, 
					BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 15),
							HorizontalOptions = LayoutOptions.FillAndExpand, 
							VerticalOptions = LayoutOptions.Start, 
							Children = {
								txtUid, 
								txtUname
							}
						},
					}
				};
				headerLayout.IsVisible = true;

				lblTglBayar = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Tgl Bayar : ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtTglBayar
							}
						}
					}
				};
				lblTglBayar.IsVisible = true;

				lblPeriode = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Periode : ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (20, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							Orientation = StackOrientation.Horizontal,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtBulan,
								new cxLabel {
									Text = " / ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
									HorizontalOptions = LayoutOptions.Start,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}, 
								txtTahun
							}
						}
					}
				};

				lblPasar = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Pasar : ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							Orientation = StackOrientation.Horizontal,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtNmpasar,
							}
						}
					}
				};

				lblStand = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Stand : ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtAlamat
							}
						}
					}
				};

				lblPedagang = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Pedagang : ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtNmped
							}
						}
					}
				};

				lblPemakaian = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Pemakaian : ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (40, 0, 10, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							Orientation = StackOrientation.Horizontal,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtPakai,
								new cxLabel {
									Text = " (",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
									HorizontalOptions = LayoutOptions.Start,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}, 
								txtAkhir,
								new cxLabel {
									Text = " - ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
									HorizontalOptions = LayoutOptions.Start,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								},
								txtAwal,
								new cxLabel {
									Text = ")",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
									HorizontalOptions = LayoutOptions.Start,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								},
							}
						}
					}
				};

				lblHargaAir = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Harga Air : Rp. ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtBiaya
							}
						}
					}
				};

				lblPemeliharaan = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Pemeliharaan : Rp. ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtJasa
							}
						}
					}
				};

				lblSewaMeter = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Sewa Meter : Rp. ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtSewaMeter
							}
						}
					}
				};

				lblBtu = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Btu : Rp. ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtBtu
							}
						}
					}
				};

				lblMaterai = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Materai : Rp. ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtMaterai
							}
						}
					}
				};

				lblPPn = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "PPn : Rp. ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtPpn
							}
						}
					}
				};


				lblTotal = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness (10, 10, 10, 10), 
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								new cxLabel {
									Text = "Total : Rp. ",
									FontSize = Shared.Settings.Styles.Sizes.Font.DrawerTitle,
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									HorizontalOptions = LayoutOptions.FillAndExpand,
									VerticalOptions = LayoutOptions.Start,
									TextColor = Color.Black
								}
							}
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness (0, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtTotal
							}
						}
					}
				};

				allLayout = new StackLayout { 
					Spacing = 1, 
					Padding = new Thickness (10, 0, 10, 0),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					BackgroundColor = Color.White,
					Children = {
						lblTglBayar, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblPeriode, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblPasar, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),	
						lblStand, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblPedagang, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblPemakaian, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblHargaAir, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblPemeliharaan,
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblSewaMeter, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblBtu, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblMaterai, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblPPn, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblTotal
					}
				};

				scroll = new ScrollView {
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					BackgroundColor = Color.White,  
					Padding = new Thickness(0,0,0,0),
					Content = new StackLayout { 
						Spacing = 0, 
						Padding = new Thickness(0,0,0,0),
						HorizontalOptions = LayoutOptions.FillAndExpand, 
						VerticalOptions = LayoutOptions.FillAndExpand, 
						BackgroundColor = Shared.Settings.Styles.Colors.Background.Accent,
						Children = {
							allLayout
						}
					}
				};

				Content = new StackLayout { 
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					BackgroundColor = Color.White,
					Children = {
						headerLayout, 
						scroll,
						//btnCetak
					}
				};

				var tapbtnCetak = new TapGestureRecognizer();
				tapbtnCetak.Tapped += async (s, e) => {

				};

				btnCetak.GestureRecognizers.Add(tapbtnCetak);
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("Layout", ex);
				//throw ex;
			}
		}

		protected override void OnAppearing ()
		{
			try
			{
				base.OnAppearing ();


				if(strUid == null || strUid.Length <= 1){
					txtUid.Text = " - ";
				}
				if(strUname == null || strUname.Length <= 1){
					txtUname.Text = " - ";
				}
				if(strTglBayar == null || strTglBayar.Length <= 1){
					txtTglBayar.Text = " - ";
				}
				if(strBulan.Length <= 1 || strBulan == null){
					txtBulan.Text = " - ";
				}
				if(strTahun.Length <= 1 || strTahun == null){
					txtTahun.Text = " - ";
				}
				if(strNmpasar == null || strNmpasar.Length <= 1){
					txtNmpasar.Text = " - ";
				}
				if(strKdpasar == null || strKdpasar.Length <= 1){
					txtKdpasar.Text = " - ";
				}
				if(strAlamat == null || strAlamat.Length <= 1){
					txtAlamat.Text = " - ";
				}
				if(strNmped == null || strNmped.Length <= 1){
					txtNmped.Text = " - ";
				}
				if(strAwal == null || strAwal.Length <= 1){
					txtAwal.Text = " 0 ";
				}
				if(strAkhir == null || strAkhir.Length <= 1){
					txtAkhir.Text = " 0 ";
				}
				if(strPakai == null || strPakai.Length <= 1){
					txtPakai.Text = " 0 ";
				}
				if(strBiaya == null || strBiaya.Length <= 1){
					txtBiaya.Text = " 0 ";
				}
				if(strJasa == null || strJasa.Length <= 1){
					txtJasa.Text = " 0 ";
				}
				if(strSewaMeter == null || strSewaMeter.Length <= 1){
					txtSewaMeter.Text = " 0 ";
				}
				if(strBtu == null || strBtu.Length <= 1){
					txtBtu.Text = " 0 ";
				}
				if(strMaterai == null || strMaterai.Length <= 1){
					txtMaterai.Text = " 0 ";
				}
				if(strPpn == null || strPpn.Length <= 1){
					txtPpn.Text = " 0 ";
				}
				if(strTotal == null || strTotal.Length <= 1){
					txtTotal.Text = " 0 ";
				}
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("OnAppearing", ex);
				//throw ex;
			}
		}

		protected override bool OnBackButtonPressed()
		{
			PromptBack();
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


