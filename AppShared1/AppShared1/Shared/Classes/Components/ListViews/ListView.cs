using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Shared.Classes.Components.ListViews
{
    public class Drawer
    {
        public class Main : ListView
        {
            public static List<Shared.Modules.Binds.Drawer.MainDrawer> data = new Shared.Modules.DataSources.Drawer.MainDrawer();

            public Main()
            {
                HasUnevenRows = true;
                ItemsSource = data;
                VerticalOptions = LayoutOptions.FillAndExpand;
                BackgroundColor = Color.Transparent;
                SeparatorVisibility = SeparatorVisibility.None;
                ItemTemplate = new DataTemplate(typeof(Shared.Modules.DataTemplates.Drawer.MainDrawer));

            }
        }
    }

	public class SearchResult : ListView
	{
		public SearchResult(Type cell)
		{
			HasUnevenRows = true;
			HeightRequest = 1000;
			VerticalOptions = LayoutOptions.FillAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			BackgroundColor = Color.White; //Shared.Settings.Styles.Colors.Background.Accent;
			SeparatorVisibility = SeparatorVisibility.None;
			SeparatorColor = Color.Black;//Shared.Settings.Styles.Colors.Background.Accent; //Color.White;
			ItemTemplate = new DataTemplate (cell);
		}
	}

	public class PembayaranResult : ListView
	{
		public PembayaranResult (Type cell)
		{
			HasUnevenRows = true;
			HeightRequest = 1000;
			VerticalOptions = LayoutOptions.FillAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			BackgroundColor =  Color.White;
			SeparatorVisibility = SeparatorVisibility.Default;
			ItemTemplate = new DataTemplate (cell);
		}
	}
}
