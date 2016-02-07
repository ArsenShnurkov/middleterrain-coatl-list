using System;
using System.Linq;
using Eto.Parse;

namespace db_code_test
{
	public class EtoParseToAbstractModel
	{
		public AbstractModel DoTransform(GrammarMatch rootNode)
		{
			var res = new AbstractModel ();
			var tableDeclarations = from n in rootNode.Matches where n.Name == "table_definition" select n.Matches["class_name"].Text;
			foreach (var name in tableDeclarations)
			{
				var t = res.CreateClassDef();
				t.ClassName = name;
			}
			return res;
		}
	}
}

