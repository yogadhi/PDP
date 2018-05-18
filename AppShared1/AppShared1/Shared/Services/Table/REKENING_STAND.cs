using System;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite.Net;
using SQLite.Net.Attributes;
using System.Linq;

namespace Shared.Services.Table
{
	public class REKENING_STAND
	{
		SQLiteConnection database;

		public REKENING_STAND ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
		}

		[PrimaryKey]
		public int NOID { get; set; }
		public string pasar { get; set; }
		public string nostand { get; set; }
		public string alamat { get; set; }
		public string nmped { get; set; }
	}

	public class REKENINGSTAND{
		public string pasar { get; set; }
		public string nostand { get; set; }
		public string alamat { get; set; }
		public string nmped { get; set; }
	}

	public class REKENINGSTAND_CHECKED{
		public string pasar { get; set; }
		public string nostand { get; set; }
		public string alamat { get; set; }
		public string nmped { get; set; }
		public string isChecked { get; set; }
	}
}

