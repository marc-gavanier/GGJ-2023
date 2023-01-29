using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes {
	[RequireComponent(typeof(Button))]
	public class SceneSwitchButton : MonoBehaviour {
		[SerializeField, Scene] private string scene;
		
		private void Awake() {
			var button = GetComponent<Button>();
			button.onClick.AddListener(() => StartCoroutine(SwitchScene()));
		}

		public IEnumerator SwitchScene() {
			yield return SceneLoader.Instance.Load(scene);
		} 
	}
}