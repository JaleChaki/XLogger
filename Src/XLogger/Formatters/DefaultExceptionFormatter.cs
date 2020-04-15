using System;
using System.Text;
using XLogger.Configuration;
using XLogger.Configuration.FormatterConfiguration;

namespace XLogger.Formatters {
	public class DefaultExceptionFormatter : ExceptionFormatter<Exception> {

		public ExceptionFormatterConfig Config { get; set; }

		public DefaultExceptionFormatter() : this(null) {

		}

		public DefaultExceptionFormatter(ExceptionFormatterConfig config) : base() {
			Config = config ?? LoggerConfiguration.GetConfiguration<ExceptionFormatterConfig>() ?? new ExceptionFormatterConfig();
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
			return result.ToString();
		}

	}
}
