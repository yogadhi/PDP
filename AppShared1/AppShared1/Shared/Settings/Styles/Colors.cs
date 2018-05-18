using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Shared.Settings.Styles
{
    public class Colors
    {
        private static Color Base = Color.FromHex("#FFFFFF");
        private static Color Brand = Color.FromHex("#8BC34A");
        private static Color BrandDark = Color.FromHex("#558B2F");
        private static Color Accent = Color.FromHex("#8BC34A");

        public class Page
        {
            public static Color Base = Colors.Base;
            public static Color Brand = Colors.Brand;
            public static Color Background = Color.FromHex("#FFFFFF");
        }

        public class Background
        {
            public static Color Base = Colors.Base;
            public static Color Brand = Colors.Brand;
            public static Color Accent = Colors.Accent;
            public static Color Dark = Colors.BrandDark;
			public static Color HeaderListView = Color.FromHex("#DCDCD8");
			public static Color GrayLight = Color.FromHex("#EBF5E0");
			public static Color Yellow = Color.FromHex("#FDB70F");
			public static Color DarkGray = Color.FromHex("#707070");
			public static Color LightGreen = Color.FromHex ("#D9FBB1");
			public static Color LightYellow = Color.FromHex ("#F9FCAB");
			public static Color DarkRed = Color.FromHex("#DC4439");
			public static Color LightPink = Color.FromHex("#BFABFF");
			public static Color LightBlue = Color.FromHex("#03A9F5");

            public class transparent
            {

            }
        }

        public class Panel
        {
            public static Color Loading = Color.FromHex("#FFFFFF");
        }

        public class Font
        {
            public static Color Base = Color.FromHex("#000000");
            public static Color Brand = Color.FromHex("#FFFFFF");
            public static Color Dark = Color.FromHex("#747474");
            public static Color DrawerTitle = Color.FromHex("#D5D5D5");
        }
    }
}
