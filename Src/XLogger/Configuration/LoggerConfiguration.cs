using System;
using System.Collections.Generic;
using System.Text;
using XLogger.Formatters;
using XLogger.LogMethods;

namespace XLogger.Configuration {
	public static class LoggerConfiguration {

		internal static LoggerConfigurationModel LoggerConfigurationModel;

		private static readonly object Sync = new object();

		static LoggerConfiguration() {
			lock (Sync) {
				LoggerConfigurationModel = new LoggerConfigurationModel();
				new ConfigurationBuilder().UseDefaultConfiguration().ApplyConfiguration();
			}
		}

		public static void ConfigureLoggerConfiguration(Action<ConfigurationBuilder> callback) {
			var configurationBuilder = new ConfigurationBuilder();
			callback?.Invoke(configurationBuilder);
			configurationBuilder.ApplyConfiguration();
		}

		public static void SetLogLevel(LogLevel level) {
			LoggerConfigurationModel.CurrentLogLevel = level;
		}

		public static void AddConfiguration<T>(T config) where T : IConfiguration {
			lock (Sync) {
				LoggerConfigurationModel.AddConfiguration(config);
			}
		}

		public static T GetConfiguration<T>() where T : IConfiguration {
			lock (Sync) {
				return LoggerConfigurationModel.GetConfiguration<T>();
			}
		}

		public static void AddFormatter(IFormatter formatter) {
			if (formatter is ExceptionFormatter excFormatter) {
				ExceptionFormattersManager.AddFormatter(excFormatter);
			} else {
				LogFormatterManager.AddFormatter(formatter);
			}
		}

		public static void AddLogMethod(ILogMethod method, IFilter filter) {

		}

		public static void AddLogMethod(ILogMethod method, Predicate<LogMessage> predicate) {

		}

		public static void AddLogMethod(ILogMethod method) {

		}

	}
}
