using System;
using System.IO;
using System.Text;

namespace XLogger.Tests {
	internal static class TestUtils {

		private static readonly Random Random = new Random();

		public static string GenerateString(int stringLength = 64) {
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < stringLength; ++i) {
				result.Append((char)Random.Next(256));
			}
			return result.ToString();
		}

		public static void ClearSpace() {
			if (File.Exists("log.log")) {
				File.Delete("log.log");
			}
		}

		public static bool FileContainsString(string searchStr, string filename = "log.log") {
			return File.ReadAllText(filename).Contains(searchStr);
		}

	}
}
