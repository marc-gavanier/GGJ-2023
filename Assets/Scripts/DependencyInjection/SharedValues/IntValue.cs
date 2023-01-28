using UnityEngine;
using Utility.Events;

namespace DependencyInjection.SharedValues {
	[CreateAssetMenu(menuName = "GGJ/Values/Int")]
	public class IntValue : BaseValue<int, IntEvent> {
		
	}
	
	public static partial class ScriptableObjectExtension {
		public static IntValue AddInt(this ScriptableObject target, string name) => target.AddValue<IntValue>(name);
	}
}