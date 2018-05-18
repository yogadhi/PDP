using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;
using Shared.Classes.Cache;

namespace Shared.Modules.DataTemplates.RekeningStand
{
	public class StandSearchResult : ViewCell
	{
		StackLayout alamatStandLayout, nmpedLayout, allLayout;
		cxLabel txtAlamatStand, txtNmped;

		public StandSearchResult () : base()
		{
			try
			{
				txtAlamatStand = new cxLabel {
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
					HorizontalOptions = LayoutOptions.Start, 
					VerticalOptions = LayoutOptions.CenterAndExpand, 
					TextColor = Color.Black, 
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
				};
				txtAlamatStand.SetBinding (cxLabel.TextProperty, "alamat");

				alamatStandLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(5, 5, 5, 5),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new cxLabel {
							Text = "Alamat : ",
							FontSize = Shared.Settings.Styles.Sizes.Font.Base,
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.CenterAndExpand, 
							TextColor = Color.Black,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
						},
						txtAlamatStand
					}
				};

				txtNmped = new cxLabel {
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
					HorizontalOptions = LayoutOptions.Start, 
					VerticalOptions = LayoutOptions.CenterAndExpand, 
					TextColor = Color.Black,
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
				};
				txtNmped.SetBinding (cxLabel.TextProperty, "nmped");

				nmpedLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(5, 5, 5, 5),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					Orientation = StackOrientation.Horizontal,
					Children = {
						new cxLabel {
							Text = "Pedagang : ",
							FontSize = Shared.Settings.Styles.Sizes.Font.Base,
							FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
							HorizontalOptions = LayoutOptions.Start, 
							VerticalOptions = LayoutOptions.CenterAndExpand, 
							TextColor = Color.Black,
							WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
						},
						txtNmped
					}
				};
						
				allLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(0,0,0,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Children = {
						alamatStandLayout, 
						nmpedLayout,
						new StackLayout {
							Spacing = 0,
							Padding = new Thickness(5,0,5,0),
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.FillAndExpand,
							Children = {
								Shared.Settings.Styles.Pages.LayoutLine.borderX(Shared.Settings.Styles.Colors.Background.LightBlue, 1),
							}
						},			
					}
				};

				this.View = allLayout;
			}
			catch (Exception ex)
			{
				Shared.Services.Logs.Insights.Send("Layout", ex);
				//throw ex;
			}
		}

		protected override void OnAppearing ()
		{
			try{

			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("OnAppearing", ex);
			}
		}
	}
}


