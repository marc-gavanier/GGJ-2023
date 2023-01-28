using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Editor.Scripts.Utility {
	public static class SerializedPropertyExtension {
		public static List<SerializedProperty> Entries(this SerializedProperty property) {
			Debug.Assert(property.isArray, $"{property.name} is not an array");

			var entries = new List<SerializedProperty>();

			for (var i = 0; i < property.arraySize; i++) {
				entries.Add(property.GetArrayElementAtIndex(i));
			}

			return entries;
		}

		public static bool HasAttribute(this SerializedProperty property, Type attributeType) {
			var objectType = property.serializedObject.targetObject.GetType();
			var field = objectType.GetField(property.name, (BindingFlags)(-1));
			Debug.Assert(field != null, $"Missing field {property.name} in {objectType.FullName}");
			var attributes = field.GetCustomAttributes(attributeType, false);

			return attributes.Length > 0;
		}
	}
}