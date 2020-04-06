using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Configuration {
	public static class LoggerConfiguration {

		internal static LoggerConfigurationModel LoggerConfigurationModel;

		static LoggerConfiguration() {
			new ConfigurationBuilder().ApplyConfiguration();
		}

		public static void ConfigureLoggerConfiguration(Action<ConfigurationBuilder> callback) {
			var configurationBuilder = new ConfigurationBuilder();
			callback?.Invoke(configurationBuilder);
			configurationBuilder.ApplyConfiguration();
		}

		public static void SetLogLevel(LogLevel level) {
			LoggerConfigurationModel.CurrentLogLevel = level;
		}

		public static void AddConfiguration<T>(T config) where T : IAbstractConfiguration {
			LoggerConfigurationModel.AddConfiguration(config);
		}

		public static T GetConfiguration<T>() where T : IAbstractConfiguration {
			return LoggerConfigurationModel.GetConfiguration<T>();
		}

	}
}
