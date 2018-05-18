using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;
using Shared.Classes.Cache;

namespace Shared.Modules.Pages.TabbedPages
{
	public class TabPages : TabbedPage
	{
		public TabPages ()
		{
			try{
				Title = "Beranda";
				Icon = "ic_home.png";

				this.Children.Add(new Shared.Modules.Pages.Home.HomePage());
				this.Children.Add(new Shared.Modules.Pages.DaftarLunas.DaftarLunas());
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("Layout", ex);
			}
		}
	}
}


