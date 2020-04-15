using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XLogger.Formatters.PropertyNamingStrategies {
	public static class PropertyNameParser {

		private static string[] ParseInternalWord(string word) {
			StringBuilder wordBuilder = new StringBuilder();
			List<string> result = new List<string>();
			for (int i = 0; i < word.Length; ++i) {
				if (char.IsUpper(word[i])) {
					if (wordBuilder.Length > 0) {
						result.Add(wordBuilder.ToString());
					}
					wordBuilder
						.Clear()
						.Append(word[i]);
				} else {
					wordBuilder.Append(word[i]);
				}
			}
			if (wordBuilder.Length > 0) {
				result.Add(wordBuilder.ToString());
			}
			List<string> outedResult = new List<string>();
			wordBuilder.Clear();
			for (int i = 0; i < result.Count; ++i) {
				if (result[i].Length > 1) {
					if (wordBuilder.Length > 0) {
						outedResult.Add(wordBuilder.ToString());
						wordBuilder.Clear();
					}
					outedResult.Add(result[i]);
				}
				if (result[i].Length == 1) {
					wordBuilder.Append(result[i]);
				}
			}
			if (wordBuilder.Length > 0) {
				outedResult.Add(wordBuilder.ToString());
				wordBuilder.Clear();
			}
			return outedResult.ToArray();
		}

		public static string[] Parse(string propertyName) {
			return propertyName
				.Split(' ', '_', '-')
				.Where(x => x.Length != 0)
				.SelectMany(x => ParseInternalWord(x))
				.Select(x => x.ToLower())
				.ToArray();
		}

		public static string ParseWordAsPascalCase(string word) {
			if (string.IsNullOrEmpty(word)) {
				return string.Empty;
			}
			var result = new StringBuilder(word.ToLower());
			result[0] = char.ToUpper(word[0]);
			return result.ToString();
		}

	}
}
