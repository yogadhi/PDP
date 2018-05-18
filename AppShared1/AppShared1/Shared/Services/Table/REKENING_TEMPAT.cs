using System;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite.Net;
using SQLite.Net.Attributes;
using System.Linq;

namespace Shared.Services.Table
{
	public class REKENING_TEMPAT
	{
		SQLiteConnection database;

		public REKENING_TEMPAT ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
		}

		[PrimaryKey]
		public int NOID { get; set; }
		public string tahun	{ get; set; }
		public string bulan	{ get; set; }
		public string pasar	{ get; set; }
		public string nmpasar { get; set; }
		public string nostand { get; set; }
		public string nmped { get; set; }
		public string nomor	{ get; set; }
		public string alamat { get; set; }
		public string luas { get; set; }
		public string tarip { get; set; }
		public string biaya { get; set; }
		public string sampah { get; set; }
		public string btu { get; set; }
		public string materai { get; set; }
		public string ppn { get; set; }
		public string total { get; set; }
		public string tglbayar { get; set; }
		public string uid { get; set; }
		public string uname { get; set; }
		public string jns { get; set; }
	}

	public class REKENINGTEMPAT{
		public string tahun	{ get; set; }
		public string bulan	{ get; set; }
		public string pasar	{ get; set; }
		public string nmpasar { get; set; }
		public string nostand { get; set; }
		public string nmped { get; set; }
		public string nomor	{ get; set; }
		public string alamat { get; set; }
		public string luas { get; set; }
		public string tarip { get; set; }
		public string biaya { get; set; }
		public string sampah { get; set; }
		public string btu { get; set; }
		public string materai { get; set; }
		public string ppn { get; set; }
		public string total { get; set; }
		public DateTime tglbayar { get; set; }
		public string uid { get; set; }
		public string uname { get; set; }
		public string jns { get; set; }
	}

	public class CONTAINER_REKENING_TEMPAT{
		public string tahun	{ get; set; }
		public string bulan	{ get; set; }
		public string pasar	{ get; set; }
		public string nmpasar { get; set; }
		public string nostand { get; set; }
		public string nmped { get; set; }
		public string nomor	{ get; set; }
		public string alamat { get; set; }
		public string luas { get; set; }
		public string tarip { get; set; }
		public string biaya { get; set; }
		public string sampah { get; set; }
		public string btu { get; set; }
		public string materai { get; set; }
		public string ppn { get; set; }
		public string total { get; set; }
		public string tglbayar { get; set; }
		public string uid { get; set; }
		public string uname { get; set; }
		public string jns { get; set; }
	}

	public class CONTAINER_REKENING_TEMPAT_CHECKED{
		public string tahun	{ get; set; }
		public string bulan	{ get; set; }
		public string pasar	{ get; set; }
		public string nmpasar { get; set; }
		public string nostand { get; set; }
		public string nmped { get; set; }
		public string nomor	{ get; set; }
		public string alamat { get; set; }
		public string luas { get; set; }
		public string tarip { get; set; }
		public string biaya { get; set; }
		public string sampah { get; set; }
		public string btu { get; set; }
		public string materai { get; set; }
		public string ppn { get; set; }
		public string total { get; set; }
		public string tglbayar { get; set; }
		public string uid { get; set; }
		public string uname { get; set; }
		public string jns { get; set; }
		public string isChecked { get; set; }
	}
}

