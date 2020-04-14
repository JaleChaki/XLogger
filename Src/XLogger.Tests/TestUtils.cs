using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XLogger.LogMethods;

namespace XLogger.Tests {
	internal static class TestUtils {

		internal class TestableLogMethod : ILogMethod {

			public delegate void WritedEvent(FormattedLogMessage msg);

			public event WritedEvent Callback;

			public List<FormattedLogMessage> WritedLogs;

			public TestableLogMethod() {
				WritedLogs = new List<FormattedLogMessage>();
			}

			public void Write(FormattedLogMessage log) {
				Callback?.Invoke(log);
				WritedLogs.Add(log);
			}
		}

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
			if (!File.Exists(filename)) {
				return false;
			}
			return File.ReadAllText(filename).Contains(searchStr);
		}

	}
}
