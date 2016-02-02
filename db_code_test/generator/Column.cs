using System;
using System.IO;

namespace db_code_test
{
	public class Column
	{
		/// <summary>
		/// К какой таблице относится эта колонка
		/// </summary>
		/// <value>The table.</value>
		public Table Table {get; set;}
		/// <summary>
		/// Как называется
		/// </summary>
		/// <value>The name.</value>
		public string Name {get; set;}
		/// <summary>
		/// Какой тип имеет
		/// </summary>
		/// <value>The type of the spec.</value>
		public string SpecType {get; set;}

		/// <summary>
		/// нагенерировать код для колонки под указанную СУБД
		/// </summary>
		/// <param name="outstream">Outstream.</param>
		public void GenerateText(TextWriter outstream)
		{
		}
	}
}

