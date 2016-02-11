using System;

namespace db_code_test
{
	public class MemberDefRaw : MemberDefAbstraction
	{
		public MemberDefRaw(ClassDef classDef) : base (classDef)
		{
		}
		public MemberType Type { get; set;}
	}
}

