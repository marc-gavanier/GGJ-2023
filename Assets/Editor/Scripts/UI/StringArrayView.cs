using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Editor.Scripts.UI {
	public class StringArrayView : BaseArrayView {
		public StringArrayView(SerializedProperty property, string label) : base(property, label) {
		}

		protected override void BindItem(VisualElement entry, int index) {
			var property = entries[index];
			var valueField = entry.Q<TextField>("value");
			valueField.BindProperty(property);
		}

		protected override VisualElement MakeItem() {
			var root = new VisualElement();
			var valueField = new TextField {
				name = "value"
			};
			root.Add(valueField);

			return root;
		}

		protected override void ResetEntry(SerializedProperty entryProperty) {
			entryProperty.stringValue = "";
		}
	}
}