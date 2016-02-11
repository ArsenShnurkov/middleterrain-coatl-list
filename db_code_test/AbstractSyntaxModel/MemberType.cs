using System;
using Eto.Parse;

namespace db_code_test
{
	public class MemberType
	{
		public MemberType(Match m)
		{
			this.Match = m;
		}
		public Match Match { get; set; }
		public string Text
		{
			get
			{
				return Match.Text;
			}
		}
	}
}

