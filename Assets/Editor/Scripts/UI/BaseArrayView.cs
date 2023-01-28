using System.Collections.Generic;
using Editor.Scripts.Utility;
using UnityEditor;
using UnityEngine.UIElements;

namespace Editor.Scripts.UI {
	public abstract class BaseArrayView : VisualElement {
		
		protected virtual float ItemHeight => EditorGUIUtility.singleLineHeight;

		private readonly SerializedProperty entriesProperty;
		
		protected List<SerializedProperty> entries;

		public BaseArrayView(SerializedProperty property, string label) {
			entriesProperty = property;
			entries = property.Entries();

			var labelElement = new Label(label);
			Add(labelElement);
			
			var listView = new ListView(entries, ItemHeight, MakeItem, BindItem);
			listView.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
			listView.showBorder = true;
			listView.reorderMode = ListViewReorderMode.Animated;
			listView.reorderable = true;
			listView.showAddRemoveFooter = true;
			listView.selectionType = SelectionType.Multiple;
			listView.itemsAdded += MakeNewEntries;
			listView.itemsRemoved += RemoveEntries;
			listView.itemIndexChanged += SwitchEntries;
			
			Add(listView);
		}

		protected abstract void BindItem(VisualElement entry, int index);

		protected abstract VisualElement MakeItem();

		protected abstract void ResetEntry(SerializedProperty entryProperty);


		private void MakeNewEntries(IEnumerable<int> indexes) {
			foreach (var index in indexes) {
				entriesProperty.InsertArrayElementAtIndex(index);
				var entryProperty = entriesProperty.GetArrayElementAtIndex(index);
				ResetEntry(entryProperty);
			}

			entriesProperty.serializedObject.ApplyModifiedProperties();
			RefreshEntries();
		}

		private void RefreshEntries() {
			entries = entriesProperty.Entries();
		}

		private void RemoveEntries(IEnumerable<int> indexes) {
			var dIndex = 0;

			foreach (var index in indexes) {
				entriesProperty.DeleteArrayElementAtIndex(index - dIndex);
				dIndex++;
			}

			entriesProperty.serializedObject.ApplyModifiedProperties();
			RefreshEntries();
		}

		private void SwitchEntries(int oldIndex, int newIndex) {
			entriesProperty.MoveArrayElement(oldIndex, newIndex);
			entriesProperty.serializedObject.ApplyModifiedProperties();
			RefreshEntries();
		}
	}
}