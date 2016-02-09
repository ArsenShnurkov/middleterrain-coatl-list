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
			// create class defs
			var tableDeclarations = from n in rootNode.Matches where n.Name == "table_definition" select n.Matches["table_name"].Text;
			foreach (var decl in tableDeclarations)
			{
				var t = res.Classes.CreateClassDef();
				t.TableName = decl;
			}
			// create inheritance list
			var table_rules = from n in rootNode.Matches where n.Name == "table_definition" select n;
			foreach (var r in table_rules)
			{
				string tableName = (from rm in r.Matches where rm.Name == "table_name" select rm.Text).Single ();
				var classDef = res.Classes[tableName];

				var inhspec = from item in r.Matches
				              where item.Name == "inheritance_specification"
				              select item;
				if (inhspec.Count() == 0)
				{
					continue;
				}
				var inhspeclist = from specitem in inhspec.Single ().Matches
				                  where specitem.Name == "inheritance_specification_list"
				                  select specitem;
				if (inhspec.Count() != 1)
				{
					throw new ApplicationException ("error in parser");
				}
				// filter out commas and whitespaces
				var spec = from identifier in inhspeclist.Single().Matches
					where identifier.Name == "identifier"
					select identifier;
				foreach (var m in spec)
				{
					string s = m.Text;
					if (res.Classes.ContainsTableName(s))
					{
						var baseClassDef = res.Classes[s];
						if (classDef.InheritanceSpecification.Contains (baseClassDef) == false)
						{
							classDef.InheritanceSpecification.Add(baseClassDef);
						}
					}
				}
			}
			return res;
		}
	}
}

