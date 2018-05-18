using System;
using SQLite.Net;

namespace Shared.Services
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

