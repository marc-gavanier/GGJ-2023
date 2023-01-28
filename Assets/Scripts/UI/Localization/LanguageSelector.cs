using System;
using DependencyInjection.SharedValues;
using Localization;
using TMPro;
using UnityEngine;
using Utility;

namespace UI.Localization {
	[RequireComponent(typeof(TMP_Dropdown))]
	public class LanguageSelector : MonoBehaviour {
		[SerializeField, ShowReference] private StringValue language;
		
		private void Awake() { 
			var dropdown = GetComponent<TMP_Dropdown>();
			var languages = LocalizationManager.Instance.Languages;
			dropdown.AddOptions(languages);

			if (string.IsNullOrWhiteSpace(language)) {
				language.Value = languages[0];
			}
			else {
				var index = languages.IndexOf(language);

				if (index == -1) {
					language.Value = languages[0];
				}
				else {
					dropdown.value = index;
				}
			}
			
			dropdown.onValueChanged.AddListener(delegate {
				language.Value = languages[dropdown.value];
			});
		}
	}
}