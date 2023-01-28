using UnityEditor;
using UnityEngine;

namespace DependencyInjection.SharedValues {
	#if UNITY_EDITOR
	public static partial class ScriptableObjectExtension {
		public static TValue AddValue<TValue>(this ScriptableObject target, string name) where TValue : ScriptableObject {
			var value = ScriptableObject.CreateInstance<TValue>();
			value.name = name;
			AssetDatabase.AddObjectToAsset(value, target);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();

			return value;
		}
	}
	#endif
}