using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.Configuration {
	public interface IConfiguration {

		IConfiguration CreateDefaultConfiguration();

	}
}
