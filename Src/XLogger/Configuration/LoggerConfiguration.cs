using System;
using System.Collections.Generic;
using System.Text;
using XLogger.Formatters;
using XLogger.LogMethods;

namespace XLogger.Configuration {
	public static class LoggerConfiguration {

		internal static LoggerConfigurationModel LoggerConfigurationModel;

		static LoggerConfiguration() {
			lock (InternalLogger.Sync) {
				LoggerConfigurationModel = new LoggerConfigurationModel();
				new ConfigurationBuilder().UseDefaultConfiguration().ApplyConfiguration();
			}
		}

		public static void ConfigureLoggerConfiguration(Action<ConfigurationBuilder> callback) {
			lock (InternalLogger.Sync) {
				var configurationBuilder = new ConfigurationBuilder();
				callback?.Invoke(configurationBuilder);
				configurationBuilder.ApplyConfiguration();
			}
		}

		public static void SetLogLevel(LogLevel level) {
			LoggerConfigurationModel.CurrentLogLevel = level;
		}

		public static void AddConfiguration<T>(T config) where T : IConfiguration {
			lock (InternalLogger.Sync) {
				LoggerConfigurationModel.AddConfiguration(config);
			}
		}

		public static T GetConfiguration<T>() where T : IConfiguration {
			lock (InternalLogger.Sync) {
				return LoggerConfigurationModel.GetConfiguration<T>();
			}
		}

	}
}
