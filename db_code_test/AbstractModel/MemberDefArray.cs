using System;

namespace db_code_test
{
	public class MemberDefArray : MemberDefAbstraction
	{
		public MemberDefArray(ClassDef classDef) : base (classDef)
		{
		}		
		public ClassDef ItemType { get; set;}
	}
}

