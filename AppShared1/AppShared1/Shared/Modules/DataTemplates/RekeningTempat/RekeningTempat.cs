using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;
using Shared.Classes.Cache;

namespace Shared.Modules.DataTemplates.RekeningTempat
{
	public class RekeningTempat : ViewCell
	{
		cxLabel txtUID, txtUname, txtNmPasar, txtBulan, txtTahun, txtNmped, txtAlamat, txtTotal, txtTglBayar, txtChecked;
		StackLayout userIDLayout, userNameLayout, nmPasarLayout, periodeLayout, nmPedLayout, alamatLayout, totalLayout, tglBayarLayout, allLayout;
		AbsoluteLayout peakLayout;
		Image imgChecked;	

		public RekeningTempat () : base()
		{
			try{
				peakLayout = new AbsoluteLayout
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Color.White, 
					Padding = new Thickness(5, 0, 0, 0)
				};

				imgChecked = new Image()
				{
					Aspect = Aspect.AspectFit,
					HeightRequest = 20,
					WidthRequest = 20,
					BackgroundColor = Color.Transparent
				};
				imgChecked.Source = Shared.Classes.Optimizer.Image.FromFile("ic_isnotchecked");

				txtChecked = new cxLabel {
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
					HorizontalOptions = LayoutOptions.Start, 
					VerticalOptions = LayoutOptions.CenterAndExpand, 
					TextColor = Color.White 
				};
				txtChecked.SetBinding (cxLabel.TextProperty, "isChecked");

				txtUID = new cxLabel{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					TextColor = Color.Black,
				};
				txtUID.SetBinding(cxLabel.TextProperty, "uid");

				userIDLayout = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new cxLabel {
							Text = "User ID : ",
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.FillAndExpand,
							FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							TextColor = Color.Black,
						},
						txtUID, 
					}
				};

				txtUname = new cxLabel{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					TextColor = Color.Black,
				};
				txtUname.SetBinding(cxLabel.TextProperty, "uname");

				userNameLayout = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new cxLabel {
							Text = "User Name : ",
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.FillAndExpand,
							FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							TextColor = Color.Black,
						},
						txtUname, 
					}
				};

				txtNmPasar = new cxLabel{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					TextColor = Color.Black,
				};
				txtNmPasar.SetBinding(cxLabel.TextProperty, "nmpasar");

				nmPasarLayout = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new cxLabel {
							Text = "Pasar : ",
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.FillAndExpand,
							FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							TextColor = Color.Black,
						},
						txtNmPasar, 
					}
				};

				txtBulan = new cxLabel{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.FillAndExpand,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					//WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					TextColor = Color.Black,
				};
				txtBulan.SetBinding(cxLabel.TextProperty, "bulan");

				txtTahun = new cxLabel{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					//WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					TextColor = Color.Black,
				};
				txtTahun.SetBinding(cxLabel.TextProperty, "tahun");

				periodeLayout = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new cxLabel {
							Text = "Periode : ",
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.FillAndExpand,
							FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							TextColor = Color.Black,
						},
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness(15,0,0,0), 
							HorizontalOptions = LayoutOptions.FillAndExpand, 
							VerticalOptions = LayoutOptions.FillAndExpand, 
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							Orientation = StackOrientation.Horizontal,
							Children = {
								txtBulan,
								new cxLabel {
									Text = " / ",
									HorizontalOptions = LayoutOptions.Start,
									VerticalOptions = LayoutOptions.Start,
									FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
									FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
									TextColor = Color.Black,
								},
								txtTahun
							}
						}
					}
				};

				txtNmped = new cxLabel{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.FillAndExpand,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					TextColor = Color.Black,
				};
				txtNmped.SetBinding(cxLabel.TextProperty, "nmped");

				nmPedLayout = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new cxLabel {
							Text = "Pedagang : ",
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.FillAndExpand,
							FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							TextColor = Color.Black,
						},
						txtNmped, 
					}
				};

				txtAlamat = new cxLabel{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.FillAndExpand,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					TextColor = Color.Black,
				};
				txtAlamat.SetBinding(cxLabel.TextProperty, "alamat");

				alamatLayout = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new cxLabel {
							Text = "Alamat : ",
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.FillAndExpand,
							FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							TextColor = Color.Black,
						},
						txtAlamat, 
					}
				};

				txtTotal = new cxLabel{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.FillAndExpand,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					TextColor = Color.Black,
				};
				txtTotal.SetBinding(cxLabel.TextProperty, "total");

				totalLayout = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new cxLabel {
							Text = "Total : Rp. ",
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.FillAndExpand,
							FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							TextColor = Color.Black,
						},
						txtTotal, 
					}
				};

				txtTglBayar = new cxLabel{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.FillAndExpand,
					FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					TextColor = Color.Black,
				};
				txtTglBayar.SetBinding(cxLabel.TextProperty, "tglbayar");

				tglBayarLayout = new StackLayout {
					Spacing = 0, 
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new cxLabel {
							Text = "Tanggal Bayar : ",
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.FillAndExpand,
							FontSize = Shared.Settings.Styles.Sizes.Font.Base, 
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
							TextColor = Color.Black,
						},
						txtTglBayar, 
					}
				};

				var alls = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(20,0,10,0),
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Children = {
						new StackLayout {
							Spacing = 0, 
							Padding = new Thickness(0,10,0,10),
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.FillAndExpand,
							Children = {
								userIDLayout, 
								userNameLayout,
								nmPasarLayout, 
								periodeLayout, 
								nmPedLayout, 
								alamatLayout, 
								totalLayout, 
								tglBayarLayout, 
								txtChecked
							}
						},
					}	
				};

				AbsoluteLayout.SetLayoutFlags(alls, AbsoluteLayoutFlags.All);
				AbsoluteLayout.SetLayoutBounds(alls, new Rectangle(0, 0, 1f, 1f));

				AbsoluteLayout.SetLayoutFlags(imgChecked, AbsoluteLayoutFlags.PositionProportional);
				AbsoluteLayout.SetLayoutBounds(imgChecked,
					new Rectangle(0, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

				peakLayout.Children.Add(alls);
				peakLayout.Children.Add(imgChecked);

				allLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Children = {
						peakLayout
					}	
				};
				this.View = allLayout;
			}
			catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("Layout", ex);	
			}
		}

		protected override void OnAppearing ()
		{
			if (txtChecked.Text == "0") {
				imgChecked.Source = Shared.Classes.Optimizer.Image.FromFile ("ic_isnotchecked");
			} else if (txtChecked.Text == "1") {
				imgChecked.Source = Shared.Classes.Optimizer.Image.FromFile ("ic_ischecked");
			} else {
				imgChecked.Source = Shared.Classes.Optimizer.Image.FromFile ("");
			}
		}
	}
}


