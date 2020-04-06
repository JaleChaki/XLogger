using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Formatters.FormatterConfiguration {
	public class MessageFormatterConfig {

		public string MessageFormat { get; set; }

		public bool PrintExceptions { get; set; }

		internal static MessageFormatterConfig GetDefaultConfiguration() {
			return new MessageFormatterConfig {
				MessageFormat = "",
				PrintExceptions = true
			};
		}

	}
}
