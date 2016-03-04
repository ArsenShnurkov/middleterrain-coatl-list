using System;
using System.Linq;
using Eto.Parse;

namespace db_code_test
{
	public partial class EtoParseToLanguageModel
	{
		public LanguageModel DoTransform(GrammarMatch srcModel)
		{
			var dstModel = new LanguageModel ();
			CreateTableDefs(srcModel, dstModel);
			CopyRawFields(srcModel, dstModel);
			CopySetsAndArrays(srcModel, dstModel);
			return dstModel;
		}
	}
}

