using DependencyInjection.SharedValues;
using Editor.Scripts.UI;
using UnityEditor;

namespace Editor.Scripts.SharedValues {
	[CustomPropertyDrawer(typeof(ConstStringArray))]
	public class ConstStringArrayDrawerDrawer : BaseStringArrayDrawer {
	}
}