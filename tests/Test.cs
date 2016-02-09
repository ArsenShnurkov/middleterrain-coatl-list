using NUnit.Framework;
using System;
using System.IO;
using System.Diagnostics;

namespace tests
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase1 ()
		{
			var grammar = Globals.LoadFromResource("tests", "Resources", "test1.ebnf");
			Globals.Process (grammar, ":A");
		}
		[Test ()]
		public void TestCase2 ()
		{
			var grammar = Globals.LoadFromResource("tests", "Resources", "test1.ebnf");
			Globals.Process (grammar, ":A,A");
		}
		[Test ()]
		public void TestCase3 ()
		{
			var grammar = Globals.LoadFromResource("tests", "Resources", "test1.ebnf");
			Globals.Process (grammar, ":A,A,A");
		}
		[Test ()]
		public void TestCase4 ()
		{
			var grammar = Globals.LoadFromResource("tests", "Resources", "test1.ebnf");
			Globals.Process (grammar, ":A,A,A,A");
		}
	}
}

