using System;
using MyCloudTable;
using Xamarin.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using PerpetualEngine.Storage;

#if __ANDROID__
using MyCloudTable.Droid;
#endif
#if __IOS__
using MyCloudTable.iOS;
#endif

[assembly: Dependency (typeof (Cache_Linked))]

namespace MyCloudTable
{
	public class Cache_Linked : ICache
	{
		public Cache_Linked ()
		{
		}

        #region KeyString
        public class KeyString
        {
            public class AppConfig
            {
                public static string GroupCode = "appconfig";
                public static string IP = "ip";
                public static string searchradius = "searchradius";
                public static string talktousemail = "talktousemail";
            }

            public class Login
            {
                public static string GroupCode = "login";
                public static string isCached = "login_isCached";
                public static string userID = "login_userID";
                public static string username = "login_username";
                public static string password = "login_password";
                public static string firstname = "login_firstname";
                public static string lastname = "login_lastname";
                public static string displayname = "login_displayname";
                public static string telpno = "login_telpno";
                public static string email = "login_email";
                public static string active = "login_active";
            }
            public class Image
            {
                public static string GroupCode = "image";
            }
            public class Location
            {
                public static string GroupCode = "location";
                public static string Lat = "lat";
                public static string Lng = "lng";
            }
            public class GPSEnable
            {
                public static string GroupCode = "Gps";
                public static string enable = "enable";
            }
        }
        #endregion

        #region AppConfig
        public void CacheAppConfig(string IP, double searchradius, string talktousemail)
        {
            ICacheAppConfig data = new ICacheAppConfig();
            data.IP = IP;
            data.SearchRadius = searchradius;

            var storage = SimpleStorage.EditGroup(KeyString.AppConfig.GroupCode);
            storage.Put(KeyString.AppConfig.IP, IP);
            storage.Put<double>(KeyString.AppConfig.searchradius, searchradius);
            storage.Put(KeyString.AppConfig.talktousemail, talktousemail);
        }

        public ICacheAppConfig getCacheAppConfig()
        {
            var storage = SimpleStorage.EditGroup(KeyString.AppConfig.GroupCode);

            ICacheAppConfig data = new ICacheAppConfig();
            data.IP = storage.Get(KeyString.AppConfig.IP);
            data.SearchRadius = storage.Get<double>(KeyString.AppConfig.searchradius);
            data.TalkToUsEmail = storage.Get(KeyString.AppConfig.talktousemail);
            
            return data;
        }

        public void clearCacheAppConfig()
        {
            var storage = SimpleStorage.EditGroup(KeyString.AppConfig.GroupCode);
            storage.Put(KeyString.AppConfig.IP, "");
            storage.Put<double>(KeyString.AppConfig.searchradius, 0);
            storage.Put(KeyString.AppConfig.talktousemail, "");
        }
        #endregion

        #region Login
        public void CacheLogin(long userID, string username, string password, string firstname, string lastname, string displayname, string telpno, string email, int active) {

			int a = (int)userID;

			ICacheLogin data = new ICacheLogin();
			data.userID = userID;
			data.userName = username;
			data.Password = password;
			data.firstName = firstname;
			data.lastName = lastname;
			data.displayName = displayname;
			data.telpNo = telpno;
			data.email = email;
			data.active = active;

			var storage = SimpleStorage.EditGroup(KeyString.Login.GroupCode);
			storage.Put<long>(KeyString.Login.userID, userID);
			storage.Put(KeyString.Login.username, username);
			storage.Put(KeyString.Login.password, password);
			storage.Put(KeyString.Login.firstname, firstname);
			storage.Put(KeyString.Login.lastname, lastname);
			storage.Put(KeyString.Login.displayname, displayname);
			storage.Put(KeyString.Login.telpno, telpno);
			storage.Put(KeyString.Login.email, email);
			storage.Put<int>(KeyString.Login.active, active);

			storage.Put<Boolean>(KeyString.Login.isCached, true);
		}

