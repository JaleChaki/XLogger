using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Formatters {
	public interface ILogFormatter {

		string Format(LogMessage message);

	}
}
