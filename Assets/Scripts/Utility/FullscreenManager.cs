using UnityEngine;

namespace Utility {
	public class FullscreenManager : ScriptableObject {
		public void SetFullscreenMode(bool isFullscreen) {
			Screen.fullScreen = isFullscreen;
		}
	}
}