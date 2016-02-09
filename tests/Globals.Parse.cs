using System.Reflection;
using System.IO;
using Eto.Parse.Grammars;
using Eto.Parse;
using System.Diagnostics;
using System;

partial class Globals
{
	public static GrammarMatch Process (string grammar_def, string text)
	{
		EbnfStyle style = (EbnfStyle)(
			(uint)EbnfStyle.Iso14977 
			//& ~(uint) EbnfStyle.WhitespaceSeparator	
			| (uint) EbnfStyle.EscapeTerminalStrings);

		EbnfGrammar grammar;
		Grammar parser;
		try
		{
			grammar = new EbnfGrammar(style);
			parser = grammar.Build(grammar_def, "file");
		}
		catch (Exception ex)
		{
			Trace.WriteLine (ex.ToString ());
			/*
System.ArgumentException: the topParser specified is not found in this ebnf
  at Eto.Parse.Grammars.EbnfGrammar.Build (System.String bnf, System.String startParserName) [0x00048] in <filename unknown>:0 
  at Globals.Main (System.String[] args) [0x0002b] in /var/calculate/remote/distfiles/egit-src/SqlParser-on-EtoParse.git/test1/Program.cs:20 
*/
			throw;
		}

		var match = parser.Match(text);
		if (match.Success == false) {
			Trace.WriteLine ("No luck!");
		}
		else {
			Trace.WriteLine ("Success.");
		}
		return match;
	}
}
