using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Android.Locations;

namespace Shared.Classes.Dependencies
{
    public class Interfaces
    {
		public interface IBarcode
		{
			Task<string[]> Scan();
		}

        public interface IMyDevice
        {
            string AppVersionCode();
            string AppVersionName();
            string Platform();
            string PhoneModel();
            string Codename();
            string APIlevel();
            string Version();
			string IMEI();
			string SerialNumber ();
			bool SendEmail (string receiver, string subject, string msg);
        }

        public interface IGadget
        {
            void Close_App();
        }

		public interface ISaveAndLoad
		{
			Task SaveTextAsyncAppend (string filename, string text);
			Task SaveTextAsync (string filename, string text);
			String LoadText (string path, string filename);
		}
    }
}
