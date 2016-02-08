using System;
using System.Collections.Generic;

namespace db_code_test
{
	
	public class ClassDef
	{
		public AbstractModel AbstractModel { get; set; }

		/// <summary>
		/// Список таблиц, в которых лежат поля объекта
		/// </summary>
		List<Table> tables = new List<Table>();

		public IEnumerable<Table> InheritanceSpecification {
			get {
				return tables;
			}
		}

		public string ClassName { get; set; }
		public string TableName {
			get {
				if (tables.Count > 0) {
					return tables[0].Name;
				} else {
					throw new ApplicationException ("table list is not populated");
				}
			}
			set {
				if (tables.Count == 0) {
					var t = new Table ();
					tables.Add (t);
				}
				tables [0].Name = value;
			}
		}
		List<MemberDefAbstraction> fields = new List<MemberDefAbstraction>();
		public IEnumerable<MemberDefAbstraction> Fields
		{
			get
			{
				return fields;
			}
		}
	}
}
