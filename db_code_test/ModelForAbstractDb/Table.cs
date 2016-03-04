using System;
using System.Collections.Generic;

namespace db_code_test
{
	public partial class Table
	{
		public Schema Schema {get; set;}
		public string Name {get; set;}
		/// <summary>
		/// Список полей объекта
		/// </summary>
		List<Column> columns = new List<Column>();

		public IEnumerable<Table> Dependencies
		{ 
			get
			{
				var res = new SortedList<string, Table> ();
				foreach (var r in Schema.Refs)
				{
					var ft = r.To.Table;
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
		public bool IsPrimaryKey(string name)
		{
			bool res = name.EndsWith ("_pk");
			return res;
		}
		public Column CreateColumn()
		{
			var res = new Column();
			res.Table = this;
			columns.Add(res);
			return res;
		}
		public Column CreateColumn(string name, ColumnType type)
		{
			Column res = CreateColumn ();
			res.Name = name;
			res.SpecType = type;
			return res;
		}
		public bool ContainColumn(string name)
		{
			for (int i = 0; i < columns.Count; ++i)
			{
				if (columns [i].Name == name)
				{
					return true;
				}
			}
			return false;
		}
		public Column GetColumn(string name)
		{
			for (int i = 0; i < columns.Count; ++i)
			{
				var c = columns [i];
				if (c.Name == name)
				{
					return c;
				}
			}
			throw new ArgumentOutOfRangeException (nameof (name));
		}
	}
}

