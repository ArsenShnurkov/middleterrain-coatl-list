using System;
using System.Collections.Generic;

namespace db_code_test
{
	public partial class Table
	{
		// Rows
		List<Row> rows = new List<Row>();
		public IEnumerable<Row> Rows { get { return rows; } }

		public Row CreateRow()
		{
			Row row = new Row ();
			rows.Add (row);
			for (int i = 0; i < columns.Count; ++i)
			{
				row.CreateCell(columns[i]);
			}
			return row;
		}
	}
}

