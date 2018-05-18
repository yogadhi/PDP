using System;
using Android.Bluetooth;
using Java.IO;
using Java.Util;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Dependencies;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Android.Graphics;
using System.IO;
using System.Drawing;
using Shared.Classes;
using System.Collections;

namespace Shared.Classes
{
	public class PrintToPrinter
	{
		public static void Print (string bt_printer, string value)
		{
			try{
				if(bt_printer != "" || bt_printer != null || bt_printer.Length > 0){
					
					var x = BluetoothAdapter.DefaultAdapter.BondedDevices;
				
					BluetoothSocket socket = null;
					BufferedReader inReader = null;
					BufferedWriter outReader = null;

					BluetoothDevice hxm = BluetoothAdapter.DefaultAdapter.GetRemoteDevice (bt_printer);
					UUID applicationUUID = UUID.FromString ("00001101-0000-1000-8000-00805F9B34FB");
					socket = hxm.CreateRfcommSocketToServiceRecord (applicationUUID);
					socket.Connect ();

					inReader = new BufferedReader(new InputStreamReader(socket.InputStream));
					outReader = new BufferedWriter(new OutputStreamWriter(socket.OutputStream));
					outReader.Write(value);
					outReader.Flush();
					Thread.Sleep(5 * 1000);
					var s = inReader.Ready();
					inReader.Skip(0);
					//close all
					inReader.Close();
					socket.Close();
					outReader.Close ();
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("Print", ex);
			}
		}

		public static void PrintNew (string bt_printer)
		{
			try{
				string path = Android.OS.Environment.ExternalStorageDirectory.ToString();
				string filename = "ic_logo.png";
				string fullPath = System.IO.Path.Combine(path, filename);
				byte[] dataBytes = System.IO.File.ReadAllBytes(fullPath);
				Bitmap icon = BitmapFactory.DecodeFile(fullPath);
				var ms = new MemoryStream();
				icon.Compress(Bitmap.CompressFormat.Png, 90, ms);
				var iconBytes = ms.ToArray();

				if(bt_printer != "" || bt_printer != null || bt_printer.Length > 0){
					byte[] SELECT_BIT_IMAGE_MODE = {0x1B, 0x2A, 33, 255, 3};
					BluetoothSocket socket = null;

					SELECT_BIT_IMAGE_MODE = iconBytes;

					BluetoothDevice hxm = BluetoothAdapter.DefaultAdapter.GetRemoteDevice (bt_printer);
					UUID applicationUUID = UUID.FromString ("00001101-0000-1000-8000-00805F9B34FB");
					socket = hxm.CreateRfcommSocketToServiceRecord (applicationUUID);
					socket.Connect ();

					socket.OutputStream.Write(SELECT_BIT_IMAGE_MODE, 0, SELECT_BIT_IMAGE_MODE.Length);
					socket.Close();
				}
			}catch(Exception ex){
				Shared.Services.Logs.Insights.Send ("Print", ex);
			}
		}


	}
}

