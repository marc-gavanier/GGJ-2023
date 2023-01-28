using UnityEditor;

namespace Utility {
	public static class SelectionUtility {
		public static string CurrentFolder {
			get {
				var path = AssetDatabase.GetAssetPath(Selection.activeObject);

				return AssetDatabase.IsValidFolder(path) ? path : null;
			}
		}

		public static bool IsFolder => CurrentFolder != null;
	}
}