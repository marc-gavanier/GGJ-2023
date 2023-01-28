using UnityEngine;

namespace Utility {
	public static class ServiceUtility {
		public static TService Find<TService>() where TService : ScriptableObject {
			var instances = Resources.FindObjectsOfTypeAll<TService>();
			
			return instances.Length == 0 ? null : instances[0];
		}
	}
}