#if USE_JSON
using XLogger.LogMethods;
using Newtonsoft.Json;
#endif
using System;
using System.Collections.Generic;
using System.IO;
using XLogger.Configuration.MethodsConfiguration;
using XLogger.Formatters;

namespace XLogger.Configuration {
	public sealed class ConfigurationBuilder {

		public LogLevel LogLevel { get; set; } = LogLevel.Info;

		private LoggerConfigurationModel BuildedConfigModel;

		private LogMethodsModel BuildedMethodsModel;

		private List<IFormatter> Formatters;

		private static readonly object Sync = new object();

		public ConfigurationBuilder() {
			Reset();
		}

		public ConfigurationBuilder Reset() {
			BuildedConfigModel = new LoggerConfigurationModel();
			BuildedMethodsModel = new LogMethodsModel();
			Formatters = new List<IFormatter>();
			LogLevel = LogLevel.Info;
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
			return UseConsoleLogging(filter: null);
		}

		public ConfigurationBuilder UseConsoleLogging(LogLevel higherLevel) {
			return UseConsoleLogging(filter: LogLevelFilter.ByHigherLevel(higherLevel));
		}

		public ConfigurationBuilder UseConsoleLogging(Predicate<LogMessage> filterPredicate) {
			return UseConsoleLogging(new PredicateFilter(filterPredicate));
		}

		public ConfigurationBuilder UseConsoleLogging(IFilter filter) {
			BuildedMethodsModel.AddMethod(new ConsoleLogMethod(), filter);
			return this;
		}

		public ConfigurationBuilder UseFileLogging() {
			BuildedMethodsModel.AddMethod(new FileLogMethod());
			return this;
		}

		public ConfigurationBuilder UseFileLogging(Predicate<LogMessage> filterPredicate) {
			BuildedMethodsModel.AddMethod(new FileLogMethod(), new PredicateFilter(filterPredicate));
			return this;
		}

		public ConfigurationBuilder UseFileLogging(IFilter filter) {
			BuildedMethodsModel.AddMethod(new FileLogMethod(), filter);
			return this;
		}

		public ConfigurationBuilder UseFileLogging(string fileName) {
			return UseFileLogging(fileName, filter: null);
		}

		public ConfigurationBuilder UseFileLogging(string fileName, IFilter filter) {
			var config = new FileLogMethodConfiguration {
				GenerateNewFile = false
			};
			BuildedConfigModel.AddConfiguration(config);
			BuildedMethodsModel.AddMethod(new FileLogMethod(fileName, config), filter);
			return this;
		}

		public ConfigurationBuilder UseFileLogging(string fileName, Predicate<LogMessage> filterPredicate) {
			return UseFileLogging(fileName, new PredicateFilter(filterPredicate));
		}

		public ConfigurationBuilder UseCustomLogMethod<T>() where T : class, ILogMethod, new() {
			BuildedMethodsModel.AddMethod(new T());
			return this;
		}

		public ConfigurationBuilder UseCustomLogMethod(ILogMethod method, Predicate<LogMessage> filterPredicate) {
			BuildedMethodsModel.AddMethod(method, new PredicateFilter(filterPredicate));
			return this;
		}

		public ConfigurationBuilder UseCustomLogMethod(ILogMethod method, IFilter filter) {
			BuildedMethodsModel.AddMethod(method, filter);
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

		public ConfigurationBuilder AddFormatter(IFormatter formatter) {
			Formatters.Add(formatter);
			return this;
		}

		internal void ApplyConfiguration() {
			lock (Sync) {
				BuildedConfigModel.CurrentLogLevel = LogLevel;
				LoggerConfiguration.LoggerConfigurationModel = BuildedConfigModel;
				LogMethodsManager.LogMethodsModel = BuildedMethodsModel;
				ExceptionFormattersManager.Reset();
				LogFormatterManager.SetFormatter(null);
				foreach (IFormatter f in Formatters) {
					if (f is ExceptionFormatter ef) {
						ExceptionFormattersManager.AddFormatter(ef);
					} else {
						LogFormatterManager.SetFormatter(f);
					}
				}
			}
		}

	}
}
