using Editor.Scripts.Utility;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Utility;

namespace Editor.Scripts.UI {
	public abstract class BaseArrayDrawer : PropertyDrawer {
		private ReorderableList list;
		private SerializedProperty serializedProperty;
		private SerializedObject serializedObject;
		private bool showReference = false;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			return showReference ? EditorGUIUtility.singleLineHeight : (list?.GetHeight() ?? 0f);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			if (showReference || property.HasAttribute(typeof(ShowReferenceAttribute))) {
				showReference = true;
				EditorGUI.PropertyField(position, property, label);

				return;
			}
			
			if (list == null) {
				serializedObject = new SerializedObject(property.objectReferenceValue);
				serializedProperty = serializedObject.FindProperty("value");
				CreateList();
			}

			list?.DoList(position);
		}

		protected abstract void DrawEntry(SerializedProperty entryProperty, Rect rect);
		protected abstract void ResetEntry(SerializedProperty entryProperty);

		private void AddEntry(ReorderableList reorderableList) {
			serializedProperty.arraySize++;

			var entryProperty = serializedProperty.GetArrayElementAtIndex(serializedProperty.arraySize - 1);
			ResetEntry(entryProperty);

			serializedObject.ApplyModifiedProperties();
		}

		private void CreateList() {
			list = new ReorderableList(serializedObject, serializedProperty, true, true, true, true) {
				drawHeaderCallback = rect => EditorGUI.LabelField(rect, serializedProperty.displayName),
				drawElementCallback = DrawElementCallback,
				onAddCallback = AddEntry,
				onRemoveCallback = RemoveEntry,
				elementHeightCallback = ElementHeight
			};
		}

		private void DrawElementCallback(Rect rect, int index, bool isactive, bool isfocused) {
			var entryProperty = serializedProperty.GetArrayElementAtIndex(index);
			DrawEntry(entryProperty, rect);
			entryProperty.serializedObject.ApplyModifiedProperties();
		}

		private float ElementHeight(int index) {
			var element = serializedProperty.GetArrayElementAtIndex(index);

			return base.GetPropertyHeight(element, GUIContent.none);
		}

		private void RemoveEntry(ReorderableList reorderableList) {
			serializedProperty.DeleteArrayElementAtIndex(list.index);
			serializedProperty.serializedObject.ApplyModifiedProperties();
		}
	}
}