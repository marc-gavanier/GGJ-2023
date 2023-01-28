using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DependencyInjection.SharedValues {
	public abstract class BaseValue<TValue, TEvent> : BaseConstValue<TValue> where TEvent : UnityEvent<TValue> {
		[SerializeField] private TEvent onChange;
		
		public TEvent OnChange => onChange;
		
		public override TValue Value {
			get => value;
			set {
				var oldValue = this.value;
				this.value = value;
				
				var comparer = Comparer<TValue>.Default;

				if (comparer.Compare(oldValue, value) != 0) {
					onChange.Invoke(value);
				}
			}
		}
	}
}