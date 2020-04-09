using XLogger.Formatters;
using XLogger.LogMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger {
	internal static class InternalLogger {

		public static IFormatter StringFormatter { get; set; }

		public static void LogString(string log, LogLevel level) {
			string formattedMessage = LogFormatterManager.GetFormatter(log).Format(new LogMessage(log, level));
			FormattedLogMessage formattedResult = new FormattedLogMessage(formattedMessage, new LogMessage(log, level));
			foreach (var m in LogMethodsManager.LogMethodsModel.Methods) {
				m.Write(formattedResult);
			}
		}

		public static void LogException(Exception e, LogLevel level) {

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
