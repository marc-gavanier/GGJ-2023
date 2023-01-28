using Editor.Scripts.Utility;
using UnityEditor;
using UnityEngine;
using Utility;

namespace Editor.Scripts.UI {
	public class BaseConstDrawer : PropertyDrawer {
		private SerializedObject serializedObject;
		private SerializedProperty serializedProperty;
		private bool showReference;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			if (showReference) return base.GetPropertyHeight(property, label);

			if (serializedProperty == null) return 0f;

			return base.GetPropertyHeight(serializedProperty, label);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			if (showReference || property.HasAttribute(typeof(ShowReferenceAttribute))) {
				showReference = true;
				EditorGUI.PropertyField(position, property, label);

				return;
			}

			if (serializedProperty == null) {
				serializedObject = new SerializedObject(property.objectReferenceValue);
				serializedProperty = serializedObject.FindProperty("value");
			}

			EditorGUI.PropertyField(position, serializedProperty, label);
		}
	}
}