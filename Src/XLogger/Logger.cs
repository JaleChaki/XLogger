using System;

namespace Logging {
	public static class Logger {

		public static void Debug(string log) {
			InternalLogger.LogString(log, LogLevel.Debug);
		}

		public static void Info(string log) {
			InternalLogger.LogString(log, LogLevel.Info);
		}

		public static void Warn(string log) {
			InternalLogger.LogString(log, LogLevel.Warning);
		}

		public static void Error(string log) {
			InternalLogger.LogString(log, LogLevel.Error);
		}

		public static void Fatal(string log) {
			InternalLogger.LogString(log, LogLevel.Fatal);
		}

		public static void Debug(Exception e) {
			InternalLogger.LogException(e, LogLevel.Debug);
		}

		public static void Info(Exception e) {
			InternalLogger.LogException(e, LogLevel.Info);
		}

		public static void Warn(Exception e) {
			InternalLogger.LogException(e, LogLevel.Warning);
		}

		public static void Error(Exception e) {
			InternalLogger.LogException(e, LogLevel.Error);
		}

		public static void Fatal(Exception e) {
			InternalLogger.LogException(e, LogLevel.Fatal);
		}

	}
}
