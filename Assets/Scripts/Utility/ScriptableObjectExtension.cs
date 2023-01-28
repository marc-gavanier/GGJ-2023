﻿using UnityEditor;
using UnityEngine;

namespace Utility {
	public static class ScriptableObjectExtension {
		public static void SaveAsset(this ScriptableObject asset, string name) {
			var path = AssetDatabase.GenerateUniqueAssetPath($"{SelectionUtility.CurrentFolder}/{name}.asset");
			AssetDatabase.CreateAsset(asset, path);
			AssetDatabase.SaveAssets();
			EditorUtility.FocusProjectWindow();
			ProjectWindowUtil.ShowCreatedAsset(asset);
		}
	}
}