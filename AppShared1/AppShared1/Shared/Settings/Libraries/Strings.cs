using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Settings.Libraries
{
    public class Strings
    {
		public static string promptLogoutApp = "Konfirmasi Logout Aplikasi?";
		public static string promptQuitApp = "Konfirmasi Keluar Aplikasi?";
		public static string RTOTitle = "Permintaan batas waktu";
		public static string RTOMessage = "Kehilangan koneksi selama permintaan. Silakan coba lagi segera.";
		public static string Retry = "Coba Lagi";
		public static string Cancel = "Batal";
		public static string SearchMessage = "Tentukan setidaknya satu filter untuk mengembalikan hasil";
		public static string SearchTitle = "Pencarian";
		public static string NoDataMessage = "Tidak ada data untuk ditampilkan";
		public static string NoDataTitle = "Data Tidak Ditemukan";
		public static string InvalidBarcodeMessage = "Hasil barcode tidak dapat proses. Akhiri operasi.";
		public static string InvalidBarcodeTitle = "Validasi Barcode";
		public static string InvalidUserPassMessage = "Username / password salah";
		public static string InvalidUserPassTitle = "Otentikasi Gagal";
    }

	public class Enumerables {
		public enum PrintMode 
		{
			ErrorLog, 
			PrinterPort
		}

		public enum ConvertDateMode{
			Login, 
			DaftarLunas
		}
	}

	public class TimeOut{
		public static int Short = 3000;
		public static int Medium = 5000;
		public static int Long = 7000;
	}
}
