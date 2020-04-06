#if USE_JSON
using Logging.LogMethods;
using Newtonsoft.Json;
#endif
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logging.Configuration {
	public sealed class ConfigurationBuilder {

		public LogLevel LogLevel { get; set; } = LogLevel.Info;

		private LoggerConfigurationModel BuildedModel;

		public ConfigurationBuilder() {
			Reset();
		}

		public ConfigurationBuilder Reset() {
			BuildedModel = new LoggerConfigurationModel();
			return this;
		}

		public ConfigurationBuilder UseLogLevel(LogLevel level) {
			LogLevel = level;
			return this;
		}

#if USE_JSON
		public ConfigurationBuilder FromJsonFile<T>(string filepath) where T : class, IAbstractConfiguration {
			string jsonStr = File.ReadAllText(filepath);
			BuildedModel.AddConfiguration<T>(JsonConvert.DeserializeObject<T>(jsonStr));
			return this;
		}
#endif

		public ConfigurationBuilder AddConfiguration<T>(IAbstractConfiguration config) where T : IAbstractConfiguration {
			BuildedModel.AddConfiguration<T>((T)config);
			return this;
		}

		public ConfigurationBuilder UseConsoleLogging() {
			return UseConsoleLogging(true);
		}

		public ConfigurationBuilder UseConsoleLogging(bool use) {
			return this;
		}

		public ConfigurationBuilder UseFileLogging() {
			return UseFileLogging(true);
		}

		public ConfigurationBuilder UseFileLogging(bool use) {
			return this;
		}

		public ConfigurationBuilder UseFileLogging(string fileName) {
			return this;
		}

		public ConfigurationBuilder UseCustomLogMethod<T>() where T : ILogMethod, new() {
			return this;
		}

		public ConfigurationBuilder UseCustomLogMethod(ILogMethod method) {
			return this;
		}

		public ConfigurationBuilder UseDefaultConfiguration() {
			return Reset()
				.UseLogLevel(LogLevel.Info)
				.UseFileLogging()
				.UseConsoleLogging();
		}

		internal void ApplyConfiguration() {
			LoggerConfiguration.LoggerConfigurationModel = BuildedModel;
		}

	}
}
