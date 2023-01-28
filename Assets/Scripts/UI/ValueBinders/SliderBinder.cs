using DependencyInjection.SharedValues;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI.ValueBinders {
	[DisallowMultipleComponent]
	public class SliderBinder : MonoBehaviour {
		[SerializeField, ShowReference] private FloatValue value;

		private Slider slider;

		private void Awake() {
			slider = GetComponentInChildren<Slider>();
			slider.value = value;
			slider.onValueChanged.AddListener(UpdateValue);
			value.OnChange.AddListener(ValueChanged);
		}

		private void OnDestroy() {
			value.OnChange.RemoveListener(ValueChanged);
		}

		private void UpdateValue(float newValue) {
			value.Value = newValue;
		}

		private void ValueChanged(float newValue) {
			slider.value = newValue;
		}
	}
}