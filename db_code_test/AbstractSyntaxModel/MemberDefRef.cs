using System;

namespace db_code_test
{
	public class MemberDefRef : MemberDefAbstraction
	{
		public MemberDefRef(ClassDef classDef) : base (classDef)
		{
		}	
		public ClassDef ForeignClass { get; set;}
	}
}

