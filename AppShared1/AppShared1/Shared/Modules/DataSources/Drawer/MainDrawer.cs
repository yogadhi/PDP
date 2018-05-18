using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Shared.Modules.DataSources.Drawer
{
    public class MainDrawer : List<Binds.Drawer.MainDrawer>
    {
        public MainDrawer()
        {
            try
            {
                this.Add(new Binds.Drawer.MainDrawer()
                {
						ImageSource = "ic_home",
						Title = "Beranda",
						TargetType = typeof(Pages.TabbedPages.TabPages),
                });

				this.Add(new Binds.Drawer.MainDrawer()
					{
						ImageSource = "ic_profile",
						Title = "Profil Pengguna",
						TargetType = typeof(Pages.Profile.ProfilePage),
					});

				this.Add(new Binds.Drawer.MainDrawer()
					{
						ImageSource = "ic_about",
						Title = "Tentang Aplikasi",
						TargetType = typeof(Pages.AboutPage),
					});
            }
            catch (Exception ex)
            {
                Services.Logs.Insights.Send("MenuListData", ex);
            }
        }
    }
}
