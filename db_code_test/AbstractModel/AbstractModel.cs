using System;
using System.Collections.Generic;

namespace db_code_test
{
	public class AbstractModel
	{
		public AbstractModel()
		{
			classDefCollection = new ClassDefCollectionInAbstractModel(this);
		}

		ClassDefCollectionInAbstractModel classDefCollection;

		public ClassDefCollectionInAbstractModel Classes
		{
			get
			{
				return classDefCollection;
			}
		}

		List<ObjectDef> objects = new List<ObjectDef>();

		public IEnumerable<ObjectDef> Objects
		{
			get
			{
				return objects;
			}
		}

		List<Variable> variables = new List<Variable>();

		public IEnumerable<Variable> Variables
		{
			get
			{
				return variables;
			}
		}
	}
}
