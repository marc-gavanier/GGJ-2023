using UnityEngine;

namespace DependencyInjection.SharedValues {
	[CreateAssetMenu(menuName = "GGJ/Values/Const Bool")]
	public class ConstBoolValue : BaseConstValue<bool> {

	}
	
	public static partial class ScriptableObjectExtension {
		public static ConstBoolValue AddConstBool(this ScriptableObject target, string name) => target.AddValue<ConstBoolValue>(name);
	}
}