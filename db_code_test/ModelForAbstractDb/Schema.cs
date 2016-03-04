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

		List<Sequence> sequences = new List<Sequence>();
		public IEnumerable<Sequence> Sequences { get { return sequences; } }

		public Sequence CreateSequence(string name = null)
		{
			var res = new Sequence();
			res.Schema = this;
			if (false == string.IsNullOrWhiteSpace(name)) {
				res.Name = name;
			}
			sequences.Add(res);
			return res;
		}

		public IEnumerable<Table> GetReferencedTables(Table detail)
		{
			var res = new List<Table> ();
			for (int i = 0; i < refs.Count; ++i)
			{
				var r = refs [i];
				if (r.From.Table == detail)
				{
					res.Add (r.To.Table);
				}
			}
			return res;
		}
	}
}
