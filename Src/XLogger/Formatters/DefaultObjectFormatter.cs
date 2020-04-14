using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using XLogger.Configuration.FormatterConfiguration;
using XLogger.Configuration;
using System.Linq;

namespace XLogger.Formatters {
	public class DefaultObjectFormatter : ObjectFormatter {
		
		public DefaultObjectFormatterConfiguration Config { get; set; }

		public DefaultObjectFormatter() : this(LoggerConfiguration.GetConfiguration<DefaultObjectFormatterConfiguration>()) {

		}

		public DefaultObjectFormatter(DefaultObjectFormatterConfiguration config) {
			if (config == null) {
				config = new DefaultObjectFormatterConfiguration().CreateDefaultConfiguration() as DefaultObjectFormatterConfiguration;
			}
			Config = config;
		}
		
		public override bool AllowFormat(object o) {
			return true;
		}

		public override string Format(LogMessage log) {
			object convertedObject = log.Object;
			if (convertedObject == null) {
				return Config.NullObjectResult;
			}
			StringBuilder builder = new StringBuilder();
			foreach (var prop in convertedObject.GetType().GetProperties()) {
				if (prop.GetCustomAttribute(typeof(LoggedProperty)) is LoggedProperty a) {
					if (a.IsDebug == true && log.Level != LogLevel.Debug) {
						continue;
					}
					builder.Append(string.Format(Config.LoggedPropertyFormat, a.Name ?? prop.Name, prop.GetValue(convertedObject)));
				}
			}
			foreach (var prop in convertedObject.GetType().GetFields()) {
				if (prop.GetCustomAttribute(typeof(LoggedProperty)) is LoggedProperty a) {
					if (a.IsDebug == true && log.Level != LogLevel.Debug) {
						continue;
					}
					builder.Append(string.Format(Config.LoggedPropertyFormat, a.Name ?? prop.Name, prop.GetValue(convertedObject)));
				}
			}
			if (string.IsNullOrEmpty(builder.ToString())) {
				return convertedObject.ToString();
			}
//			string.Format(Config.FormattedObjectHeader, convertedObject.GetType().FullName);
			/*builder.ToString();
			Console.WriteLine(convertedObject.GetType());
			Console.WriteLine(convertedObject.GetType().Name);
			Console.WriteLine(convertedObject.GetType().FullName);
			string.Format(Config.FormattedObjectTail, convertedObject.GetType().FullName);*/
			return string.Format(Config.FormattedObjectHeader, convertedObject.GetType().FullName) + 
				builder.ToString() + 
				string.Format(Config.FormattedObjectTail, convertedObject.GetType().FullName);
		}
	}
}
