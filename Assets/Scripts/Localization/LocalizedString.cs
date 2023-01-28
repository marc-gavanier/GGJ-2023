using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Localization {
	[Serializable]
	public class LocalizedString {
		[Serializable]
		public class Entry {
			[SerializeField] private string language;
			[SerializeField] private string text;

			public string Language => language;

			public string Text => text;
		}

		[SerializeField] private List<Entry> entries;

		public string this[string language] {
			get {
				var entry = entries.FirstOrDefault(e => e.Language == language);

				return entry?.Text ?? "(Missing Translation)";
			}
		}
	}
}