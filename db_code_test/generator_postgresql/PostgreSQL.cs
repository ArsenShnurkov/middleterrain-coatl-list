using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace db_code_test
{
	public class PostgreSQL
	{
		public void Generate(Schema schema, TextWriter stream)
		{
			foreach (var t in schema.RemovalSequence)
			{
				Generate_Drop_Statement (t, stream);
			}
			foreach (var t in schema.CreationSequence)
			{
				Generate_Create_Statement (t, stream);
			}
		}

		public void Generate_Drop_Statement(Table t, TextWriter stream)
		{
			stream.WriteLine("DROP TABLE IF EXISTS '{0}';", t.Name);
		}

		public void Generate_Create_Statement(Table t, TextWriter stream)
		{
			var columnsList = new StringBuilder ();
			foreach (var c in t.Columns)
			{
				if (columnsList.Length != 0)
				{
					columnsList.Append(", ");
				}
				columnsList.AppendFormat ("{0} {1}", c.Name, GetNativeType (c.SpecType));
			}
			var createStatement = new StringBuilder ();
			createStatement.AppendFormat ("CREATE TABLE {0} ( {1});", t.Name, columnsList.ToString());
			stream.WriteLine(createStatement.ToString());
		}

		protected string GetNativeType(string SpecType)
		{
			switch (SpecType)
			{
			case "DECIMAL":
				return "DECIMAL";
			case "TIMESTAMP":
				return "TIMESTAMP";
			case "INTEGER":
				return "INTEGER";
			case "STRING":
				return "VARCHAR";
			default:
				throw new ArgumentException (string.Format("SpecType is {0} which is unexpected", SpecType));
			}
		}
	}
}

