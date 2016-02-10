using System;
using System.Collections.Generic;

namespace db_code_test
{
	public partial class Schema
	{
		// Tables - see Schema.Tables.cs

		// Refs
		List<Ref> refs = new List<Ref>();
		public IEnumerable<Ref> Refs { get { return refs; } }

		public void CreateLink(Column onManySide, Column onOneSide)
		{
			var r = new Ref (onManySide, onOneSide);
			refs.Add (r);
		}
	}
}
