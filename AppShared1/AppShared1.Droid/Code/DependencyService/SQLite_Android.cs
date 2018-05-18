using System;
using AppShared1;
using Xamarin.Forms;
using AppShared1.Droid;
using System.IO;
using Acr.UserDialogs;
using SQLite.Net;

[assembly: Dependency (typeof (Shared.Code.DependencyService.SQLite_Android))]

namespace Shared.Code.DependencyService
{
	public class SQLite_Android :  Shared.Services.ISQLite
	{
		public SQLite_Android ()
		{
		}

		#region ISQLite implementation
		public SQLite.Net.SQLiteConnection GetConnection ()
		{
			string dbFileName = "MCTDB.db3";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);

			var path = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbFileName);
			//var path = Path.Combine(documentsPath, dbFileName);
		
			// This is where we copy in the prepopulated database
			Console.WriteLine (path);
			if (!File.Exists (path)) {
				var s = Forms.Context.Assets.Open ("MCTDB.db3");  // RESOURCE NAME ###

				// create a write stream
				FileStream writeStream = new FileStream (path, FileMode.OpenOrCreate, FileAccess.Write);
				// write to the stream
				ReadWriteStream (s, writeStream);

				CopyDatabaseIfNotExists ();

				using (var asset = Forms.Context.Assets.Open ("MCTDB.db3")) {
					using (var dest = File.Create (path)) {
						asset.CopyTo (dest);
					}
				}
			}

			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);

			// Return the database connection 
			return conn;
		}
		#endregion

		/// <summary>
		/// helper method to get the database out of /raw/ and into the user filesystem
		/// </summary>
		void ReadWriteStream(Stream readStream, Stream writeStream)
		{
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

		private static void CopyDatabaseIfNotExists ()
		{
			string dbFileName = "MCTDB.db3";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);

			var path = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbFileName);
			//var path = Path.Combine(documentsPath, dbFileName);

			if (!File.Exists (documentsPath)) {
				using (var br = new BinaryReader (Forms.Context.Assets.Open ("MCTDB.db3"))) {
					using (var bw = new BinaryWriter (new FileStream (documentsPath, FileMode.Create))) {
						byte[] buffer = new byte[2048];
						int length = 0;
						while ((length = br.Read (buffer, 0, buffer.Length)) > 0) {
							bw.Write (buffer, 0, length);
						}
					}
				}
			}
		}
	}
}
