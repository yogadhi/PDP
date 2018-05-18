using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;
using Shared.Classes.Cache;

namespace Shared.Modules.DataTemplates.DaftarLunas
{
	public class DaftarLunas : ViewCell
	{
		StackLayout alamatStandLayout, nmpedLayout, allLayout;
		cxLabel txtAlamatStand, txtNmped;

		public DaftarLunas () : base()
		{
			try
			{
				txtAlamatStand = new cxLabel {
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
					HorizontalOptions = LayoutOptions.Start, 
					VerticalOptions = LayoutOptions.CenterAndExpand, 
					TextColor = Color.Black 
				};
				txtAlamatStand.SetBinding (cxLabel.TextProperty, "alamat");

				alamatStandLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(5, 20, 5, 20),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					Children = {
						txtAlamatStand
					}
				};

				txtNmped = new cxLabel {
					FontSize = Shared.Settings.Styles.Sizes.Font.Base,
					FontFamily = Shared.Settings.Styles.Fonts.BaseLight, 
					HorizontalOptions = LayoutOptions.Start, 
					VerticalOptions = LayoutOptions.CenterAndExpand, 
					TextColor = Color.Black
				};
				txtNmped.SetBinding (cxLabel.TextProperty, "nmped");

				nmpedLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(5, 20, 5, 20),
					HorizontalOptions = LayoutOptions.FillAndExpand, 
					VerticalOptions = LayoutOptions.FillAndExpand, 
					WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
					Children = {
						txtNmped
					}
				};

				allLayout = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(10,0,10,0),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Orientation = StackOrientation.Horizontal,
					Children = {
						alamatStandLayout, 
						nmpedLayout
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
	}
}


