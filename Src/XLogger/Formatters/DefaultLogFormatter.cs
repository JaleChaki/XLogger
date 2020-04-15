using System;
using System.Text;
using XLogger.Configuration;
using XLogger.Configuration.FormatterConfiguration;

namespace XLogger.Formatters {
	public class DefaultLogFormatter : IFormatter {

		public MessageFormatterConfig Config { get; set; }

		public DefaultLogFormatter() : this(null) {

		}

		public DefaultLogFormatter(MessageFormatterConfig config) {
			Config = config ?? LoggerConfiguration.GetConfiguration<MessageFormatterConfig>() ?? new MessageFormatterConfig();
		}

		public virtual string Format(LogMessage message) {
			StringBuilder result = new StringBuilder();
			result.Append(string.Format(Config.MessageFormat, DateTime.Now, message.Level, message.Message));
			return result.ToString();
		}
	}
}
