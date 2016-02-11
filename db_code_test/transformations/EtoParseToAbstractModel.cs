using System;
using System.Linq;
using Eto.Parse;

namespace db_code_test
{
	public partial class EtoParseToAbstractModel
	{
		public AbstractModel DoTransform(GrammarMatch srcModel)
		{
			var dstModel = new AbstractModel ();
			CreateTableDefs(srcModel, dstModel);
			CopyRawFields(srcModel, dstModel);
			return dstModel;
		}
	}
}

