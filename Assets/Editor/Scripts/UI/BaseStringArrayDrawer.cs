using UnityEditor;
using UnityEngine;

namespace Editor.Scripts.UI {
	public class BaseStringArrayDrawer : BaseArrayDrawer {
		protected override void DrawEntry(SerializedProperty entryProperty, Rect rect) {
			EditorGUI.PropertyField(rect, entryProperty, GUIContent.none);
		}

		protected override void ResetEntry(SerializedProperty entryProperty) {
			entryProperty.stringValue = "";
		}
	}
}