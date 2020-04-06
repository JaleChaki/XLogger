using System;
using System.Collections.Generic;
using System.Text;

namespace Logging {
	public class FormattedLogMessage {

		public readonly LogMessage PrimaryMessage;

		public readonly string FormattedMessage;

		public LogLevel Level => PrimaryMessage.Level;

		public FormattedLogMessage(string message, LogMessage primaryMessage) {
			this.FormattedMessage = message;
			this.PrimaryMessage = primaryMessage;
		}

	}
}
