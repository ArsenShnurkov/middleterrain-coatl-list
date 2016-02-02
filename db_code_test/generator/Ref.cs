using System;

namespace db_code_test
{
	public class Ref
	{
		Column foreignColumn = null;
		public Column ForeignColumn
		{
			get
			{
				return foreignColumn;
			}
		}
		public Table ForeignTable
		{
			get
			{
				return ForeignColumn.Table;
			}
		}
		/// <summary>
		/// owner table
		/// </summary>
		/// <value>The table.</value>
		public Table Table { get; protected set; }
	}
}

