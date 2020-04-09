using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.Formatters {
	internal static class LogFormatterManager {

		public static void AddFormatter(IFormatter formatter) {

		}

		public static IFormatter GetFormatter(string loggedMessage) {
			return new DefaultLogFormatter();
		}

	}
}
