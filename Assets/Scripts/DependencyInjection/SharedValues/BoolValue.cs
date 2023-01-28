﻿using UnityEngine;
using Utility.Events;

namespace DependencyInjection.SharedValues {
	[CreateAssetMenu(menuName = "GGJ/Values/Bool")]
	public class BoolValue : BaseValue<int, IntEvent> {
		
	}
	
	public static partial class ScriptableObjectExtension {
		public static BoolValue AddBool(this ScriptableObject target, string name) => target.AddValue<BoolValue>(name);
	}
}