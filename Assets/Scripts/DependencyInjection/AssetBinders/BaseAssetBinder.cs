using UnityEngine;

namespace DependencyInjection.AssetBinders {
	public abstract class BaseAssetBinder<TValue> : ScriptableObject {
		public abstract TValue Value { get; set; }
	}
}