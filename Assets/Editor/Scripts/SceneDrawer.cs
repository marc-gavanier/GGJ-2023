using UnityEditor;
using UnityEngine;
using Utility;

namespace Editor {
	[UnityEditor.CustomPropertyDrawer(typeof(SceneAttribute))]
	public class SceneDrawer : UnityEditor.PropertyDrawer {
		public override void OnGUI(Rect position, UnityEditor.SerializedProperty property, UnityEngine.GUIContent label) {
			var scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(property.stringValue);
			
			EditorGUI.BeginChangeCheck();
			scene = EditorGUI.ObjectField(position, scene, typeof(SceneAsset), false) as SceneAsset;

			if (EditorGUI.EndChangeCheck()) {
				property.stringValue = AssetDatabase.GetAssetPath(scene);
			}
		}
	}
}