using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Configuration {
	public static class LoggerConfiguration {

		public static void ConfigureLoggerConfiguration(Action<ConfigurationBuilder> callback) {
			var configurationBuilder = new ConfigurationBuilder();
			callback?.Invoke(configurationBuilder);
			configurationBuilder.ApplyConfiguration();
		}

		public static void SetLogLevel(LogLevel level) {

		}

	}
}
