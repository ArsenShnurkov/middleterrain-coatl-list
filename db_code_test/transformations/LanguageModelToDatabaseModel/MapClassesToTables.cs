using System;
using System.Linq;
using Deveel.Math;
using System.Collections.Generic;

namespace db_code_test
{
	public partial class AbstractModelToDatabaseModel
	{
		/// <summary>
		/// Create tables, one for each class
		/// </summary>
		/// <param name="sourceModel">Source model.</param>
		/// <param name="destModel">Destination model.</param>
		public void MapClassesToTables (LanguageModel sourceModel, Schema destModel)
		{
			foreach (ClassDefInCollectionInAbstractModel c in sourceModel.Classes)
			{
				CreateTableRowInDbClassTable (destModel, c);
			}
			foreach (ClassDefInCollectionInAbstractModel c in sourceModel.Classes)
			{
				CreateTable (destModel, c);
			}
		}
		public void CreatePrimaryKeys(LanguageModel sourceModel, Schema destModel)
		{
			int count = (from tables in destModel.Tables select tables).Count();
			int power = (int)Math.Ceiling(Math.Log ((double)count, 2)) + 2;
			int multiplier = (int)Math.Pow(2, power);
			int index = 0;
			foreach (var table in destModel.Tables)
			{
				foreach (var col in table.Columns) {
					if (table.IsPrimaryKey (col.Name))
					{
						index++;
						CreateSequence (destModel, table.Name, index, multiplier);
						break;
					}
				}
			}
		}
		public void InsertDbObject(List<ClassDef> list, LanguageModel model)
		{
			var dbobject = model.Classes["dbobject"];
			list.Add (dbobject);
		}
		public void CreateTable (Schema destModel, ClassDefInCollectionInAbstractModel c)
		{
			var table = destModel.CreateTable ();
			table.Name = c.TableName;
			/*Column pk =*/ table.CreateColumn(table.Name + "_pk", KeyType);
			var listOfClasses = ClassDef.GetListOfClasses (c);
			InsertDbObject (listOfClasses, c.AbstractModel);
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

		public void CreateSequence (Schema destModel, string name, int start, int step)
		{
			var sequence = destModel.CreateSequence ();
			sequence.Name = name + "_ids";
			sequence.Start = start;
			sequence.Step = step;
		}

		public void CreateTableRowInDbClassTable (Schema destModel, ClassDef c)
		{
		}
	}
}

