using System;
using System.Linq;
using Eto.Parse;
using System.Collections.Generic;

namespace db_code_test
{
	public partial class EtoParseToAbstractModel
	{
		public void CopyRawFields(GrammarMatch sourceModel, AbstractModel destModel)
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
				CopyFields (members_only, c);
			}
		}
		void CopyFields(IEnumerable<Match> m, ClassDef c)
		{
			foreach (var member_definition in m)
			{
				if (member_definition.Matches.Count == 0)
				{
					throw new ApplicationException ("Error in grammar");
				}
				if (member_definition.Matches [0].Name != "field_definition")
				{
					continue;
				}
				var field_def = member_definition.Matches ["field_definition"];
				var type = field_def.Matches["raw_type"];
				string name = field_def.Matches["identifier"].Text;

				string alias;
				var field_name = field_def.Matches ["field_name"];
				if (field_name.Success)
				{
					alias = field_def.Matches ["field_name"].Text;
				}
				else
				{
					alias = name;
				}
				c.CreateMember (type, name, alias);
			}
		}
	}
}

