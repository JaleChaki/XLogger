using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger {
	public struct LogMessage {

		public string Message;

		public Exception Exception;

		public object Object;

		public LogLevel Level;

		public LogMessage(string message, LogLevel level) {
			Message = message;
			Exception = null;
			Level = level;
			Object = null;
		}

		public LogMessage(Exception exception, LogLevel level) {
			Message = null;
			Exception = exception;
			Level = level;
			Object = null;
		}

		public LogMessage(object o, LogLevel level) {
			Object = o;
			Message = null;
			Level = level;
			Exception = null;
		}

	}
}
