using DependencyInjection.SharedValues;
using Localization;
using TMPro;
using UnityEngine;
using Utility;

namespace UI.Localization {
	public class LocalizedLabel : MonoBehaviour {
		[SerializeField] private LocalizedString localizedString;
		[SerializeField, ShowReference] private StringValue language;

		private TMP_Text label;

		private void Awake() {
			label = GetComponentInChildren<TMP_Text>();
			Debug.Assert(label != null, $"{name} does not have a TMP_Text");
			UpdateText(language);
			language.OnChange.AddListener(UpdateText);
		}

		private void UpdateText(string newLanguage) {
			label.text = localizedString[newLanguage];
		}
	}
}