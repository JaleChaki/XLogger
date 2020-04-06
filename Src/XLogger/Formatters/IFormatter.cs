using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Formatters {
	public interface IFormatter {

		string Format(LogMessage log);

	}
}
