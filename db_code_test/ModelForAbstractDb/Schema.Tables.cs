using System;
using System.Collections.Generic;

namespace db_code_test
{
	public partial class Schema
	{
		List<Table> tables = new List<Table>();
		public IEnumerable<Table> Tables { get { return tables; } }

		/// <summary>
		/// Creates table within the list of tables
		/// </summary>
		/// <returns>The table.</returns>
		public Table CreateTable(string name = null)
		{
			var res = new Table();
			res.Schema = this;
			res.Name = name;
			tables.Add(res);
			return res;
		}

		public Table GetTable(string name)
		{
			for (int i = 0; i < tables.Count; ++i)
			{
				var t = tables [i];
				if (t.Name == name)
				{
					return t;
				}
			}
			throw new ArgumentOutOfRangeException (nameof (name));
		}
		IEnumerable<Table> creationSequence = null;
		IEnumerable<Table> removalSequence = null;

		public IEnumerable<Table> CreationSequence
		{ 
			get 
			{ 
				if (creationSequence == null || removalSequence == null)
				{
					build ();
				}
				return creationSequence; 
			} 
		}

		public IEnumerable<Table> RemovalSequence
		{ 
			get 
			{ 
				if (creationSequence == null || removalSequence == null)
				{
					build ();
				}
				return removalSequence; 
			} 
		}

		protected void build()
		{
			var seq1 = topological_then_alphabet_sort (tables);
			creationSequence = seq1;
			int length = tables.Count;
			var seq2 = new Table[length]; // create clone
			foreach (var item in creationSequence)
			{
				seq2[--length] = item;
			}
			removalSequence = seq2;
		}

		/// <summary>
		/// </summary>
		/// <remarks>A topological ordering is possible if and only if the graph has no directed cycles.
		/// algorithms are known for constructing a topological ordering of any DAG in linear time.
		/// Kahn's algorithm from
		/// https://en.wikipedia.org/wiki/Topological_sorting
		/// http://www.codeproject.com/Articles/869059/Topological-sorting-in-Csharp
		/// </remarks>
		/// <returns>The then alphabet sort.</returns>
		/// <param name="schema">Schema.</param>
		protected IEnumerable<Table> topological_then_alphabet_sort (List<Table> tables)
		{
			var res = TopologicalSort.Sort<Table> (tables, table => table.Schema.GetReferencedTables (table));
			return res;
		}
	}
}

