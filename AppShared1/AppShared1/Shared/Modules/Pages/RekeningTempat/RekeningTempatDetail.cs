using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;

using Shared.Classes.Cache;

namespace Shared.Modules.Pages.RekeningTempat
{
	public class RekeningTempatDetail : ContentPage
	{	
		string contPageTitle, strUid, strUname, strTglBayar, strBulan, strTahun, strNmpasar, strKdpasar, 
		strAlamat, strNmped, strLuas, strTarip, strBiaya, strSampah, strBtu, strMaterai, strPpn, strTotal;
		ScrollView scroll;
		StackLayout headerLayout, lblTglBayar, lblPeriode, lblPasar, lblStand, lblPedagang, lblLuas, lblTarip, lblIuranTempat, 
		lblKebersihan, lblBtu, lblMaterai, lblPPn, lblTotal, allLayout, btnCetak;
		cxLabel txtUid, txtUname, txtTglBayar, txtBulan, txtTahun, txtNmpasar, txtKdpasar, txtAlamat, txtNmped, 
		txtLuas, txtTarip, txtBiaya, txtSampah, txtBtu, txtMaterai, txtPpn, txtTotal;
			
		public RekeningTempatDetail (string pageTitle, string tahun, string bulan, string pasar, string nmpasar, string nmped, string alamat, string luas, string tarip, string biaya, string sampah, string btu, string materai, string ppn, string total, string tglbayar, string uid, string uname)
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
				strLuas = luas;
				strTarip = tarip;
				strBiaya = biaya;
				strSampah = sampah;
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

				txtLuas = new cxLabel {
					Text = strLuas,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Color.Black
				};

				txtTarip = new cxLabel {
					Text = strTarip,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
					HorizontalOptions = LayoutOptions.StartAndExpand,
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

				txtSampah = new cxLabel {
					Text = strSampah,
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

				lblLuas = new StackLayout {
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
									Text = "Luas : ",
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
							Padding = new Thickness (10, 0, 0, 0), 
							HorizontalOptions = LayoutOptions.StartAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							Orientation = StackOrientation.Horizontal,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Children = {
								txtLuas,
								new cxLabel {
									Text = " m2",
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

				lblTarip = new StackLayout {
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
									Text = "Tarip : Rp. ",
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
								txtTarip
							}
						}
					}
				};

				lblIuranTempat = new StackLayout {
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
									Text = "Iuran Tempat : Rp. ",
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

				lblKebersihan = new StackLayout {
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
									Text = "Kebersihan : Rp. ",
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
								txtSampah
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
									Text = "BTU : Rp. ",
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
						lblLuas, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblTarip, 
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblIuranTempat,
						Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
						lblKebersihan, 
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
				if(strLuas == null || strLuas.Length <= 1){
					txtLuas.Text = " 0 ";
				}
				if(strTarip == null || strTarip.Length <= 1){
					txtTarip.Text = " 0 ";
				}
				if(strBiaya == null || strBiaya.Length <= 1){
					txtBiaya.Text = " 0 ";
				}
				if(strSampah == null || strSampah.Length <= 1){
					txtSampah.Text = " 0 ";
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


