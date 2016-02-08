using System;
using System.Collections.Generic;

namespace db_code_test
{
	
	public class ObjectDef
	{
		public ClassDef ClassDef {get; set;}

		List<PropertyDefAbstraction> fields = new List<PropertyDefAbstraction>();

		public IEnumerable<PropertyDefAbstraction> Fields
		{
			get
			{
				return fields;
			}
		}
	}
}
