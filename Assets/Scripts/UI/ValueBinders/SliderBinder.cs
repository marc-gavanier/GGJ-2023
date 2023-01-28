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
		}

		private void UpdateValue(float newValue) {
			value.Value = newValue;
		}
	}
}