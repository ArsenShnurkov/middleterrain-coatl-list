using System;
using System.Data.Common;

namespace db_code_test
{
	public class NonspecificDbParameterCollection : DbParameterCollection
	{
		public NonspecificDbParameterCollection ()
		{
		}

		#region implemented abstract members of DbParameterCollection

		public override int Count {
			get {
				return 0;
			}
		}

		public override int Add (object value)
		{
			throw new NotImplementedException ();
		}

		public override void AddRange (System.Array values)
		{
			throw new NotImplementedException ();
		}

		public override bool Contains (object value)
		{
			throw new NotImplementedException ();
		}

		public override bool Contains (string value)
		{
			throw new NotImplementedException ();
		}

		public override void CopyTo (System.Array array, int index)
		{
			throw new NotImplementedException ();
		}

		public override void Clear ()
		{
			throw new NotImplementedException ();
		}

		public override System.Collections.IEnumerator GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		protected override DbParameter GetParameter (int index)
		{
			throw new NotImplementedException ();
		}

		protected override DbParameter GetParameter (string parameterName)
		{
			throw new NotImplementedException ();
		}

		public override int IndexOf (object value)
		{
			throw new NotImplementedException ();
		}

		public override int IndexOf (string parameterName)
		{
			throw new NotImplementedException ();
		}

		public override void Insert (int index, object value)
		{
			throw new NotImplementedException ();
		}

		public override void Remove (object value)
		{
			throw new NotImplementedException ();
		}

		public override void RemoveAt (int index)
		{
			throw new NotImplementedException ();
		}

		public override void RemoveAt (string parameterName)
		{
			throw new NotImplementedException ();
		}

		protected override void SetParameter (int index, DbParameter value)
		{
			throw new NotImplementedException ();
		}

		protected override void SetParameter (string parameterName, DbParameter value)
		{
			throw new NotImplementedException ();
		}

		public override object SyncRoot {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion
	}
}

