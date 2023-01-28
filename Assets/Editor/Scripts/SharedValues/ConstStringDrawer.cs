using DependencyInjection.SharedValues;
using Editor.Scripts.UI;
using UnityEditor;
using UnityEngine;

namespace Editor.Scripts.SharedValues {
	[CustomPropertyDrawer(typeof(ConstStringValue))]
	public class ConstStringDrawer : BaseConstDrawer {
	}
}