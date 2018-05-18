using System;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite.Net;
using SQLite.Net.Attributes;
using System.Linq;

namespace Shared.Services.Table
{
	public class REKENING_PASAR
	{
		SQLiteConnection database;

		public REKENING_PASAR ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
		}

		[PrimaryKey]
		public int NOID { get; set; }
		public string kdpasar { get; set; }
		public string nmpasar { get; set; }
	}
}

