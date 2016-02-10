using System;
using System.Collections.Generic;

namespace db_code_test
{
	public class Row
	{
		List<Cell> cells = new List<Cell>();
		public IEnumerable<Cell> Cells { get { return cells; } }

		public Cell CreateCell(Column col)
		{
			var res = new Cell();
			res.Column = col;
			cells.Add(res);
			return res;
		}
		public Cell this[string name]
		{
			get
			{
				for (int i = 0; i < cells.Count; ++i)
				{
					var c = cells [i];
					if (c.Column.Name == name)
					{
						return c;
					}
				}
				throw new ArgumentOutOfRangeException (nameof (name));
			}
		}
	}
}

