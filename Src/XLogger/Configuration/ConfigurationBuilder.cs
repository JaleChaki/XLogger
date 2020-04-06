#if USE_JSON
using Newtonsoft.Json;
#endif
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Configuration {
	public class ConfigurationBuilder {

		public LogLevel LogLevel { get; set; } = LogLevel.Info;

		public ConfigurationBuilder UseLogLevel(LogLevel level) {
			LogLevel = level;
			return this;
		}

#if USE_JSON
		public ConfigurationBuilder FromJson(string filepath) {
			return this;
		}
#endif

		public ConfigurationBuilder UseDefaultConfiguration() {
			LogLevel = LogLevel.Debug;
			return this;
		}

		internal void ApplyConfiguration() {

		}

	}
}
