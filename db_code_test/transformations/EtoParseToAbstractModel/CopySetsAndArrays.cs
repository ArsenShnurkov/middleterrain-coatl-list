using System;
using System.Linq;
using Eto.Parse;
using System.Collections.Generic;

namespace db_code_test
{
	public partial class EtoParseToAbstractModel
	{
		public void CopySetsAndArrays(GrammarMatch sourceModel, AbstractModel destModel)
		{
			foreach (var c in destModel.Classes)
			{
				// semicolon_separated_field_list
				var table_fields = (from n in sourceModel.Matches 
						where n.Name == "table_definition" && n.Matches["table_name"].Text == c.TableName 
					select n.Matches["semicolon_separated_field_list"]).Single();
				var members_only = from tf in table_fields.Matches
					where tf.Name == "member_definition"
					select tf;
				CopySetsAndArrays (members_only, destModel, c);
			}
		}
		void CopySetsAndArrays(IEnumerable<Match> m, AbstractModel destModel, ClassDef c)
		{
			foreach (var member_definition in m)
			{
				if (member_definition.Matches.Count == 0)
				{
					throw new ApplicationException ("Error in grammar");
				}
				var field_def = member_definition.Matches [0];
				var rule_name = field_def.Name;
				if (rule_name != "set_definition" && rule_name != "array_definition")
				{
					continue;
				}
				var item_type = field_def.Matches["item_type"];
				var db_name = field_def.Matches ["db_name"];

				string alias;
				var code_name = field_def.Matches ["code_name"];
				if (code_name.Success)
				{
					alias = code_name.Text;
				}
				else
				{
					alias = db_name.Text;
				}
				var cd = destModel.Classes[item_type.Text];
				if (rule_name == "set_definition")
				{
					c.CreateSetMember(cd, db_name.Text, alias);
				}
				if (rule_name == "array_definition")
				{
					c.CreateArrayMember(cd, db_name.Text, alias);
				}
			}
		}
	}
}
