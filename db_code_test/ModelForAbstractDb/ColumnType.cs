using System;

namespace db_code_test
{
	public class ColumnType
	{
		public ColumnType(MemberType m, string type = null, string additionalInfo = null)
		{
			this.MemberType = m;
			this.text = type;
			this.AdditionalInfo = additionalInfo;
		}
		public MemberType MemberType { get; set; }

		protected string text;
		public string Text
		{
			get
			{
				if (text != null)
				{
					return text;
				}
				return MemberType.Text;
			}
		}

		string AdditionalInfo {get; set; }
	}
}

