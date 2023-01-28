using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection.SharedValues {
	public abstract class BaseConstArray<TValue> : BaseConstValue<TValue[]>, IEnumerable<TValue> {
		public static implicit operator List<TValue>(BaseConstArray<TValue> array) => array.value.ToList();

		public TValue this[int index] => value[index];
		
		public IEnumerator<TValue> GetEnumerator() {
			return value.Cast<TValue>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public int IndexOf(TValue searchValue) {
			var comparer = EqualityComparer<TValue>.Default;
			var index = 0;

			foreach (var entry in value) {
				if (comparer.Equals(entry, searchValue)) return index;

				index++;
			}

			return -1;
		}
	}
}