		public ICacheLogin getCacheLogin ()  {
			var storage = SimpleStorage.EditGroup(KeyString.Login.GroupCode);

			ICacheLogin data = new ICacheLogin();
			data.userID = storage.Get<long>(KeyString.Login.userID);
			data.userName = storage.Get(KeyString.Login.username);
			data.Password = storage.Get(KeyString.Login.password);
			data.firstName = storage.Get(KeyString.Login.firstname);
			data.lastName = storage.Get(KeyString.Login.lastname);
			data.displayName = storage.Get(KeyString.Login.displayname);
			data.telpNo = storage.Get(KeyString.Login.telpno);
			data.email = storage.Get(KeyString.Login.email);
			data.active = storage.Get<int>(KeyString.Login.active);

			return data;
		}

		public Boolean isLoginCached ()  {
			bool cond = false;
			var storage = SimpleStorage.EditGroup(KeyString.Login.GroupCode);
			Boolean data = storage.Get<Boolean>(KeyString.Login.isCached, false);

			if (data == true) {
				int active = storage.Get<int> (KeyString.Login.active);

				if (active != 0) {
					cond = false;
				} else {
					cond = true;
				}
			}
			return cond;
		}

		public void clearCacheLogin() {
			var storage = SimpleStorage.EditGroup(KeyString.Login.GroupCode);
			storage.Put<long>(KeyString.Login.userID, 0);
			storage.Put(KeyString.Login.username, "");
			storage.Put(KeyString.Login.password, "");
			storage.Put(KeyString.Login.firstname, "");
			storage.Put(KeyString.Login.lastname, "");
			storage.Put(KeyString.Login.displayname, "");
			storage.Put(KeyString.Login.telpno, "");
			storage.Put(KeyString.Login.email, "");
			storage.Put<int>(KeyString.Login.active, -1);

			storage.Put<Boolean>(KeyString.Login.isCached, false);
		}
		#endregion Login

		#region Location
		public void CacheLocation(double Lat, double Lng) {
            try
            {
                clearCacheLocation();
                ICacheLocation data = new ICacheLocation();
                data.Lat = Lat;
                data.Lng = Lng;

                var storage = SimpleStorage.EditGroup(KeyString.Location.GroupCode);
                storage.Put<double>(KeyString.Location.Lat, Lat);
                storage.Put<double>(KeyString.Location.Lng, Lng);
            }
            catch(Exception ex){
                string msg = ex.ToString();
            }
		}

		public ICacheLocation getCacheLocation ()  {
			var storage = SimpleStorage.EditGroup(KeyString.Location.GroupCode);

			ICacheLocation data = new ICacheLocation();
			data.Lat = storage.Get<double>(KeyString.Location.Lat);
			data.Lng = storage.Get<double>(KeyString.Location.Lng);

			return data;
		}

		public void clearCacheLocation() {
            try
            {
                var storage = SimpleStorage.EditGroup(KeyString.Location.GroupCode);
                storage.Put<double>(KeyString.Location.Lat, 0);
                storage.Put<double>(KeyString.Location.Lng, 0);
            }catch(Exception ex){
                string msg = ex.ToString();
            }
		}
		#endregion

		#region GPSEnable
		public void CacheGPSEnable(string enable) {
			clearCacheLocation ();
			ICacheGps data = new ICacheGps();
			data.enable = enable;

			var storage = SimpleStorage.EditGroup(KeyString.GPSEnable.GroupCode);
			storage.Put<string>(KeyString.GPSEnable.enable, enable);
		}

		public ICacheGps getCacheGPSEnable ()  {
			var storage = SimpleStorage.EditGroup(KeyString.GPSEnable.GroupCode);

			ICacheGps data = new ICacheGps();
			data.enable = storage.Get<string>(KeyString.GPSEnable.enable.ToString());
			return data;
		}

		public void clearCacheGPSEnable() {
			var storage = SimpleStorage.EditGroup(KeyString.GPSEnable.GroupCode);
			storage.Put<double>(KeyString.GPSEnable.enable, 0);
		}
		#endregion
	}
}

