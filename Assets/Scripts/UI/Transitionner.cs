using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class Transitionner : MonoBehaviour {
		[SerializeField] private Image fader;
		[SerializeField] private float fadeDuration;

		public static Transitionner Instance {
			get {
				var obj = GameObject.FindWithTag("Transitionner");

				return obj.GetComponent<Transitionner>();
			}
		} 

		public IEnumerator FadeIn() {
			yield return fader.DOColor(Color.clear, fadeDuration).WaitForCompletion();

			fader.gameObject.SetActive(false);
		}

		public IEnumerator FadeOut() {
			fader.gameObject.SetActive(true);
			
			yield return fader.DOColor(Color.black, fadeDuration).WaitForCompletion();
		}

		private void OnEnable() {
			StartCoroutine(FadeIn());
		}
	}
}