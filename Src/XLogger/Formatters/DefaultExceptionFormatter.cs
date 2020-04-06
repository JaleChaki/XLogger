using Logging.Configuration.FormatterConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Formatters {
	public class DefaultExceptionFormatter : ExceptionFormatter<Exception> {

		public ExceptionFormatterConfig Config { get; set; }

		public DefaultExceptionFormatter() : this(ExceptionFormatterConfig.GetDefaultConfiguration()) {
			
		}

		public DefaultExceptionFormatter(ExceptionFormatterConfig config) : base() {
			Config = config;
		}

		public override string Format(LogMessage log) {
			return InternalFormat(log);
		}

		protected internal virtual string InternalFormat(LogMessage log) {
			Exception e = log.Exception;
			StringBuilder result = new StringBuilder(string.Format(Config.ExceptionHeaderFormat, e.GetType().Name, e.Message));
			if (Config.PrintStackTrace) {
				result.Append("\n")
					.Append(Config.ExceptionStackTraceHeader)
					.Append("\n")
					.Append(e.StackTrace);
			}
			if (e.InnerException != null && Config.PrintInnerExceptions) {
				result.Append(string.Format(Config.InnerExceptionHeader, e.InnerException.GetType().Name, e.InnerException.Message))
					.Append("\n")
					.Append(ExceptionFormatter.GetExceptionFormatter(e).Format(log));
			}

			return result.ToString();
		}

	}
}
