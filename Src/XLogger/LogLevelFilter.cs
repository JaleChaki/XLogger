using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger {
	public class LogLevelFilter : IFilter {

		private Predicate<LogMessage> Predicate;

		public LogLevelFilter(Predicate<LogMessage> predicate) {
			Predicate = predicate;
		}

		public LogLevelFilter(LogLevel exactlyLevel) : this(exactlyLevel: exactlyLevel, null, null) {

		}

		internal LogLevelFilter(LogLevel? exactlyLevel = null, LogLevel? higherLevel = null, LogLevel? lowerLevel = null) {
			if (exactlyLevel != null) {
				Predicate = delegate (LogMessage log) { return log.Level == exactlyLevel; };
			}
			if (higherLevel != null) {
				Predicate = delegate (LogMessage log) { return log.Level >= higherLevel; };
			}
			if (lowerLevel != null) {
				Predicate = delegate (LogMessage log) { return log.Level <= lowerLevel; };
			}
		}

		public static LogLevelFilter ByHigherLevel(LogLevel level) {
			return new LogLevelFilter(higherLevel: level);
		}

		public static LogLevelFilter ByLowerLevel(LogLevel level) {
			return new LogLevelFilter(lowerLevel: level);
		}

		public virtual bool Filter(LogMessage log) {
			return Predicate(log);
		}
	}
}
