using XLogger.Formatters;
using XLogger.LogMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger {
	internal static class InternalLogger {

		public static IFormatter StringFormatter { get; set; }

		public readonly static object Sync = new object();

		public static void LogString(string log, LogLevel level) {
			lock (Sync) {
				var loggedMessage = new LogMessage(log, level);
				string formattedMessage = LogFormatterManager.GetFormatter(log).Format(loggedMessage);
				FormattedLogMessage formattedResult = new FormattedLogMessage(formattedMessage, loggedMessage);
				foreach (var i in LogMethodsManager.LogMethodsModel.Instances) {
					i.WriteIfNeed(formattedResult);
				}
			}
		}

		public static void LogException(Exception e, LogLevel level) {
			string formattedMessage;
			lock (Sync) {
				var loggedMessage = new LogMessage(e, level);
				formattedMessage = ExceptionFormattersManager.GetFormatter(e)?.Format(loggedMessage);
			}
			LogString(formattedMessage, level);
		}

		public static void LogObject(object obj, LogLevel level) {
			lock (Sync) {
				if (obj is Exception e) {
					LogException(e, level);
					return;
				}
			}
		}

	}
}
