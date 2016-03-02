using System;

namespace db_code_test
{
	public abstract class MemberDefAbstraction
	{
		public MemberDefAbstraction(ClassDef classdef)
		{
			this.classDef = classdef;
		}

		public string MemberName {get;set;}

		protected ClassDef classDef;
		public ClassDef ClassDef
		{
			get
			{
				return classDef;	
			}
		}
	}
}
