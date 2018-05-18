using System;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite.Net;
using SQLite.Net.Attributes;
using System.Linq;

namespace Shared.Services.Table
{
	public class User
	{
		SQLiteConnection database;

		public User ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
		}

		[PrimaryKey]
		public int NOID { get; set; }
		public string IDLogin { get; set; }
		public string UserLogin { get; set; }
		public string PassLogin { get; set; }
		public string Date_Start { get; set; }
		public int Duration { get; set; }
		public string Pasar { get; set; }
		public string Status { get; set; }
		public string tgl_close { get; set; }
	}
}

