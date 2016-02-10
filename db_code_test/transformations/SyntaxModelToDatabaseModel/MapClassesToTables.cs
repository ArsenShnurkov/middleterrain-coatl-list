using System;
using Deveel.Math;

namespace db_code_test
{
	public partial class SyntaxModelToDatabaseModel
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
			var listOfClasses = ClassDef.GetListOfClasses (c);
			foreach (ClassDef classDef in listOfClasses)
			{
				foreach (var m in classDef.Members)
				{
					if (m is MemberDefRaw)
					{
						var mr = m as MemberDefRaw;
						var column = table.CreateColumn();
						column.SpecType = GetDatabaseTypeFromSyntaxType(mr.Type);
						column.Name = m.MemberName;
					}
					else
					{
						throw new NotImplementedException("sets and arrays are not implemented yet");
					}
				}
			}
		}

		/// <summary>
		/// Gets the database type from syntax type
		/// </summary>
		/// <returns>type of column in the abstract database model</returns>
		/// <remarks>>
		/// INTEGER, RATIONAL, STRING, DATE
		/// </remarks>
		public string GetDatabaseTypeFromSyntaxType(Type type)
		{
			if (type == typeof(string))
			{
				return "STRING";
			}
			if (type == typeof(BigInteger))
			{
				return "INTEGER";
			}
			if (type == typeof(Rational))
			{
				return "RATIONAL";
			}
			if (type == typeof(DateTime))
			{
				return "DATE";
			}
			throw new NotImplementedException("unimplemented type");
		}
	}
}

