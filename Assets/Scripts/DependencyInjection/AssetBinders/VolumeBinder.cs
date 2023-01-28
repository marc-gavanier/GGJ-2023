using DependencyInjection.SharedValues;
using UnityEngine;
using UnityEngine.Audio;
using Utility;

namespace DependencyInjection.AssetBinders {
	[CreateAssetMenu(menuName = "GGJ/Asset Binders/Volume Binder")]
	public class VolumeBinder : BaseAssetBinder<float> {
		[SerializeField] private AudioMixerGroup mixerGroup;

		public override float Value {
			get {
				mixerGroup.audioMixer.GetFloat(mixerGroup.name, out var volume);

				return volume;
			}
			set => mixerGroup.audioMixer.SetFloat(mixerGroup.name, value);
		}
	}
}