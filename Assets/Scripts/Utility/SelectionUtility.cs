using UnityEditor;

namespace Utility {
	#if UNITY_EDITOR
	public static class SelectionUtility {
		public static string CurrentFolder {
			get {
				var path = AssetDatabase.GetAssetPath(Selection.activeObject);

				return AssetDatabase.IsValidFolder(path) ? path : null;
			}
		}

		public static bool IsFolder => CurrentFolder != null;
	}
	#endif
}