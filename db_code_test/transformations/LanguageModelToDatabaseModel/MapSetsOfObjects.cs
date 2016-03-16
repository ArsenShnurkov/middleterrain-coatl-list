using System;
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
		public void MapSetsOfObjects (LanguageModel sourceModel, Schema destModel)
		{
			var listOfSets = new List<ClassDef> (); 
			foreach (var classDef in sourceModel.Classes)
			{
				foreach (var m in classDef.Members)
				{
					if (m is MemberDefSet)
					{
						var ms = m as MemberDefSet;
						var nestedClass = ms.ItemType;
						if (listOfSets.Contains (nestedClass) == false)
						{
							listOfSets.Add (nestedClass);
							CreateSetTable (destModel, classDef, nestedClass);
						}
					}
				}
			}
		}

		public void CreateSetTable (Schema destModel, ClassDef container, ClassDef item)
		{
			// table with set items
			var table = destModel.CreateTable ();
			table.Name = "set_" + container.TableName + "_" + item.TableName;
			var set_id = new ColumnType (null, "KEY", "// Set identifier");
			var set_item = new ColumnType(null, "KEY", "// Set element");
			table.CreateColumn("set_id", set_id);
			table.CreateColumn("item" + "_fk", set_item);
			// column in container to select a set
			var containerTable = destModel.GetTable(container.TableName);
			var set_fk = new ColumnType (null, "KEY", "// Set identifier");
			containerTable.CreateColumn(item.TableName + "_set_fk", set_fk);
		}

		public void MapArraysOfObjects (LanguageModel sourceModel, Schema destModel)
		{
			var listOfArrays = new List<ClassDef> (); 
			foreach (var classDef in sourceModel.Classes)
			{
				foreach (var m in classDef.Members)
				{
					if (m is MemberDefArray)
					{
						var ms = m as MemberDefArray;
						var nestedClass = ms.ItemType;
						if (listOfArrays.Contains (nestedClass) == false)
						{
							listOfArrays.Add (nestedClass);
							CreateArrayTable (destModel, classDef, nestedClass);
						}
					}
				}
			}
		}

		public void CreateArrayTable (Schema destModel, ClassDef container, ClassDef item)
		{
			// table with set items
			var table = destModel.CreateTable ();
			table.Name = "array_" + container.TableName + "_" + item.TableName;
			var array_id = new ColumnType (null, "KEY", "// Array identifier");
			var item_num = new ColumnType(null, "INTEGER", "// order");
			var set_item = new ColumnType(null, "KEY", "// Array element");
			table.CreateColumn("array_id", array_id);
			table.CreateColumn("item_num", item_num);
			table.CreateColumn("item" + "_fk", set_item);
			// column in container to select a set
			var containerTable = destModel.GetTable(container.TableName);
			var set_fk = new ColumnType (null, "KEY", "// Array identifier");
			containerTable.CreateColumn(item.TableName + "_array_fk", set_fk);
		}
	}
}

