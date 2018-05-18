using System;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite.Net;
using SQLite.Net.Attributes;
using System.Linq;

namespace Shared.Services.Table
{
	public class REKENING_LISTRIK
	{
		SQLiteConnection database;

		public REKENING_LISTRIK ()
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
		public string daya { get; set; }
		public string awal { get; set; }
		public string akhir { get; set; }
		public string pakai { get; set; }
		public string biaya { get; set; }
		public string beban { get; set; }
		public string ttlb { get; set; }
		public string ppj { get; set; }
		public string jasa { get; set; }
		public string btu { get; set; }
		public string materai { get; set; }
		public string ppn { get; set; }
		public string total { get; set; }
		public string tglbayar { get; set; }
		public string uid { get; set; }
		public string uname { get; set; }
		public string jns { get; set; }
	}

	public class REKENINGLISTRIK{
		public string tahun	{ get; set; }
		public string bulan	{ get; set; }
		public string pasar	{ get; set; }
		public string nmpasar { get; set; }
		public string nostand { get; set; }
		public string nmped { get; set; }
		public string nomor	{ get; set; }
		public string alamat { get; set; }
		public string daya { get; set; }
		public string awal { get; set; }
		public string akhir { get; set; }
		public string pakai { get; set; }
		public string biaya { get; set; }
		public string beban { get; set; }
		public string ttlb { get; set; }
		public string ppj { get; set; }
		public string jasa { get; set; }
		public string btu { get; set; }
		public string materai { get; set; }
		public string ppn { get; set; }
		public string total { get; set; }
		public DateTime tglbayar { get; set; }
		public string uid { get; set; }
		public string uname { get; set; }
		public string jns { get; set; }
	}

	public class CONTAINER_REKENING_LISTRIK{
		public string tahun	{ get; set; }
		public string bulan	{ get; set; }
		public string pasar	{ get; set; }
		public string nmpasar { get; set; }
		public string nostand { get; set; }
		public string nmped { get; set; }
		public string nomor	{ get; set; }
		public string alamat { get; set; }
		public string daya { get; set; }
		public string awal { get; set; }
		public string akhir { get; set; }
		public string pakai { get; set; }
		public string biaya { get; set; }
		public string beban { get; set; }
		public string ttlb { get; set; }
		public string ppj { get; set; }
		public string jasa { get; set; }
		public string btu { get; set; }
		public string materai { get; set; }
		public string ppn { get; set; }
		public string total { get; set; }
		public string tglbayar { get; set; }
		public string uid { get; set; }
		public string uname { get; set; }
		public string jns { get; set; }
	}

	public class CONTAINER_REKENING_LISTRIK_CHECKED{
		public string tahun	{ get; set; }
		public string bulan	{ get; set; }
		public string pasar	{ get; set; }
		public string nmpasar { get; set; }
		public string nostand { get; set; }
		public string nmped { get; set; }
		public string nomor	{ get; set; }
		public string alamat { get; set; }
		public string daya { get; set; }
		public string awal { get; set; }
		public string akhir { get; set; }
		public string pakai { get; set; }
		public string biaya { get; set; }
		public string beban { get; set; }
		public string ttlb { get; set; }
		public string ppj { get; set; }
		public string jasa { get; set; }
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

