using System.Collections.Generic;
using DependencyInjection.SharedValues;
using UnityEditor;
using UnityEngine;
using Utility;

namespace Localization {
	public class LocalizationManager : ScriptableObject {
		private static LocalizationManager instance;
		
		[SerializeReference] private ConstStringArray languages;

		public static LocalizationManager Instance => instance ??= ServiceUtility.Find<LocalizationManager>();

		public ConstStringArray Languages => languages;

		[MenuItem("Assets/Create/GGJ/Services/Localization Manager", false)]
		public static void Create() {
			var localizationManager = ScriptableObject.CreateInstance<LocalizationManager>();
			localizationManager.SaveAsset("LocalizationManager");
			localizationManager.languages = localizationManager.AddConstStringArray("Languages");
		}

		[MenuItem("Assets/Create/GGJ/Services/Localization Manager", true)]
		public static bool ValidateCreate() {
			return SelectionUtility.IsFolder && Resources.FindObjectsOfTypeAll<LocalizationManager>().Length == 0;
		}
	}
}