using System;
using System.Data.Common;

namespace db_code_test
{
	public class NonspecificDbCommand : DbCommand
	{
		NonspecificDbParameterCollection parameters;

		public NonspecificDbCommand ()
		{
			parameters = new NonspecificDbParameterCollection ();
		}

		#region implemented abstract members of DbCommand

		public override string CommandText { get; set; }

		protected override DbParameterCollection DbParameterCollection {
			get {
				return parameters;
			}
		}

		public override void Cancel ()
		{
			throw new NotImplementedException ();
		}

		protected override DbParameter CreateDbParameter ()
		{
			throw new NotImplementedException ();
		}

		protected override DbDataReader ExecuteDbDataReader (System.Data.CommandBehavior behavior)
		{
			throw new NotImplementedException ();
		}

		public override int ExecuteNonQuery ()
		{
			throw new NotImplementedException ();
		}

		public override object ExecuteScalar ()
		{
			throw new NotImplementedException ();
		}

		public override void Prepare ()
		{
			throw new NotImplementedException ();
		}

		public override int CommandTimeout {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public override System.Data.CommandType CommandType {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		protected override DbConnection DbConnection {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		protected override DbTransaction DbTransaction {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public override bool DesignTimeVisible {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public override System.Data.UpdateRowSource UpdatedRowSource {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		#endregion
	}
}

