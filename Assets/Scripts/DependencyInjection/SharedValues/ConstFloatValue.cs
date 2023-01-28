using UnityEngine;

namespace DependencyInjection.SharedValues {
	[CreateAssetMenu(menuName = "GGJ/Values/Const Float")]
	public class ConstFloatValue : BaseConstValue<float> {

	}
	
	#if UNITY_EDITOR
	public static partial class ScriptableObjectExtension {
		public static ConstFloatValue AddConstFloat(this ScriptableObject target, string name) => target.AddValue<ConstFloatValue>(name);
	}
	#endif
}