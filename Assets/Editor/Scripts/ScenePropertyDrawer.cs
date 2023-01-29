using Scenes;
using UnityEditor;
using UnityEngine;

namespace Editor.Scripts {
	[CustomPropertyDrawer(typeof(SceneAttribute))]
	public class ScenePropertyDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			var scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(property.stringValue);
			
			EditorGUI.BeginChangeCheck();
			scene = EditorGUI.ObjectField(position, label, scene, typeof(SceneAsset), false) as SceneAsset;

			if (EditorGUI.EndChangeCheck()) {
				property.stringValue = AssetDatabase.GetAssetPath(scene);
			}
		}
	}
}