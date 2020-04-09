#if USE_JSON
using XLogger.LogMethods;
using Newtonsoft.Json;
#endif
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XLogger.Configuration.MethodsConfiguration;

namespace XLogger.Configuration {
	public sealed class ConfigurationBuilder {

		public LogLevel LogLevel { get; set; } = LogLevel.Info;

		private LoggerConfigurationModel BuildedConfigModel;

		private LogMethodsModel BuildedMethodsModel;

		private static readonly object Sync = new object();

		public ConfigurationBuilder() {
			Reset();
		}

		public ConfigurationBuilder Reset() {
			BuildedConfigModel = new LoggerConfigurationModel();
			BuildedMethodsModel = new LogMethodsModel();
			return this;
		}

		public ConfigurationBuilder UseLogLevel(LogLevel level) {
			LogLevel = level;
			return this;
		}

#if USE_JSON
		public ConfigurationBuilder FromJsonFile<T>(string filepath) where T : class, IConfiguration {
			string jsonStr = File.ReadAllText(filepath);
			BuildedConfigModel.AddConfiguration<T>(JsonConvert.DeserializeObject<T>(jsonStr));
			return this;
		}
#endif

		public ConfigurationBuilder AddConfiguration<T>(T config) where T : IConfiguration {
			BuildedConfigModel.AddConfiguration<T>(config);
			return this;
		}

		public ConfigurationBuilder UseConsoleLogging() {
			BuildedMethodsModel.AddMethod(new ConsoleLogMethod());
			return this;
		}


		public ConfigurationBuilder UseFileLogging() {
			BuildedMethodsModel.AddMethod(new FileLogMethod());
			return this;
		}
		
		public ConfigurationBuilder UseFileLogging(string fileName) {
			var config = new FileLogMethodConfiguration {
				GenerateNewFile = false
			};
			BuildedConfigModel.AddConfiguration(config);
			BuildedMethodsModel.AddMethod(new FileLogMethod(fileName, config));
			return this;
		}

		public ConfigurationBuilder UseCustomLogMethod<T>() where T : class, ILogMethod, new() {
			BuildedMethodsModel.AddMethod(new T());
			return this;
		}

		public ConfigurationBuilder UseCustomLogMethod(ILogMethod method) {
			BuildedMethodsModel.AddMethod(method);
			return this;
		}

		public ConfigurationBuilder UseDefaultConfiguration() {
			return Reset()
				.UseLogLevel(LogLevel.Info)
				.UseConsoleLogging();
		}

		internal void ApplyConfiguration() {
			lock (Sync) {
				LoggerConfiguration.LoggerConfigurationModel = BuildedConfigModel;
				LogMethodsManager.LogMethodsModel = BuildedMethodsModel;
			}
		}

	}
}
