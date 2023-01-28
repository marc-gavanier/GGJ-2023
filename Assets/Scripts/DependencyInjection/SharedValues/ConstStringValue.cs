using UnityEngine;

namespace DependencyInjection.SharedValues {
	[CreateAssetMenu(menuName = "GGJ/Values/Const String")]
	public class ConstStringValue : BaseConstValue<string> {
		
	}
	
	#if UNITY_EDITOR
	public static partial class ScriptableObjectExtension {
		public static ConstStringValue AddConstString(this ScriptableObject target, string name) => target.AddValue<ConstStringValue>(name);
	}
	#endif
}