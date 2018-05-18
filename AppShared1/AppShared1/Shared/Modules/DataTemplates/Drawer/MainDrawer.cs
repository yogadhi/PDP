using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Shared.Classes.Components;

namespace Shared.Modules.DataTemplates.Drawer
{
    public class MainDrawer : ViewCell
    {
        public MainDrawer() : base()
        {
            try
            {
                var menuImage = new Image
                {
                    HeightRequest = 30,
                    WidthRequest = 30,
                    Aspect = Aspect.AspectFill,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                };
                menuImage.SetBinding(Image.SourceProperty, "ImageSource");

                var imageLayout = new StackLayout
                {
                    Spacing = 0,
                    Padding = new Thickness(15, 0, 15, 0),
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.Start,
                    Children = { menuImage }
                };

                var nameLabel = new cxLabel
                {
                    FontFamily = Shared.Settings.Styles.Fonts.BaseLight,
                    FontSize = Shared.Settings.Styles.Sizes.Font.Base,
                    TextColor = Color.Black,//Shared.Settings.Styles.Colors.Font.Base,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                };
                nameLabel.SetBinding(cxLabel.TextProperty, "Title");

                var cellLayout = new StackLayout
                {
                    Spacing = 0,
                    Padding = new Thickness(10, 10, 10, 10),
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    Children = { imageLayout, nameLabel }
                };

                this.View = cellLayout;
            }
            catch (Exception ex)
            {
                Shared.Services.Logs.Insights.Send("Layout", ex);
            }
        }
    }
}
