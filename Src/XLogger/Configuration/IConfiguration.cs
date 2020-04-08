using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Configuration {
	public interface IConfiguration {

		IConfiguration CreateDefaultConfiguration();

	}
}
