using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.Formatters {
	public interface IFormatter {

		string Format(LogMessage log);

	}
}
