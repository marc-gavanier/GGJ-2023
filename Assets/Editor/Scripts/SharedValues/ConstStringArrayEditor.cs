using DependencyInjection.SharedValues;
using Editor.Scripts.UI;
using UnityEditor;
using UnityEngine.UIElements;

namespace Editor.Scripts.SharedValues {
	[CustomEditor(typeof(ConstStringArray))]
	public class ConstStringArrayEditor : UnityEditor.Editor {
		public override VisualElement CreateInspectorGUI() {
			var root = new VisualElement();
			
			var valueProperty = serializedObject.FindProperty("value");
			var valueField = new StringArrayView(valueProperty, serializedObject.targetObject.name);
			root.Add(valueField);

			return root;
		}
	}
}