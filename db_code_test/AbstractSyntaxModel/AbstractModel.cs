using System;
using System.Collections.Generic;

namespace db_code_test
{
	public class AbstractModel
	{
		/// <summary>
		/// Список классов, которые определяются моделью
		/// </summary>
		List<ClassDef> classes = new List<ClassDef>();
		List<ObjectDef> objects = new List<ObjectDef>();
		List<Variable> variables = new List<Variable>();
		public ClassDef CreateClassDef()
		{
			var res = new ClassDef();
			res.AbstractModel = this;
			classes.Add(res);
			return res;
		}
	}
}

