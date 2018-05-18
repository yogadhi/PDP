using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;
using Shared.Classes.Cache;
using Shared.Classes;

namespace Shared.Modules
{
	public class PromptProses : StackLayout
	{

		public StackLayout layoutYa { get; set; }
		public StackLayout layoutTidak { get; set; }

		public StackLayout Print ()
		{

			var txtTitle = new cxLabel
			{
				Text = "Pembayaran Rekening",
				FontFamily = Shared.Settings.Styles.Fonts.BaseBoldSemi,
				FontSize = 16,
				TextColor = Color.White,
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				VerticalTextAlignment = TextAlignment.Start,
			};

			var txtTitleLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Start,
				Padding = new Thickness(10, 5, 10, 5),
				BackgroundColor = Shared.Settings.Styles.Colors.Background.LightBlue,
				Children = {
					txtTitle
				}
			};  

			var txtNote = new cxLabel
			{
				Text = "Apakah Anda ingin melakukan pembayaran rekening?",
				FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
				FontSize = 12,
				TextColor = Color.Black,
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				VerticalTextAlignment = TextAlignment.Start,
			};

			var txtNoteLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Start,
				Padding = new Thickness(10, 0, 10, 0),
				BackgroundColor = Color.White,
				Children = {
					txtNote
				}
			}; 

			layoutYa = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(10, 0, 10, 0),
				BackgroundColor = Color.White,
				WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
				Children = {
					new cxLabel
					{
						Text = "Ya",
						FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
						FontSize = 12,
						TextColor = Color.Black,
						BackgroundColor = Color.Transparent,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
					}
				}
			}; 

			layoutTidak = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(10, 0, 10, 0),
				BackgroundColor = Color.White,
				WidthRequest = Shared.Settings.Styles.Pages.MyDevice.ScreendWidth / 2,
				Children = {
					new cxLabel
					{
						Text = "Tidak",
						FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
						FontSize = 12,
						TextColor = Color.Black,
						BackgroundColor = Color.Transparent,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
					}
				}
			}; 
				
			return  new StackLayout { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Black,
				Padding = new Thickness(3,3,3,3),
				Children = {
					new StackLayout {
						HorizontalOptions = LayoutOptions.FillAndExpand, 
						VerticalOptions = LayoutOptions.FillAndExpand,
						Padding = new Thickness(0, 0, 0, 0), 
						BackgroundColor = Color.White,
						Children = {
							txtTitleLayout,
							txtNoteLayout,
							new StackLayout {
								HorizontalOptions = LayoutOptions.FillAndExpand, 
								VerticalOptions = LayoutOptions.Start,
								Padding = new Thickness(10, 15, 10, 15), 
								BackgroundColor = Color.White,
								Orientation = StackOrientation.Horizontal,
								Children = {
									layoutTidak,
									layoutYa, 
								}
							}
						}
					}
				}
			};
		}
	}
}


