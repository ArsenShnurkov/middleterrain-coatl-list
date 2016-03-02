using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Eto.Parse;

namespace db_code_test
{
	[DebuggerDisplay("{GetDebuggerDisplay()}")]
	public class ClassDef
	{
		/// <summary>
		/// СList of parent classes
		/// </summary>
		ClassDefCollectionInClassDef inheritanceSpecification = new ClassDefCollectionInClassDef();

		public ClassDefCollection InheritanceSpecification {
			get {
				return inheritanceSpecification;
			}
		}

		public string ClassName { get; set; }

		public string TableName { get; set; }

		List<MemberDefAbstraction> members = new List<MemberDefAbstraction>();

		public IEnumerable<MemberDefAbstraction> Members
		{
			get
			{
				return members;
			}
		}

		public MemberDefAbstraction CreateMember(Match type, string name, string alias = null)
		{
			var member = new MemberDefRaw (this);
			member.Type = new MemberType(type);
			member.MemberName = name;
			members.Add (member);
			return member;
		}

		public MemberDefAbstraction CreateSetMember(ClassDef itemType, string name, string alias = null)
		{
			var member = new MemberDefSet (this);
			member.ItemType = itemType;
			member.MemberName = name;
			members.Add (member);
			return member;
		}

		public MemberDefAbstraction CreateArrayMember(ClassDef itemType, string name, string alias = null)
		{
			var member = new MemberDefArray (this);
			member.ItemType = itemType;
			member.MemberName = name;
			members.Add (member);
			return member;
		}

		public static List<ClassDef> GetListOfClasses (ClassDef c, bool IncludeSelf = true)
		{
			List<ClassDef> res = new List<ClassDef> ();
			if (IncludeSelf)
			{
				res.Add (c);
			}
			foreach (var parent in c.InheritanceSpecification)
			{
				if (res.Contains (parent) == false)
				{
					res.Add (parent);
				}
				var recursiveParents = GetListOfClasses (parent);
				foreach (var recParent in recursiveParents)
				{
					if (res.Contains (recParent) == false)
					{
						res.Add (recParent);
					}
				}
			}
			return res;
		}

		string GetDebuggerDisplay()
		{
			var res = new StringBuilder();
			res.AppendFormat("TABLE '{0}'", TableName);
			var list = GetListOfClasses (this, /*IncludeSelf = */false);
			for (int i = 0; i < list.Count; ++i)
			{
				if (i == 0)
				{
					res.Append(": ");
				}
				else
				{
					res.Append(", ");
				}
				res.AppendFormat("{0}", list[i].TableName);
			}
			return res.ToString();
		}
	}

	// commented out because not used
	/*public class ClassDefInAbstractModel : ClassDef
	{
		public AbstractModel AbstractModel { get; set; }
	}*/

	public class ClassDefInCollectionInClassDef : ClassDef
	{
		public ClassDefCollectionInClassDef Collection { get; set; }
		public ClassDef ClassDef
		{
			get
			{
				return Collection.ClassDef;
			}
		}
	}

	public class ClassDefInCollectionInAbstractModel : ClassDef
	{
		public ClassDefCollectionInAbstractModel Collection { get; set; }
		public AbstractModel AbstractModel
		{
			get
			{
				return Collection.AbstractModel;
			}
		}
	}

	public abstract class ClassDefCollection : IEnumerable<ClassDef>
	{
		/// <summary>
		/// Список классов, которые определяются моделью
		/// </summary>
		protected List<ClassDef> classes = new List<ClassDef>();

		public ClassDef this[string name]
		{
			get
			{
				for (int i = 0; i < classes.Count; ++i)
				{
					var c = classes [i];
					if (c.TableName == name)
					{
						return c;
					}
				}
				throw new ArgumentOutOfRangeException (nameof (name));
			}
		}

		public ClassDef this[int index]
		{
			get
			{
				return classes [index];
			}
		}

		public bool ContainsTableName(string name)
		{
			for (int i = 0; i < classes.Count; ++i)
			{
				if (classes [i].TableName == name)
				{
					return true;
				}
			}
			return false;
		}

		public int Count 
		{
			get
			{
				return classes.Count;
			}
		}

		public abstract ClassDef CreateClassDef ();

		public void Add(ClassDef c)
		{
			classes.Add (c);
		}

		IEnumerator<ClassDef> IEnumerable<ClassDef>.GetEnumerator ()
		{
			return classes.GetEnumerator ();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return classes.GetEnumerator ();
		}
	}
	public class ClassDefCollectionInAbstractModel : ClassDefCollection
	{
		public ClassDefCollectionInAbstractModel(AbstractModel abstractModel)
		{
			this.AbstractModel = abstractModel;
		}

		public AbstractModel AbstractModel { get; set; }

		public override ClassDef CreateClassDef()
		{
			var res = new ClassDefInCollectionInAbstractModel();
			res.Collection = this;
			classes.Add(res);
			return res;
		}
	}
	public class ClassDefCollectionInClassDef : ClassDefCollection
	{
		public ClassDef ClassDef { get; set; }

		public override ClassDef CreateClassDef()
		{
			var res = new ClassDefInCollectionInClassDef();
			res.Collection = this;
			classes.Add(res);
			return res;
		}
	}
}
