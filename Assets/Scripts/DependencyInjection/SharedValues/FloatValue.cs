using UnityEngine;
using Utility.Events;

namespace DependencyInjection.SharedValues {
	[CreateAssetMenu(menuName = "GGJ/Values/Float")]
	public class FloatValue : BaseValue<float, FloatEvent> {
		
	}
	
	#if UNITY_EDITOR
	public static partial class ScriptableObjectExtension {
		public static FloatValue AddFloat(this ScriptableObject target, string name) => target.AddValue<FloatValue>(name);
	}
	#endif
}