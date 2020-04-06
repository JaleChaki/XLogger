using Logging.Formatters.FormatterConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Formatters {
	public class DefaultLogFormatter : ILogFormatter {

		public MessageFormatterConfig Config { get; set; }

		public DefaultLogFormatter() : this(MessageFormatterConfig.GetDefaultConfiguration()) {

		}

		public DefaultLogFormatter(MessageFormatterConfig config) {
			Config = config;
		}

		public virtual string Format(LogMessage message) {
			StringBuilder result = new StringBuilder();
			result.Append(Config);
			return result.ToString();
		}
	}
}
