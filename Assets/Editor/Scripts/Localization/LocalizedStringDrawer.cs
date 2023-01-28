using System.Collections.Generic;
using System.Linq;
using Localization;
using UnityEditor;
using UnityEngine;

namespace Editor.Scripts.Localization {
	[CustomPropertyDrawer(typeof(LocalizedString))]
	public class LocalizedStringDrawer : PropertyDrawer {
		private Dictionary<string, SerializedProperty> textProperties;
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			if (textProperties == null) {
				GetTextProperties(property);
			}

			var languages = LocalizationManager.Instance.Languages;

			if (textProperties.Count == 0) {
				EditorGUI.LabelField(position, "There is no languages");
			}
			else {
				foreach (var entry in textProperties) {
					position.height = EditorGUIUtility.singleLineHeight;
					EditorGUI.LabelField(position, entry.Key);

					position.y += position.height + EditorGUIUtility.standardVerticalSpacing;
					position.height = 3 * EditorGUIUtility.singleLineHeight;
					EditorGUI.PropertyField(position, entry.Value, GUIContent.none);
					position.y += position.height + EditorGUIUtility.standardVerticalSpacing;
				}
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			if (textProperties == null || textProperties.Count == 0) return EditorGUIUtility.singleLineHeight;

			var height = 0f;

			foreach (var entry in textProperties) {
				height += 4 * EditorGUIUtility.singleLineHeight + 2 * EditorGUIUtility.standardVerticalSpacing;
			}

			return height;
		}

		private void GetTextProperties(SerializedProperty property) {
			var languages = LocalizationManager.Instance.Languages;
			var entriesProperty = property.FindPropertyRelative("entries");
			textProperties = new Dictionary<string, SerializedProperty>();

			for (var i = 0; i < entriesProperty.arraySize; i++) {
				var entryProperty = entriesProperty.GetArrayElementAtIndex(i);
				var languageProperty = entryProperty.FindPropertyRelative("language");

				if (!languages.Contains(languageProperty.stringValue)) {
					entriesProperty.DeleteArrayElementAtIndex(i);
					i--;
				}
				else {
					var textProperty = entryProperty.FindPropertyRelative("text");
					textProperties.Add(languageProperty.stringValue, textProperty);
				}
			}

			foreach (var language in languages) {
				if (textProperties.ContainsKey(language)) continue;

				entriesProperty.arraySize++;
				var entryProperty = entriesProperty.GetArrayElementAtIndex(entriesProperty.arraySize - 1);
				var languageProperty = entryProperty.FindPropertyRelative("language");
				languageProperty.stringValue = language;

				var textProperty = entryProperty.FindPropertyRelative("text");
				textProperties.Add(language, textProperty);
			}

			property.serializedObject.ApplyModifiedProperties();
		}
	}
}