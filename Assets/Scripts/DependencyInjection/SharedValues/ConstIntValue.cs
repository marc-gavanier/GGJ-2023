using UnityEngine;

namespace DependencyInjection.SharedValues {
	[CreateAssetMenu(menuName = "GGJ/Values/Const Int")]
	public class ConstIntValue : BaseConstValue<int> {
		
	}
	
	public static partial class ScriptableObjectExtension {
		public static ConstIntValue AddConstInt(this ScriptableObject target, string name) => target.AddValue<ConstIntValue>(name);
	}
}