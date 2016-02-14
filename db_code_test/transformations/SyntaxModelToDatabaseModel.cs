using System;
using System.Collections.Generic;

namespace db_code_test
{
	public partial class SyntaxModelToDatabaseModel
	{
		public Schema DoTransform(AbstractModel sourceModel)
		{
			var destModel = new Schema ();
			MapClassesToTables(sourceModel, destModel);
			MapInheritanceLinks(sourceModel, destModel);
			MapSetsOfObjects(sourceModel, destModel);
			MapArraysOfObjects(sourceModel, destModel);
			return destModel;
		}

	}
}
