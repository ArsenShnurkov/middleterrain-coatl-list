using System;

namespace db_code_test
{
	public class MemberDefSet : MemberDefAbstraction
	{
		public MemberDefSet(ClassDef classDef) : base (classDef)
		{
		}		
		public ClassDef ItemType { get; set;}
	}
}

