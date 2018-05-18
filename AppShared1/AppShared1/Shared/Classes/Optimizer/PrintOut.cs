using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;
using Shared.Classes.Cache;
using MoreLinq;
using System.Linq;
using System.Linq.Expressions;
using Shared.Classes.Optimizer;
using System.Drawing;
using Android.Graphics;
using System.IO;

namespace Shared.Classes.Optimizer
{
	public class PrintOut
	{
		public static void PrintTransaction(List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT> listRT, List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK> listRL, List<Shared.Services.Table.CONTAINER_REKENING_AIR> listRA, string printerport){
			try{
				List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT> contListRT = new List<Shared.Services.Table.CONTAINER_REKENING_TEMPAT>();
				List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK> contListRL = new List<Shared.Services.Table.CONTAINER_REKENING_LISTRIK>(); 
				List<Shared.Services.Table.CONTAINER_REKENING_AIR> contListRA = new List<Shared.Services.Table.CONTAINER_REKENING_AIR>();

				List<string> strList = new List<string>();
				string textPrint = "";

				contListRT = listRT;
				contListRL = listRL;
				contListRA = listRA;

				if(contListRT != null && contListRT.Count > 0){
					foreach(var index in contListRT){
						textPrint = 
							"----------------------------\n" + 
							"PD PASAR SURYA\n" + 
							"----------------------------\n" + 
							index.nmpasar + "\n" +
							"----------------------------\n" +
							"REKENING TEMPAT \n" + 
							index.pasar + index.jns + index.tglbayar.Substring(6, 4) + index.tglbayar.Substring(3, 2) + 
							index.tglbayar.Substring(6, 4) + index.tglbayar.Substring(0, 2) + index.nomor + "4" + index.uid + index.tglbayar.Substring(11, 2) + 
							index.tglbayar.Substring(14, 2) + index.tglbayar.Substring(17, 2) + "\n" + 
							"User : " + index.uname + " (" + index.uid + ")\n" + 
							"Tgl Bayar : " + index.tglbayar + "\n" + 
							"Periode : " + index.bulan + "/" + index.tahun + "\n" + 
							"Stand : " + index.alamat + "\n" + 
							"Pedagang : " + index.nmped + "\n" + 
							"Luas : " + index.luas + "\n" + 
							"Tarip : Rp. " + index.tarip + "\n" + 
							"Iuran Tempat : Rp. " + index.biaya + "\n" + 
							"Kebersihan : Rp. " + index.sampah + "\n" + 
							"BTU : Rp. " + index.btu + "\n" + 
							"Materai : Rp. " + index.materai + "\n" + 
							"PPn : Rp. " + index.ppn + "\n" + 
							"Total : Rp. " + index.total + "\n" + 
							"================================\n";
						strList.Add(textPrint);
					}
				}

				if(contListRL != null && contListRL.Count > 0){
					foreach(var index in contListRL){
						textPrint = 
							"----------------------------\n" + 
							"PD PASAR SURYA\n" + 
							"----------------------------\n" + 
							index.nmpasar + "\n" +
							"----------------------------\n" +
							"REKENING LISTRIK \n" + 
							index.pasar + index.jns + index.tglbayar.Substring(6, 4) + index.tglbayar.Substring(3, 2) + 
							index.tglbayar.Substring(6, 4) + index.tglbayar.Substring(0, 2) + index.nomor + "4" + index.uid + index.tglbayar.Substring(11, 2) + 
							index.tglbayar.Substring(14, 2) + index.tglbayar.Substring(17, 2) + "\n" + 
							"User : " + index.uname + " (" + index.uid + ")\n" + 
							"Tgl Bayar : " + index.tglbayar + "\n" + 
							"Periode : " + index.bulan + "/" + index.tahun + "\n" + 
							"Stand : " + index.alamat + "\n" + 
							"Pedagang : " + index.nmped + "\n" + 
							"Daya : " + index.daya + "watt \n" + 
							"Pemakaian : " + index.pakai + " (" + index.akhir + " - " + index.awal + ") \n" + 
							"Biaya : Rp. " + index.biaya + "\n" + 
							"Beban : Rp. " + index.beban + "\n" + 
							"TTLB : Rp. " + index.ttlb + "\n" + 
							"PPJ : Rp. " + index.ppj + "\n" + 
							"Pemeliharaan : Rp. " + index.jasa + "\n" + 
							"BTU : Rp. " + index.btu + "\n" + 
							"Materai : Rp. " + index.materai + "\n" +
							"Ppn : Rp. " + index.ppn + "\n" +
							"Total : Rp. " + index.total + "\n" + 
							"================================\n";
						strList.Add(textPrint);
					}
				}

				if(contListRA != null && contListRA.Count > 0){
					foreach(var index in contListRA){
						textPrint = 
							"----------------------------\n" + 
							"PD PASAR SURYA\n" + 
							"----------------------------\n" + 
							index.nmpasar + "\n" +
							"----------------------------\n" +
							"REKENING AIR \n" + 
							index.pasar + index.jns + index.tglbayar.Substring(6, 4) + index.tglbayar.Substring(3, 2) + 
							index.tglbayar.Substring(6, 4) + index.tglbayar.Substring(0, 2) + index.nomor + "4" + index.uid + index.tglbayar.Substring(11, 2) + 
							index.tglbayar.Substring(14, 2) + index.tglbayar.Substring(17, 2) + "\n" + 
							"User : " + index.uname + " (" + index.uid + ")\n" + 
							"Tgl Bayar : " + index.tglbayar + "\n" + 
							"Periode : " + index.bulan + "/" + index.tahun + "\n" + 
							"Stand : " + index.alamat + "\n" + 
							"Pedagang : " + index.nmped + "\n" + 
							"Pemakaian : " + index.pakai + " (" + index.akhir + " - " + index.awal + ") \n" + 
							"Harga Air : Rp. " + index.biaya + "\n" + 
							"Pemeliharaan : Rp. " + index.jasa + "\n" + 
							"Sewa Meter : Rp. " + index.sewameter + "\n" + 
							"BTU : Rp. " + index.btu + "\n" + 
							"Materai : Rp. " + index.materai + "\n" +
							"Ppn : Rp. " + index.ppn + "\n" +
							"Total : Rp. " + index.total + "\n" + 
							"================================\n";
						strList.Add(textPrint);
					}
				}

				if(strList.Count > 0){
					for(int i = 0; i < strList.Count; i++){
						DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().SaveTextAsyncAppend("_REKENING.txt", strList[i].ToString());
					}
				}
				Shared.Classes.Optimizer.PrintOut.PrintNow(printerport, DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().LoadText(Android.OS.Environment.ExternalStorageDirectory.ToString(), "_REKENING.txt"));
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("RTTransaction", ex);
			}
		}

		public async static void  PrintNow(string PrinterPort, string textPrint){
			try{
//				var answer = await Shared.Settings.Panels.Alert.Display("Apakah Anda ingin cetak transaksi ini?.", "Cetak Transaksi", "Ya", "Tidak");
//				if(answer == true){
				Shared.Classes.PrintToPrinter.Print(PrinterPort, textPrint);
				string path = Android.OS.Environment.ExternalStorageDirectory.ToString();
				string filename = "_REKENING.txt";
				string fullPath = System.IO.Path.Combine(path, filename);
				DependencyService.Get<Shared.Classes.Dependencies.Interfaces.ISaveAndLoad>().SaveTextAsync(filename, "");
//				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("PrintNow", ex);
			}
		}
	}
}

