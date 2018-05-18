using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Shared.Settings.Styles
{
    public class Paddings
    {
        public class Drawer
        {
            public static Thickness Profile = new Thickness(25, Device.OnPlatform(25, 25, 0), 25, 25);
        }
    }
}
