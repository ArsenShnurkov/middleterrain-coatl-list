using System;
using System.Collections.Generic;

namespace db_code_test
{
	public class Table
	{
		public Schema Schema {get; set;}
		public string Name {get; set;}
		/// <summary>
		/// Список полей объекта
		/// </summary>
		List<Column> columns = new List<Column>();
		List<Ref> refs = new List<Ref>();

		public IEnumerable<Table> Dependencies
		{ 
			get
			{
				var res = new SortedList<string, Table> ();
				foreach (var r in refs)
				{
					var ft = r.ForeignTable;
					if (res.ContainsKey (ft.Name) == false) {
						res.Add (ft.Name, ft);
					}
				}
				Table[] array = new Table[res.Values.Count];
				res.Values.CopyTo(array, 0);
				return array;
			}
		}

		public IEnumerable<Column> Columns { get { return columns; } }
		/// <summary>
		/// Creates a new column and adds it into the list fo columns of this table
		/// </summary>
		public Column CreateColumn()
		{
			var res = new Column();
			res.Table = this;
			columns.Add(res);
			return res;
		}
	}
}

