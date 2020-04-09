using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger {
	public interface IFilter {

		bool Filter(LogMessage log);

	}
}
