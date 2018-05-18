using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XLabs.Platform.Device;
using XLabs.Ioc;

namespace Shared.Settings.Styles
{
    public class Pages
    {
        public static void Set(BindableObject bindable, FileImageSource icon, string title)
        {
            //NavigationPage.SetTitleIcon(bindable, icon);
            NavigationPage.SetBackButtonTitle(bindable, title);
        }

        public static Style TitleLabelStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
						new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Center },
						new Setter { Property = Label.FontSizeProperty, Value = Shared.Settings.Styles.Sizes.Font.DrawerTitle },
						new Setter { Property = Label.TextColorProperty, Value = Shared.Settings.Styles.Colors.Font.DrawerTitle }
					}
                };
            }
        }

        public static Style TitleLabelFrameStyle
        {
            get
            {
                return new Style(typeof(Frame))
                {
                    Setters = {
						new Setter { Property = Frame.BackgroundColorProperty, Value = Color.Transparent },
						new Setter { Property = Frame.HasShadowProperty, Value = false },
					}
                };
            }
        }

        public static Style SetPage
        {
            get
            {
                return new Style(typeof(Page))
                {
                    Setters = {
						new Setter { Property = Page.BackgroundColorProperty, Value = Shared.Settings.Styles.Colors.Page.Base },
						new Setter { Property = Page.IconProperty, Value = "Icon" },
						new Setter { Property = Page.TitleProperty, Value = "Master" }
					}
                };
            }
        }

        public static Style SetNavPage
        {
            get
            {
                return new Style(typeof(NavigationPage))
                {
                    Setters = {
						new Setter { Property = NavigationPage.BarTextColorProperty, Value = Color.White },
						new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = Shared.Settings.Styles.Colors.Page.Brand },
					}
                };
            }
        }

		public class MyDevice {
			public static IDevice device = Resolver.Resolve<IDevice>();
			public static int ScreendWidth = device.Display.Width;
			public static int ScreendHeight = device.Display.Height;
		}

		public class LayoutLine {
			public static BoxView borderY(Color color, double thickness) {
				return new BoxView () {
					WidthRequest = thickness,
					BackgroundColor = color,
				};
			}
			public static BoxView borderX(Color color, double thickness) {
				return new BoxView () {
					HeightRequest = thickness,
					BackgroundColor = color,
				};
			}
		}
    }
}
