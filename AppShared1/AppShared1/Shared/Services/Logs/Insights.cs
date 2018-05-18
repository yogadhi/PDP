using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Shared.Classes.Dependencies;

namespace Shared.Services.Logs
{
    public class Insights
    {
        public async static void Send(string taskname, Exception exception)
        {
			string error = "";

			error = taskname + " : " + exception.ToString ();

			DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().SaveTextAsyncAppend("PDPS_ERROR_LOG.txt", error);
        }
    }
}
