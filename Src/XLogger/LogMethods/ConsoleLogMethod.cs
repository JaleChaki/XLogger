using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.LogMethods {
	public class ConsoleLogMethod : ILogMethod {



		protected ConsoleColor GetConsoleColor(LogLevel level) {
			return ConsoleColor.Red;
		}

		public void Write(FormattedLogMessage log) {
			
		}
	}
}
