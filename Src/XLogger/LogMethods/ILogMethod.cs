using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.LogMethods {
	public interface ILogMethod {

		void Write(FormattedLogMessage log);

	}
}
