using System;
using System.Collections.Generic;

namespace db_code_test
{
	public partial class AbstractModelToDatabaseModel
	{
		public Schema DoTransform(LanguageModel sourceModel)
		{
			var destModel = new Schema ();
			MapClassesToTables(sourceModel, destModel);
			MapInheritanceLinks(sourceModel, destModel);
			MapSetsOfObjects(sourceModel, destModel);
			MapArraysOfObjects(sourceModel, destModel);
			CreatePrimaryKeys(sourceModel, destModel);
			return destModel;
		}

	}
}
