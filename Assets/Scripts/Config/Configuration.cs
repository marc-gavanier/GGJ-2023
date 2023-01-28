using DependencyInjection.SharedValues;
using UnityEditor;
using UnityEngine;
using Utility;

namespace Config {
	public class Configuration : ScriptableObject {
		[SerializeReference] private StringValue language;

		[MenuItem("Assets/Create/GGJ/Configuration", false)]
		private static void Create() {
			var configuration = ScriptableObject.CreateInstance<Configuration>();
			configuration.SaveAsset("Configuration");
			configuration.language = configuration.AddString("Language");
		}

		[MenuItem("Assets/Create/GGJ/Configuration", true)]
		private static bool ValidateCreate() {
			return SelectionUtility.IsFolder;
		}
	}
}