using System;
using Deveel.Math;

namespace db_code_test
{
	public partial class AbstractModelToDatabaseModel
	{
		/// <summary>
		/// Create tables, one for each class
		/// </summary>
		/// <param name="sourceModel">Source model.</param>
		/// <param name="destModel">Destination model.</param>
		public void MapClassesToTables (AbstractModel sourceModel, Schema destModel)
		{
			foreach (var c in sourceModel.Classes)
			{
				CreateTable (destModel, c);
			}
		}

		public void CreateTable (Schema destModel, ClassDef c)
		{
			var table = destModel.CreateTable ();
			table.Name = c.TableName;
			/*Column pk =*/ table.CreateColumn(table.Name + "_pk", KeyType);
			var listOfClasses = ClassDef.GetListOfClasses (c);
			foreach (ClassDef classDef in listOfClasses)
			{
				foreach (var m in classDef.Members)
				{
					if (m is MemberDefRaw)
					{
						var mr = m as MemberDefRaw;
						if (mr.Type.Text == "RATIONAL")
						{
							var ctu = new ColumnType (mr.Type, "INTEGER", "// Upper");
							var ctl = new ColumnType(mr.Type, "INTEGER", "// Lower");
							table.CreateColumn(m.MemberName + "_upper", ctu);
							table.CreateColumn(m.MemberName + "_lower", ctl);
						}
						else
						{
							/*var column =*/ table.CreateColumn(m.MemberName, new ColumnType(mr.Type));
						}
					}
				}
			}
		}
	}
}

