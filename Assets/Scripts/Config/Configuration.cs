using DependencyInjection.SharedValues;
using UnityEditor;
using UnityEngine;
using Utility;

namespace Config {
	public class Configuration : ScriptableObject {
		[SerializeReference] private StringValue language;
		[SerializeReference] private FloatValue masterVolume;
		[SerializeReference] private FloatValue sfxVolume;
		[SerializeReference] private FloatValue musicVolume;
		[SerializeReference] private BoolValue isFullscreen;

		#if UNITY_EDITOR
		public static class ConfigurationMenu {
			[MenuItem("Assets/Create/GGJ/Configuration", false)]
			private static void Create() {
				var configuration = ScriptableObject.CreateInstance<Configuration>();
				configuration.SaveAsset("Configuration");
				configuration.language = configuration.AddString("Language");
				configuration.masterVolume = configuration.AddFloat("MasterVolume");
				configuration.sfxVolume = configuration.AddFloat("SfxVolume");
				configuration.musicVolume = configuration.AddFloat("MusicVolume");
				configuration.isFullscreen = configuration.AddBool("IsFullscreen");
			}

			[MenuItem("Assets/Create/GGJ/Configuration", true)]
			private static bool ValidateCreate() {
				return SelectionUtility.IsFolder;
			}
		}
		#endif
	}
}