using UnityEngine;

namespace DependencyInjection.SharedValues {
	[CreateAssetMenu(menuName = "GGJ/Values/Const String Array")]
	public class ConstStringArray : BaseConstArray<string> {
		
	}
	
	#if UNITY_EDITOR
	public static partial class ScriptableObjectExtension {
		public static ConstStringArray AddConstStringArray(this ScriptableObject target, string name) => target.AddValue<ConstStringArray>(name);
	}
	#endif
}