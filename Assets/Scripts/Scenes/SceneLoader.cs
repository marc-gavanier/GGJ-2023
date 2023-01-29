using System.Collections;
using UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Scenes {
	public class SceneLoader : ScriptableObject {
		private const string Path = "Services/SceneLoader";
		
		private static SceneLoader instance;
		
		public static SceneLoader Instance => instance ??= Resources.Load<SceneLoader>(Path);

		public IEnumerator Load(string path) {
			yield return Transitionner.Instance.FadeOut();
			
			SceneManager.LoadScene(path);
		}

#if UNITY_EDITOR
		[MenuItem("Assets/Create/GGJ/Services/Scene Loader", false)]
		public static void Create() {
			var sceneLoader = ScriptableObject.CreateInstance<SceneLoader>();
			sceneLoader.SaveAsset("SceneLoader");
		}
		
		[MenuItem("Assets/Create/GGJ/Services/Scene Loader", true)]
		public static bool ValidateCreate() {
			return SelectionUtility.IsFolder && Instance == null;
		}
#endif
	}
}