using System;
using Deveel.Math;

namespace db_code_test
{
	public partial class SyntaxModelToDatabaseModel
	{
		public static readonly string InheritanceColumnName = "InheritanceType";
		public static readonly string InheritanceColumnType = "KEY";
		public static readonly string RefColumnName = "types_fk";

		/// <summary>
		/// Create tables, one for each class
		/// </summary>
		/// <param name="sourceModel">Source model.</param>
		/// <param name="destModel">Destination model.</param>
		public void MapInheritanceLinks (AbstractModel sourceModel, Schema destModel)
		{
			foreach (var child in sourceModel.Classes)
			{
				var parents = child.InheritanceSpecification;
				foreach (var parent in parents)
				{
					ProcessInheritanceLink(destModel, child, parent);
				}
			}
		}

		public void ProcessInheritanceLink (Schema destModel, ClassDef child, ClassDef parent)
		{
			Table childTable = destModel.GetTable(child.TableName);
			Table parentTable = destModel.GetTable(parent.TableName);
			// create classifier if it was not created earlier
			if (parentTable.ContainColumn(InheritanceColumnName) == false)
			{
				// create table
				Table inheritanceClassifier = destModel.CreateTable(parentTable.Name + "_types");
				Column pk = inheritanceClassifier.CreateColumn(RefColumnName, "KEY");
				inheritanceClassifier.CreateColumn("child_table_name", "STRING");
				// create column
				Column inheritanceType = parentTable.CreateColumn();
				inheritanceType.Name = InheritanceColumnName;
				inheritanceType.SpecType = InheritanceColumnType;
				// create link (=constraint) from parent to classifier
				destModel.CreateLink(inheritanceType, pk);
			}
			// create link (=constraint) from child to parent
			var typeLinkManySide = childTable.CreateColumn(parentTable.Name + "_fk", "KEY");
			var typeLinkOneSide = parentTable.GetColumn (RefColumnName);
			destModel.CreateLink(typeLinkManySide, typeLinkOneSide);
			// insert row into classifier
			var row = parentTable.CreateRow();
			row ["child_table_name"].Value = childTable.Name;
		}
	}
}
