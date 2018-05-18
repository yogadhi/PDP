using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shared.Classes.Components;

using Shared.Classes.Cache;
using Shared.Classes;

namespace Shared.Classes
{
	public class ParamPasser
	{
		public bool boolParameter { get; set; }

		public string stringParameter { get; set; }

		public int intParameter { get; set; }

		public DateTime DateParameter { get; set; }

		public List<Shared.Services.Table.REKENING_STAND> Stands { get; set; }
	}
}

