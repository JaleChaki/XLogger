using Logging.Configuration;
using Logging.Configuration.FormatterConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Formatters {
	public class DefaultLogFormatter : IFormatter {

		public MessageFormatterConfig Config { get; set; }

		public DefaultLogFormatter() : this(LoggerConfiguration.GetConfiguration<MessageFormatterConfig>()) {

		}

		public DefaultLogFormatter(MessageFormatterConfig config) {
			Config = config;
		}

		public virtual string Format(LogMessage message) {
			StringBuilder result = new StringBuilder();
			result.Append(string.Format(Config.MessageFormat, DateTime.Now, message.Level, message.Message));
			return result.ToString();
		}
	}
}
