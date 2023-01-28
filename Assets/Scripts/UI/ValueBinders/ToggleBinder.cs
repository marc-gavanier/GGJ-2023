using DependencyInjection.SharedValues;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI.ValueBinders {
	public class ToggleBinder : MonoBehaviour {
		[SerializeField, ShowReference] private BoolValue value;
		
		private Toggle toggle;

		private void Awake() {
			toggle = GetComponentInChildren<Toggle>();
			toggle.isOn = value;
			toggle.onValueChanged.AddListener(UpdateValue);
			value.OnChange.AddListener(ValueChanged);
		}

		private void OnDestroy() {
			value.OnChange.RemoveListener(ValueChanged);
		}

		private void UpdateValue(bool newValue) {
			value.Value = newValue;
		}

		private void ValueChanged(bool newValue) {
			toggle.isOn = newValue;
		}
	}
}