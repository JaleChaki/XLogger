using XLogger.Formatters;
using XLogger.LogMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger {
	internal static class InternalLogger {

		public static IFormatter StringFormatter { get; set; }

		public static void LogString(string log, LogLevel level) {
			var loggedMessage = new LogMessage(log, level);
			string formattedMessage = LogFormatterManager.GetFormatter(log).Format(loggedMessage);
			FormattedLogMessage formattedResult = new FormattedLogMessage(formattedMessage, loggedMessage);
			foreach (var i in LogMethodsManager.LogMethodsModel.Instances) {
				i.WriteIfPossible(formattedResult);
			}
		}

		public static void LogException(Exception e, LogLevel level) {
			var loggedMessage = new LogMessage(e, level);
			string formattedMessage = ExceptionFormattersManager.GetFormatter(e)?.Format(loggedMessage);
			FormattedLogMessage formattedResult = new FormattedLogMessage(formattedMessage, loggedMessage);
			foreach (var i in LogMethodsManager.LogMethodsModel.Instances) {
				i.WriteIfPossible(formattedResult);
			}
		}

		public static void LogObject(object obj, LogLevel level) {
			if (obj is Exception e) {
				LogException(e, level);
				return;
			}

		}

		private static void InvokeMethods(FormattedLogMessage formattedLog, IEnumerable<ILogMethod> methods) {
			foreach (var m in methods) {
				m.Write(formattedLog);
			}
		}

	}
}
