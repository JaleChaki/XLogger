using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLogger.Tests {
	internal static class TestUtils {

		private static readonly Random Random = new Random();

		public static string GenerateString(int stringLength = 64) {
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < 64; ++i) {
				result.Append((char)Random.Next(256));
			}
			return result.ToString();
		}

	}
}
