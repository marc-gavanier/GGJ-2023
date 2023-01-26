using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Game.SceneManagement {
	public class SceneLoader : MonoBehaviour {
		[SerializeField, Scene] private string scene;

		public void Load() {
			Debug.Assert(!string.IsNullOrWhiteSpace(scene), $"Scene loader {name} is missing scene");

			SceneManager.LoadScene(scene);
		}
	}
}