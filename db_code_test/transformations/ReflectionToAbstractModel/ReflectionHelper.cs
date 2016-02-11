using System;
using Deveel.Math;

namespace db_code_test
{
	public class ReflectionHelper
	{
		/// <summary>
		/// Gets the database type from syntax type
		/// </summary>
		/// <returns>type of column in the abstract database model</returns>
		/// <remarks>>
		/// INTEGER, RATIONAL, STRING, DATE
		/// </remarks>
		public static string GetDatabaseTypeFromSyntaxType(Type type)
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

