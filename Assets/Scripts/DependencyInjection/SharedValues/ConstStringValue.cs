using UnityEngine;

namespace DependencyInjection.SharedValues {
	[CreateAssetMenu(menuName = "GGJ/Values/Const String")]
	public class ConstStringValue : BaseConstValue<string> {
		
	}
	
	public static partial class ScriptableObjectExtension {
		public static ConstStringValue AddConstString(this ScriptableObject target, string name) => target.AddValue<ConstStringValue>(name);
	}
}