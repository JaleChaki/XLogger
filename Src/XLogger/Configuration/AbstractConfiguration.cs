using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Configuration {
	public interface IAbstractConfiguration {

		IAbstractConfiguration CreateDefaultConfiguration();

	}
}
