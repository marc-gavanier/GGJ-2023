using System;
using UnityEditor;
using UnityEngine;

namespace DependencyInjection.SharedValues {
	[Serializable]
	public abstract class BaseConstValue<TValue> : ScriptableObject { 
		[SerializeField] protected TValue value;

		#if UNITY_EDITOR
		[NonSerialized] private TValue initValue;
		#endif

		public virtual TValue Value {
			get => value;
			set => throw new InvalidOperationException();
		}

		public static implicit operator TValue(BaseConstValue<TValue> baseSharedConstValue) => baseSharedConstValue.value;

		protected virtual void OnEnable() {
			#if UNITY_EDITOR
			if (value is not Array) {
				EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
				initValue = value;
				EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
			}
			#endif
		}
		
		#if UNITY_EDITOR
		private void OnPlayModeStateChanged(PlayModeStateChange change) {
			if (change != PlayModeStateChange.ExitingPlayMode) return;
			
			value = initValue;
			EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
		}
		#endif
	}
}