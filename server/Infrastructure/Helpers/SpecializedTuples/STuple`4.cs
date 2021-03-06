using System;
using System.Collections.Generic;
using System.Text;

namespace Brainvest.Dscribe.Helpers.SpecializedTuples
{
	public class STuple<T1, T2, T3, T4> : IEquatable<STuple<T1, T2, T3, T4>>
	{
		public T1 Item1 { get; set; }
		public T2 Item2 { get; set; }
		public T3 Item3 { get; set; }
		public T4 Item4 { get; set; }

		public bool Equals(STuple<T1, T2, T3, T4> b)
		{
			return b != null &&
				((Item1 == null && b.Item1 == null) || EqualityComparer<T1>.Default.Equals(Item1, b.Item1)) &&
				((Item2 == null && b.Item2 == null) || EqualityComparer<T2>.Default.Equals(Item2, b.Item2)) &&
				((Item3 == null && b.Item3 == null) || EqualityComparer<T3>.Default.Equals(Item3, b.Item3)) &&
				((Item4 == null && b.Item4 == null) || EqualityComparer<T4>.Default.Equals(Item4, b.Item4));
		}

		public override bool Equals(object obj)
		{
			return (obj is STuple<T1, T2, T3, T4> b) && this.Equals(b);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hash = 17;
				hash = hash * 23 + (Item1 == null ? 0 : Item1.GetHashCode());
				hash = hash * 23 + (Item2 == null ? 0 : Item2.GetHashCode());
				hash = hash * 23 + (Item3 == null ? 0 : Item3.GetHashCode());
				hash = hash * 23 + (Item4 == null ? 0 : Item4.GetHashCode());
				return hash;
			}
		}

		public static bool operator ==(STuple<T1, T2, T3, T4> a, STuple<T1, T2, T3, T4> b)
		{
			if (a == null)
			{
				return b == null;
			}
			return a.Equals(b);
		}

		public static bool operator !=(STuple<T1, T2, T3, T4> a, STuple<T1, T2, T3, T4> b)
		{
			return !(a == b);
		}
	}
}