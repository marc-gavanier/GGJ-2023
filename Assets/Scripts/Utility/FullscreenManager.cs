using Localization;
using UnityEditor;
using UnityEngine;

namespace Utility {
	public class FullscreenManager : ScriptableObject {
		public void SetFullscreenMode(bool isFullscreen) {
			Screen.fullScreen = isFullscreen;
		}
		
#if UNITY_EDITOR
		[MenuItem("Assets/Create/GGJ/Services/Fullscreen Manager", false)]
		public static void Create() {
			var localizationManager = ScriptableObject.CreateInstance<FullscreenManager>();
			localizationManager.SaveAsset("FullscreenManager");
		}
		
		[MenuItem("Assets/Create/GGJ/Services/Fullscreen Manager", true)]
		public static bool ValidateCreate() {
			return SelectionUtility.IsFolder && ServiceUtility.Find<FullscreenManager>() == null;
		}
#endif
	}
}