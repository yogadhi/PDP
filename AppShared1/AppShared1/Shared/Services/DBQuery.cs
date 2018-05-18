using System;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLiteNetExtensions.Exceptions;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;

namespace Shared.Services
{
	public class DBQuery
	{
		static object locker = new object ();

		SQLiteConnection database;

		public DBQuery ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
		}


		#region User
		public List <Shared.Services.Table.User> GetUser (string username, string password)
		{
			try{
				var res = database.Query<Shared.Services.Table.User> ("select * from User where upper(UserLogin) = ? and upper(PassLogin) = ?", username.ToUpper(), password.ToUpper()).ToList();

				if (res != null && res.Count == 1) {
					return res;
				}else{
					return null;	
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("GetUser", ex);
				return null;
			}
		}
		#endregion


		#region pasar
		public List<Shared.Services.Table.REKENING_PASAR> GetRekPasar ()
		{
			try{
				var res = database.Query<Shared.Services.Table.REKENING_PASAR> ("select * from REKENING_PASAR").ToList();

				if (res != null && res.Count > 0) {
					return res;
				} else {
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("GetRekPasar", ex);
				return null;
			}
		}
		#endregion

		#region stand
		public List<Shared.Services.Table.REKENING_STAND> GetRekStand (string kdpasar, string alamat, string nmped)
		{
			try{
				List<Shared.Services.Table.REKENING_STAND> res = new List<Shared.Services.Table.REKENING_STAND>();

				if (kdpasar != null) {
					if (alamat != "") {
						res = database.Query<Shared.Services.Table.REKENING_STAND> ("select * from REKENING_STAND where pasar = ? and alamat like ? order by alamat asc limit 250", kdpasar, "%" + alamat + "%").ToList();
					}

					if (nmped != "") {
						res = database.Query<Shared.Services.Table.REKENING_STAND> ("select * from REKENING_STAND where pasar = ? and nmped like ? order by alamat asc limit 250", kdpasar, "%" + nmped + "%").ToList();
					}

					if (alamat == "" && nmped == "") {
						res = database.Query<Shared.Services.Table.REKENING_STAND> ("select * from REKENING_STAND where pasar = ? order by alamat asc limit 250", kdpasar).ToList();
					}

					if (res != null && res.Count > 0) {
						return res;
					} else {
						return null;
					}
				} else {
					Shared.Settings.Panels.Alert.Display ("Silakan pilih pasar pada halaman login", "Pasar Tidak Ditemukan", "OK");
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("GetRekStand", ex);
				return null;
			}
		}

		public List<Shared.Services.Table.REKENING_STAND> GetAllRekStand (string kdpasar)
		{
			try{
				List<Shared.Services.Table.REKENING_STAND> res = new List<Shared.Services.Table.REKENING_STAND>();

				if (kdpasar != null) {
					res = database.Query<Shared.Services.Table.REKENING_STAND> ("select * from REKENING_STAND where pasar = ?", kdpasar).ToList();

					if (res != null && res.Count > 0) {
						return res;
					} else {
						return null;
					}
				} else {
					Shared.Settings.Panels.Alert.Display ("Silakan pilih pasar pada halaman login", "Pasar Tidak Ditemukan", "OK");
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("GetAllRekStand", ex);
				return null;
			}
		}
		#endregion

		#region RekTempat
		public List<Shared.Services.Table.REKENING_TEMPAT> GetRekTempat (string kdpasar, string nostands)
		{
			try{
				List<Shared.Services.Table.REKENING_TEMPAT> res = new List<Shared.Services.Table.REKENING_TEMPAT>();

				string sql = "select tahun, bulan, rt.pasar as pasar, rp.nmpasar as nmpasar, rt.nostand as nostand, rs.nmped as nmped, nomor, rs.alamat as alamat, luas, tarip, biaya, sampah, btu, materai, ppn, total, " +
					" case when tglbayar = 0 then 'Belum Lunas' else tglbayar end as tglbayar, ifnull(uid, ' - ') as uid, ifnull(uname, ' - ') as uname, jns " +
					" from rekening_tempat rt " +
					" join rekening_pasar rp on rp.kdpasar = rt.pasar AND rs.pasar = rt.pasar and rp.kdpasar = rs.pasar " +
					" join rekening_stand rs on rt.nostand = rs.nostand" +
					" where rt.pasar = " + kdpasar + " and rt.nostand in(" + nostands + ") and tglbayar = 0";
				
				res = database.Query<Shared.Services.Table.REKENING_TEMPAT> (sql).ToList();

				if (res != null && res.Count > 0) {
					return res;
				} else {
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("GetRekTempat", ex);
				return null;
			}
		}

		public List<Shared.Services.Table.REKENING_TEMPAT> UpdateTglBayarRT(string tglBayar, string uid, string uname, string pasar, string no, string alamat, string bulan, string tahun) 
		{
			try{
				List<Shared.Services.Table.REKENING_TEMPAT> res = new List<Shared.Services.Table.REKENING_TEMPAT>();

				res = database.Query<Shared.Services.Table.REKENING_TEMPAT>("UPDATE REKENING_TEMPAT set tglbayar = ?, uid = ?, uname = ? where pasar = ? and nomor = ? and alamat = ? and bulan = ? and tahun = ?", tglBayar, uid, uname, pasar, no, alamat, bulan, tahun);

				if (res != null && res.Count > 0) {
					return res;
				} else {
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send("UpdateTglBayarRT", ex);
				return null;
			}
		}

		public List<Shared.Services.Table.REKENING_TEMPAT> GetRekTempatLunas ()
		{
			try{
				string sql = "select tahun, bulan, rt.pasar as pasar, rp.nmpasar as nmpasar, rt.nostand as nostand, rs.nmped as nmped, nomor, rs.alamat as alamat, luas, tarip, biaya, sampah, btu, materai, ppn, total, " +
					" case when tglbayar = 0 then 'Belum Lunas' else tglbayar end as tglbayar, ifnull(uid, ' - ') as uid, ifnull(uname, ' - ') as uname, jns " +
					" from rekening_tempat rt " +
					" join rekening_pasar rp on rt.pasar = rp.kdpasar" +
					" join rekening_stand rs on rt.nostand = rs.nostand" +
					" where tglbayar != 0 order by date(tglbayar) desc ";

				var res = database.Query<Shared.Services.Table.REKENING_TEMPAT> (sql).ToList();

				if (res != null && res.Count > 0) {
					return res;
				} else {
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("GetRekTempatLunas", ex);
				return null;
			}
		}
		#endregion

		#region RekListrik
		public List<Shared.Services.Table.REKENING_LISTRIK> GetRekListrik (string kdpasar, string nostands)
		{
			try {
				List<Shared.Services.Table.REKENING_LISTRIK> res = new List<Shared.Services.Table.REKENING_LISTRIK>();

				string sql = "select tahun, bulan, rl.pasar as pasar, rp.nmpasar as nmpasar, rl.nostand as nostand, rs.nmped as nmped, nomor, rs.alamat as alamat, daya, awal, akhir, " +
					" pakai, biaya, beban, ttlb, ppj, jasa, materai, btu, ppn, total, case when tglbayar = 0 then 'Belum Lunas' else tglbayar end as tglbayar, ifnull(uid, ' - ') as uid, ifnull(uname, ' - ') as uname, jns " +
					" from REKENING_LISTRIK rl " +
					" join rekening_pasar rp on rp.kdpasar = rl.pasar AND rs.pasar = rl.pasar and rp.kdpasar = rs.pasar " +
					" join rekening_stand rs on rl.nostand = rs.nostand" +
					" where rl.pasar = " + kdpasar + " and rl.nostand in(" + nostands + ") and tglbayar = 0";
				
				res = database.Query<Shared.Services.Table.REKENING_LISTRIK> (sql).ToList();

				if (res != null && res.Count > 0) {
					return res;
				} else {
					return null;
				}
			} catch (Exception ex) {
				Shared.Services.Logs.Insights.Send ("GetRekListrik", ex);
				return null;
			}
		}

		public List<Shared.Services.Table.REKENING_LISTRIK> UpdateTglBayarRL(string tglBayar, string uid, string uname, string pasar, string no, string alamat, string bulan, string tahun) 
		{
			try{
				List<Shared.Services.Table.REKENING_LISTRIK> res = new List<Shared.Services.Table.REKENING_LISTRIK>();

				res = database.Query<Shared.Services.Table.REKENING_LISTRIK>("UPDATE REKENING_LISTRIK set tglbayar = ?, uid = ?, uname = ? where pasar = ? and nomor = ? and alamat = ? and bulan = ? and tahun = ?", tglBayar, uid, uname, pasar, no, alamat, bulan, tahun);

				if (res != null && res.Count > 0) {
					return res;
				} else {
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send("UpdateTglBayarRL", ex);
				return null;
			}
		}

		public List<Shared.Services.Table.REKENING_LISTRIK> GetRekListrikLunas ()
		{
			try{
				string sql = "select tahun, bulan, rl.pasar as pasar, rp.nmpasar as nmpasar, rl.nostand as nostand, rs.nmped as nmped, nomor, rs.alamat as alamat, daya, awal, akhir, " +
					" pakai, biaya, beban, ttlb, ppj, jasa, materai, btu, ppn, total, case when tglbayar = 0 then 'Belum Lunas' else tglbayar end as tglbayar, ifnull(uid, ' - ') as uid, ifnull(uname, ' - ') as uname, jns " +
					" from REKENING_LISTRIK rl " +
					" join rekening_pasar rp on rl.pasar = rp.kdpasar" +
					" join rekening_stand rs on rl.nostand = rs.nostand" +
					" where tglbayar != 0 order by date(tglbayar) desc";
				
				var res = database.Query<Shared.Services.Table.REKENING_LISTRIK> (sql).ToList();

				if (res != null && res.Count > 0) {
					return res;
				} else {
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("GetRekListrikLunas", ex);
				return null;
			}
		}
		#endregion

		#region RekAir
		public List<Shared.Services.Table.REKENING_AIR> GetRekAir (string kdpasar, string nostands)
		{
			try {
				List<Shared.Services.Table.REKENING_AIR> res = new List<Shared.Services.Table.REKENING_AIR>();

				string sql = "select tahun, bulan, ra.pasar as pasar, rp.nmpasar as nmpasar, ra.nostand as nostand, rs.nmped as nmped, nomor, rs.alamat as alamat, awal, akhir, pakai, biaya, " +
					" jasa, sewameter, btu, materai, ppn, total, case when tglbayar = 0 then 'Belum Lunas' else tglbayar end as tglbayar, ifnull(uid, ' - ') as uid, ifnull(uname, ' - ') as uname, jns " +
					" from REKENING_AIR ra " +
					" join rekening_pasar rp on rp.kdpasar = ra.pasar AND rs.pasar = ra.pasar and rp.kdpasar = rs.pasar " +
					" join rekening_stand rs on ra.nostand = rs.nostand " +
					" where ra.pasar = " + kdpasar + " and ra.nostand in(" + nostands + ") and tglbayar = 0";

				res = database.Query<Shared.Services.Table.REKENING_AIR> (sql).ToList();

				if (res != null && res.Count > 0) {
					return res;
				} else {
					return null;
				}
			} catch (Exception ex) {
				Shared.Services.Logs.Insights.Send ("GetRekAir", ex);
				return null;
			}
		}

		public List<Shared.Services.Table.REKENING_AIR> UpdateTglBayarRA(string tglBayar, string uid, string uname, string pasar, string no, string alamat, string bulan, string tahun) 
		{
			try{
				List<Shared.Services.Table.REKENING_AIR> res = new List<Shared.Services.Table.REKENING_AIR>();

				res = database.Query<Shared.Services.Table.REKENING_AIR>("UPDATE REKENING_AIR set tglbayar = ?, uid = ?, uname = ? where pasar = ? and nomor = ? and alamat = ? and bulan = ? and tahun = ?", tglBayar, uid, uname, pasar, no, alamat, bulan, tahun);

				if (res != null && res.Count > 0) {
					return res;
				} else {
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send("UpdateTglBayarRA", ex);
				return null;
			}
		}

		public List<Shared.Services.Table.REKENING_AIR> GetRekAirLunas ()
		{
			try{
				string sql = "select tahun, bulan, ra.pasar as pasar, rp.nmpasar as nmpasar, ra.nostand as nostand, rs.nmped as nmped, nomor, rs.alamat as alamat, awal, akhir, pakai, biaya, " +
					" jasa, sewameter, btu, materai, ppn, total, case when tglbayar = 0 then 'Belum Lunas' else tglbayar end as tglbayar, ifnull(uid, ' - ') as uid, ifnull(uname, ' - ') as uname, jns " +
					" from REKENING_AIR ra " +
					" join rekening_pasar rp on ra.pasar = rp.kdpasar" +
					" join rekening_stand rs on ra.nostand = rs.nostand" +
					" where tglbayar != 0 order by date(tglbayar) desc";
				
				var res = database.Query<Shared.Services.Table.REKENING_AIR> (sql).ToList();

				if (res != null && res.Count > 0) {
					return res;
				} else {
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("GetRekAirLunas", ex);
				return null;
			}
		}
		#endregion 
	}
}

