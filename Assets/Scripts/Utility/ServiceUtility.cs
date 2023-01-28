using System;
using UnityEditor;
using UnityEngine;

namespace Utility {
	public static class ServiceUtility {
		public static TService Find<TService>() where TService : ScriptableObject {
			var serviceType = typeof(TService);
			var guids = AssetDatabase.FindAssets($"t:{serviceType.Name}");
			Debug.Assert(guids.Length > 0, $"This is no {serviceType.Name}");
			Debug.Assert(guids.Length == 1, $"There is multiple {serviceType.Name}");

			var path = AssetDatabase.GUIDToAssetPath(guids[0]);

			return AssetDatabase.LoadAssetAtPath(path, serviceType) as TService;
		}
	}
}