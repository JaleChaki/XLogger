using System;
using System.Collections.Generic;
using System.Text;

namespace Logging {
	public struct LogMessage {

		public string Message;

		public Exception Exception;

		public LogLevel Level;

		public LogMessage(string message, LogLevel level) {
			Message = message;
			Exception = null;
			Level = level;
		}

		public LogMessage(Exception exception, LogLevel level) {
			Message = null;
			Exception = exception;
			Level = level;
		}

		public LogMessage(string message, Exception exception, LogLevel level) {
			Message = message;
			Exception = exception;
			Level = level;
		}

	}
}
