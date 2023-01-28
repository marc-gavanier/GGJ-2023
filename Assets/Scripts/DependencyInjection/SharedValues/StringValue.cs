using UnityEngine;
using Utility.Events;

namespace DependencyInjection.SharedValues {
	[CreateAssetMenu(menuName = "GGJ/Values/String")]
	public class StringValue : BaseValue<string, StringEvent> {
		
	}
	
	public static partial class ScriptableObjectExtension {
		public static StringValue AddString(this ScriptableObject target, string name) => target.AddValue<StringValue>(name);
	}
}