using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Akavache;
using System.Reactive.Linq;


namespace Shared.Classes.Cache
{
	public class cxCache
	{
		public class AccessCredential{
			static string MainKey = "accesscredential";

			public static IAccessCredential container(string kdpasar, string userid, string username, string password, string datestart, string dateend, string status, string tgl_close, string printerport){
				try
				{
					IAccessCredential data = new IAccessCredential ();
					data.Kdpasar = kdpasar;
					data.UserID = userid;
					data.Username = username;
					data.Password = password;
					data.DateStart = datestart;
					data.DateEnd = dateend;
					data.Status = status;
					data.Tgl_Close = tgl_close;
					data.PrinterPort = printerport;

					return data;
				}
				catch (Exception ex)
				{
					//Shared.Services.Logs.Insights.Send("AccessCredential container", ex);
					return null;
				}
			}

			public static async Task Store(IAccessCredential data)
			{
				try
				{
					string key = MainKey;
					await BlobCache.LocalMachine.InsertObject<IAccessCredential>(key.ToLower(), data);
				}
				catch (Exception ex)
				{
					//Shared.Services.Logs.Insights.Send("AccessCredential Store", ex);
					//throw ex;
				}
			}

			public static async Task<IAccessCredential> Collect()
			{
				try
				{
					string key = MainKey;
					var res = await BlobCache.LocalMachine.GetObject<IAccessCredential>(key.ToLower());
					return res;
				}
				catch (KeyNotFoundException ex)
				{
					//Shared.Services.Logs.Insights.Send("AccessCredential Collect", ex);
					return null;
				}
			}

			public static async Task Dump()
			{
				try
				{
					string key = MainKey;
					await BlobCache.LocalMachine.InvalidateObject<IAccessCredential>(key.ToLower());
				}
				catch (Exception ex)
				{
					//Shared.Services.Logs.Insights.Send("AccessCredential Dump", ex);
					//throw ex;
				}
			}
		}
	}
}

