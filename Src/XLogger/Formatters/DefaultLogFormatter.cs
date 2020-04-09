using XLogger.Configuration;
using XLogger.Configuration.FormatterConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.Formatters {
	public class DefaultLogFormatter : IFormatter {

		public MessageFormatterConfig Config { get; set; }

		public DefaultLogFormatter() : this(LoggerConfiguration.GetConfiguration<MessageFormatterConfig>()) {

		}

		public DefaultLogFormatter(MessageFormatterConfig config) {
			Config = config ?? (new MessageFormatterConfig()).CreateDefaultConfiguration() as MessageFormatterConfig;
		}

		public virtual string Format(LogMessage message) {
			StringBuilder result = new StringBuilder();
			result.Append(string.Format(Config.MessageFormat, DateTime.Now, message.Level, message.Message));
			return result.ToString();
		}
	}
}
