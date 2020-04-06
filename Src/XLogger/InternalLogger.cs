using System;
using System.Collections.Generic;
using System.Text;

namespace Logging {
	internal static class InternalLogger {

		public static void LogString(string log, LogLevel level) {

		}

		public static void LogException(Exception e, LogLevel level) {

		}

		public static void LogObject(object obj, LogLevel level) {
			if (obj is Exception e) {
				LogException(e, level);
				return;
			}

		}

	}
}
