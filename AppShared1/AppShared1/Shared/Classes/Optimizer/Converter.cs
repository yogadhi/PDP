using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Globalization;

namespace Shared.Classes.Optimizer
{
	public class Converter
	{
		public static String DateTimeToString(string dates){
			try{
				CultureInfo provider = CultureInfo.InvariantCulture;
				DateTime contDate = DateTime.Now;
				string strResult = "";

				contDate = DateTime.ParseExact(dates, "M/d/yyyy h:m:s", provider);
				strResult = contDate.ToString("dd/MM/yyyy hh:mm:ss");

				return strResult;
			}catch(Exception ex){
				//Shared.Services.Logs.Insights.Send ("DateTimeToString", ex);
				string[] getDate = dates.Split ('/');
				return getDate [0].ToString () + "/" + getDate [1].ToString () + "/" + getDate [2].ToString ();
			}
		}

		public static DateTime StringToDateTime(string dates, Shared.Settings.Libraries.Enumerables.ConvertDateMode mode){
			try{
				CultureInfo provider = CultureInfo.InvariantCulture;
				DateTime contDate = DateTime.Now;
		
				if(mode == Shared.Settings.Libraries.Enumerables.ConvertDateMode.Login){
					contDate = DateTime.ParseExact(dates, "dd/MM/yyyy", provider);
				}else if(mode == Shared.Settings.Libraries.Enumerables.ConvertDateMode.DaftarLunas){
					contDate = DateTime.ParseExact(dates, "dd/MM/yyyy HH:mm:ss", provider);
				}

				return contDate;
			}catch(Exception ex){
				//Shared.Services.Logs.Insights.Send ("StringToDateTime", ex);
				return DateTime.Now;
			}
		}

		public static string DecimalToRupiah(string total){
			try{
				string resTotal;

				if (total.Length == 4) {
					resTotal = total.Substring (0, 1) + "," + total.Substring (1, 3);
				} else if (total.Length == 5) {
					resTotal = total.Substring (0, 2) + "," + total.Substring (2, 3);
				} else if (total.Length == 6) {
					resTotal = total.Substring (0, 3) + "," + total.Substring (3, 3);
				} else if (total.Length == 7) {
					resTotal = total.Substring (0, 1) + "," + total.Substring (1, 3) + "," + total.Substring (4, 3);
				} else if (total.Length == 8) {
					resTotal = total.Substring (0, 2) + "," + total.Substring (2, 3) + "," + total.Substring (5, 3);
				} else {
					resTotal = total;
				}
				return resTotal;
			}catch(Exception ex){
				//Shared.Services.Logs.Insights.Send ("DecimalToRupiah", ex);
				return total;
			}
		}

		public static List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED> CRTtoCRTC(List<Shared.Services.Table.REKENING_TEMPAT> rekTempat){
			try{
				List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED> contRekTempat = new List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED>();

				if(rekTempat != null){
					foreach(var item in rekTempat){
						contRekTempat.Add(new Shared.Services.Table.CONTAINER_REKENING_TEMPAT_CHECKED{
							alamat = item.alamat,
							biaya = item.biaya, 
							btu = item.btu,
							bulan = item.bulan, 
							jns = item.jns,
							luas = item.luas, 
							materai = item.materai,
							nmpasar = item.nmpasar,
							nmped = item.nmped, 
							nomor = item.nomor, 
							nostand = item.nostand,
							pasar = item.pasar,
							ppn = item.ppn,
							sampah = item.sampah,
							tahun = item.tahun,
							tarip = item.tarip,
							tglbayar = item.tglbayar,
							total = item.total,
							uid = item.uid,
							uname = item.uname,
							isChecked = "0"
						});
					}

					return contRekTempat;
				}else{
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("CRTtoCRTC", ex);
				return null;
			}
		}

		public static List<Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED> CRAtoCRAC(List<Shared.Services.Table.REKENING_AIR> rekAir){
			try{
				List<Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED> contRekAir = new List<Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED>();

				if(rekAir != null){
					foreach(var item in rekAir){
						contRekAir.Add(new Shared.Services.Table.CONTAINER_REKENING_AIR_CHECKED{
							akhir = item.akhir,
							alamat = item.alamat,
							awal = item.awal,
							biaya = item.biaya,
							btu = item.btu,
							bulan = item.bulan,
							jasa = item.jasa,
							jns = item.jns,
							materai = item.materai,
							nmpasar = item.nmpasar,
							nmped = item.nmped,
							nomor = item.nomor,
							nostand = item.nostand,
							pakai = item.pakai,
							pasar = item.pasar,
							ppn = item.ppn,
							sewameter = item.sewameter,
							tahun = item.tahun,
							tglbayar = item.tglbayar,
							total = item.total,
							uid = item.uid,
							uname = item.uname,
							isChecked = "0"
						});
					}

					return contRekAir;
				}else{
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("CRAtoCRAC", ex);
				return null;
			}
		}

		public static List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED> CRLtoCRLC(List<Shared.Services.Table.REKENING_LISTRIK> rekListrik){
			try{
				List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED> contRekListrik = new List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED>();

				if(rekListrik != null){
					foreach(var item in rekListrik){
						contRekListrik.Add(new Shared.Services.Table.CONTAINER_REKENING_LISTRIK_CHECKED{
							akhir = item.akhir,
							alamat = item.alamat,
							awal = item.awal,
							beban = item.beban,
							biaya = item.biaya,
							btu = item.btu,
							bulan = item.bulan,
							daya = item.daya,
							jasa = item.jasa,
							jns = item.jns,
							materai = item.materai,
							nmpasar = item.nmpasar,
							nmped = item.nmped,
							nomor = item.nomor,
							nostand = item.nostand,
							pakai = item.pakai,
							pasar = item.pasar,
							ppj = item.ppj,
							ppn = item.ppn,
							tahun = item.tahun,
							tglbayar = item.tglbayar,
							total = item.total,
							ttlb = item.ttlb,
							uid = item.uid,
							uname = item.uname,
							isChecked = "0"
						});
					}

					return contRekListrik;
				}else{
					return null;
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("CRLtoCRLC", ex);
				return null;
			}
		}
	}
}

