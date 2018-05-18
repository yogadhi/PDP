using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;
using Shared.Classes.Components;
using Shared.Classes.Cache;

namespace YAP.Core
{
	public class PrintEncryptor : System.ComponentModel.Component
	{

		#region " Component Designer generated code "
		static PrintEncryptor()
		{
			_key = new byte[] {
				11,
				13,
				17,
				144,
				88,
				36,
				77,
				48,
				29,
				50,
				111,
				99,
				213,
				14,
				135,
				118,
				167,
				198,
				153,
				200,
				241,
				29,
				23,
				44
			};
			_iv = new byte[] {
				19,
				88,
				37,
				140,
				65,
				56,
				76,
				18,
				99,
				107,
				129,
				123,
				27,
				114,
				159,
				196,
				179,
				198,
				192,
				220,
				212,
				123,
				32,
				44
			};
		}

		public PrintEncryptor()
			: base()
		{

			//This call is required by the Component Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call
		}

		//Component overrides dispose to clean up the component list.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if ((components != null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		//Required by the Component Designer

		private System.ComponentModel.IContainer components;
		//NOTE: The following procedure is required by the Component Designer
		//It can be modified using the Component Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}

		#endregion

		// Fields
		private static byte[] _iv;
		private static byte[] _key;

		private static bool _Status;
		public byte[] CryptIV
		{
			set
			{
				if (value == null == false)
				{
					_iv = value;
				}
			}
		}

		public byte[] CryptKey
		{
			set
			{
				if (value == null == false)
				{
					_key = value;
				}
			}
		}

		public static string Encrypt(string Value)
		{
			try{
				TripleDESCryptoServiceProvider objCrypt = new TripleDESCryptoServiceProvider();
				MemoryStream stmMem = new MemoryStream();
				CryptoStream stmCrypt = new CryptoStream(stmMem, objCrypt.CreateEncryptor(_key, _iv), CryptoStreamMode.Write);
				StreamWriter stwInfo = new StreamWriter(stmCrypt);
				stwInfo.Write(Value);
				stwInfo.Flush();
				stmCrypt.FlushFinalBlock();
				stmMem.Flush();
				return Convert.ToBase64String(stmMem.GetBuffer(), 0, Convert.ToInt32(stmMem.Length));
			}catch(Exception ex){
				_Status = false;
				return Value;
				Shared.Services.Logs.Insights.Send ("Encrypt", ex);
			}
		}

		public static string Decrypt(string Value)
		{
			try
			{
				TripleDESCryptoServiceProvider objCrypt = new TripleDESCryptoServiceProvider();
				byte[] bBuffer = Convert.FromBase64String(Value);
				MemoryStream stmMem = new MemoryStream(bBuffer);
				CryptoStream stmCrypt = new CryptoStream(stmMem, objCrypt.CreateDecryptor(_key, _iv), CryptoStreamMode.Read);
				StreamReader strInfo = new StreamReader(stmCrypt);
				_Status = true;
				return strInfo.ReadToEnd();
			}
			catch (Exception ex)
			{
				_Status = false;
				return Value;
				Shared.Services.Logs.Insights.Send ("Decrypt", ex);
			}
		}

		public static bool Status
		{
			get { return _Status; }
		}
	}
}
