using UnityEngine;

namespace Utility {
	public static class ServiceUtility {
		public static TService Find<TService>() where TService : ScriptableObject {
			var instances = Resources.FindObjectsOfTypeAll<TService>();
			Debug.Assert(instances.Length > 0, $"This is no {(typeof(TService)).Name}");
			Debug.Assert(instances.Length == 1, $"There is multiple {(typeof(TService)).Name}");
			
			return instances[0];
		}
	}
}