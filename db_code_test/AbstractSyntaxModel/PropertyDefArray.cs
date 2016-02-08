using System;
using System.Collections.Generic;

namespace db_code_test
{
	public class PropertyDefArray : PropertyDefAbstraction
	{
		List<PropertyDefRaw> items = new List<PropertyDefRaw>();

		public IEnumerable<PropertyDefRaw> Items
		{
			get
			{
				return items;
			}
		}
	}
}

