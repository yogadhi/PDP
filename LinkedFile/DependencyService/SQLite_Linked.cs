using System;
using System.IO;
using MyCloudTable;
using Xamarin.Forms;

#if __ANDROID__
using Android.OS;
using MyCloudTable.Droid;
#endif
#if __IOS__
using MyCloudTable.iOS;
#endif

[assembly: Dependency (typeof (SQLite_Linked))]

namespace MyCloudTable
{
	public class SQLite_Linked : ISQLite
	{
		public SQLite_Linked ()
		{
		}

		#region ISQLite implementation
		public SQLite.Net.SQLiteConnection GetConnection (AppStyle.Enumerables.Version version)
		{
			try{
				var sqliteFilename = "MCTDB.db3";
				string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
#if __ANDROID__			
            	var path = Path.Combine(documentsPath, sqliteFilename);
#endif
#if __IOS__
            	string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            	var path = Path.Combine(libraryPath, sqliteFilename);
#endif

		        #if DEBUG
		        //path = Android.OS.Environment.ExternalStorageDirectory.ToString() + "/" + sqliteFilename;
				#endif

				// This is where we copy in the prepopulated database
				Console.WriteLine (path);
				if(version == AppStyle.Enumerables.Version.Same){
					if (!File.Exists(path))
					{
#if __ANDROID__
						var s = Forms.Context.Resources.OpenRawResource(Resource.Raw.MCTDB);  // RESOURCE NAME ###

						// create a write stream
						FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
						// write to the stream
						ReadWriteStream(s, writeStream);
#endif
#if __IOS__
                		File.Copy(sqliteFilename, path);
#endif
					}
				}
				else if(version == AppStyle.Enumerables.Version.Difference){
#if __ANDROID__
					var s = Forms.Context.Resources.OpenRawResource(Resource.Raw.MCTDB);  // RESOURCE NAME ###

					// create a write stream
					FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
					// write to the stream
					ReadWriteStream(s, writeStream);
#endif
#if __IOS__
					File.Copy(sqliteFilename, path);
#endif
				}

#if __ANDROID__
				var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
#endif
#if __IOS__
            	var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
#endif

	            var conn = new SQLite.Net.SQLiteConnection(plat, path);
				// Return the database connection 
				return conn;
			}
			catch (Exception ex)
			{
				AppStyle.Log.sendException("GetConnection", ex);
				return null;
			}
		}
		#endregion

#if __ANDROID__
		public static void ReadWriteStream(Stream readStream, Stream writeStream)
		{
			try{
				int Length = 256;
				Byte[] buffer = new Byte[Length];
				int bytesRead = readStream.Read(buffer, 0, Length);
				// write the required bytes
				while (bytesRead > 0)
				{
					writeStream.Write(buffer, 0, bytesRead);
					bytesRead = readStream.Read(buffer, 0, Length);
				}
				readStream.Close();
				writeStream.Close();
			}
			catch (Exception ex)
			{
				AppStyle.Log.sendException("ReadWriteStream", ex);
			}
        }
#endif
    }
}

