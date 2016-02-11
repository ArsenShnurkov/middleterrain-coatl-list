using System;
using System.Collections.Generic;
using System.Data.Common;

namespace db_code_test
{
	public partial class DbCommandSequence
	{
		List<DbCommand> commands = new List<DbCommand>();
		public IEnumerable<DbCommand> Commands { get { return commands; } }

		public DbCommand CreateCommand(string text = null)
		{
			var res = new NonspecificDbCommand();
			res.CommandText = text;
			commands.Add (res);
			return res;
		}
	}
}

