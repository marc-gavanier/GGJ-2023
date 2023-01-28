using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DependencyInjection.SharedValues {
	public abstract class BaseValue<TValue, TEvent> : BaseConstValue<TValue> where TEvent : UnityEvent<TValue> {
		[SerializeField] private TEvent onChange;

		private Comparer<TValue> comparer;

		public TEvent OnChange => onChange;
		
		public override TValue Value {
			get => value;
			set {
				var oldValue = this.value;
				this.value = value;

				if (comparer.Compare(oldValue, value) != 0) {
					onChange.Invoke(value);
				}
			}
		}

		protected override void OnEnable() {
			base.OnEnable();
			
			comparer = Comparer<TValue>.Default;
		}
	}
}