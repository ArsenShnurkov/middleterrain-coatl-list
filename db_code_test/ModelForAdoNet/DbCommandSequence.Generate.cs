using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;

namespace db_code_test
{
	public partial class DbCommandSequence
	{
		public void Generate (TextWriter tw)
		{
			for (int i = 0; i < commands.Count; ++i)
			{
				var cmd = commands [i];
				if (cmd.Parameters.Count > 0)
				{
					throw new NotImplementedException("Parameters are not implemented yet");
				}
				tw.WriteLine (cmd.CommandText);
			}
		}
	}
}
