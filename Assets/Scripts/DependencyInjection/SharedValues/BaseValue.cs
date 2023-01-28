using System.Collections.Generic;
using DependencyInjection.AssetBinders;
using UnityEngine;
using UnityEngine.Events;

namespace DependencyInjection.SharedValues {
	public abstract class BaseValue<TValue, TEvent> : BaseConstValue<TValue> where TEvent : UnityEvent<TValue> {
		[SerializeField] private TEvent onChange;
		[SerializeField] private BaseAssetBinder<TValue> assetBinder;

		public TEvent OnChange => onChange;
		
		public override TValue Value {
			get => value;
			set {
				var oldValue = this.value;
				this.value = value;
				
				var comparer = Comparer<TValue>.Default;

				if (comparer.Compare(oldValue, value) != 0) {
					onChange.Invoke(value);

					if (assetBinder != null) {
						assetBinder.Value = value;
					}
				}
			}
		}

		protected override void OnEnable() {
			base.OnEnable();

			if (assetBinder != null) {
				value = assetBinder.Value;
			}
		}
	}
}