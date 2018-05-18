using System;
using Shared.Classes.Dependencies;
using Shared;
using Xamarin.Forms;
using System.IO;
using Android.Locations;

[assembly: Dependency (typeof (Gadget_Linked))]

namespace Shared
{
	public class Gadget_Linked : Shared.Classes.Dependencies.Interfaces.IGadget
	{
		public Gadget_Linked ()
		{
		}

		public void Close_App()
		{
			Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
		}
	}
}

