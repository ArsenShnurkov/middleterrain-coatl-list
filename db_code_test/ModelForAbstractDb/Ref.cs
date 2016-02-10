using System;

namespace db_code_test
{
	public class Ref
	{
		public Ref (Column from, Column to)
		{
			this.From = from;
			this.To = to;
		}
		public Column From { get; set; }
		public Column To { get; set; }
	}
}

