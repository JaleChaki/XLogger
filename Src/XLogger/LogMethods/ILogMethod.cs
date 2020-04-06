using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.LogMethods {
	public interface ILogMethod {

		void Write(FormattedLogMessage log);

	}
}
