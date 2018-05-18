using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;  
using Xamarin.Forms; 
using Acr.UserDialogs;

namespace Shared.Settings.Panels
{
    public class Alert
    {
        private static ContentPage page = new ContentPage();
        public static void Display(string message, string title, string button)
        {
            page.DisplayAlert(title, message, button);
        }

        public static async Task<Boolean> Display(string message, string title, string button1, string button2)
        {
            return await page.DisplayAlert(title, message, button1, button2);
        }
    }

    public class ActionSheet
    {
        private static ContentPage page = new ContentPage();

        public static async Task<String> Display(string message, string opt1, string opt2)
        {
            return await page.DisplayActionSheet(message, opt1, opt2);
        }

        public static async Task<String> Display(string message, string opt1, string opt2, string opt3)
        {
            return await page.DisplayActionSheet(message, opt1, opt2, opt3);
        }

        public static async Task<String> Display(string message, string opt1, string opt2, string opt3, string opt4)
        {
            return await page.DisplayActionSheet(message, opt1, opt2, opt3, opt4);
        }

        public static async Task<String> Display(string message, string opt1, string opt2, string opt3, string opt4, string opt5)
        {
            return await page.DisplayActionSheet(message, opt1, opt2, opt3, opt4, opt5);
        }

        public static async Task<String> Display(string message, string opt1, string opt2, string opt3, string opt4, string opt5, string opt6)
        {
            return await page.DisplayActionSheet(message, opt1, opt2, opt3, opt4, opt5, opt6);
        }

        public static async Task<String> Display(string message, string opt1, string opt2, string opt3, string opt4, string opt5, string opt6, string opt7)
        {
            return await page.DisplayActionSheet(message, opt1, opt2, opt3, opt4, opt5, opt6, opt7);
        }
    }

    public class Loading
    {
        private static ActivityIndicator loading = new ActivityIndicator();

        public static void Show()
        {
            loading.Color = Shared.Settings.Styles.Colors.Panel.Loading;
            loading.IsRunning = true;
        }

        public static void Hide()
        {
            loading.IsRunning = false;
        }
    }

	public class LoadingPanel {
		public static void Show(Boolean isRunning) {
			if (isRunning == true) {
				UserDialogs.Instance.Loading ("Loading", maskType: MaskType.Clear);
			} else {
				UserDialogs.Instance.Loading ().Hide ();
			}
		}
	};

	public class LoadingTask{
		public async static Task ShowLoading(){
			try{
				Shared.Settings.Panels.LoadingPanel.Show(true);
				await Task.Delay(1500);
				Shared.Settings.Panels.LoadingPanel.Show(false);
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send("ShowLoading", ex);
			}
		}
	}
}
