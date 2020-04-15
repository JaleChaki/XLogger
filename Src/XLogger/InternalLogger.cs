using System;
using XLogger.Configuration;
using XLogger.Formatters;
using XLogger.LogMethods;

namespace XLogger {
	internal static class InternalLogger {

		public readonly static object Sync = new object();

		public static void LogString(string log, LogLevel level) {
			lock (Sync) {
				Publish(log, level);
			}
		}

		public static void LogException(Exception e, LogLevel level) {
			lock (Sync) {
				var loggedMessage = new LogMessage(e, level);
				string formattedMessage = ExceptionFormattersManager.GetFormatter(e).Format(loggedMessage);
				Publish(formattedMessage, level);
			}
		}

		public static void LogObject(object obj, LogLevel level) {
			if (obj is Exception e) {
				LogException(e, level);
				return;
			}
			lock (Sync) {
				var loggedMessage = new LogMessage(obj, level);
				string formattedObject = ObjectFormatterManager.GetFormatter(obj).Format(loggedMessage);
				Publish(formattedObject, level);
			}
		}

		private static void Publish(string log, LogLevel level) {
			if (LoggerConfiguration.LoggerConfigurationModel.CurrentLogLevel > level) {
				return;
			}
			var loggedMessage = new LogMessage(log, level);
			string formattedMessage = LogFormatterManager.GetFormatter().Format(loggedMessage);
			FormattedLogMessage formattedResult = new FormattedLogMessage(formattedMessage, loggedMessage);
			foreach (var i in LogMethodsManager.LogMethodsModel.Instances) {
				i.WriteIfNeed(formattedResult);
			}
		}

	}
}
