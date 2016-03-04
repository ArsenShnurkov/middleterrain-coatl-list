using System;

namespace db_code_test
{
	public class PropertyDefAbstraction
	{
		protected MemberDefAbstraction memberDefAbstraction;

		public MemberDefAbstraction MemberDefAbstraction 
		{
			get
			{
				return memberDefAbstraction;
			}
		}
	}
}

