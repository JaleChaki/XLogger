using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.Formatters {
	internal static class LogFormatterManager {

		public static IFormatter GetFormatter(string loggedMessage) {
			return new DefaultLogFormatter();
		}

	}
}
