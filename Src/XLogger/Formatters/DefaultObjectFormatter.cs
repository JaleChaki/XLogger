using System.Reflection;
using System.Text;
using XLogger.Configuration;
using XLogger.Configuration.FormatterConfiguration;
using XLogger.Formatters.PropertyNamingStrategies;

namespace XLogger.Formatters {
	public class DefaultObjectFormatter : ObjectFormatter {

		public DefaultObjectFormatterConfiguration Config { get; set; }

		public DefaultObjectFormatter() : this(null) {

		}

		public DefaultObjectFormatter(DefaultObjectFormatterConfiguration config) {
			Config = config ?? LoggerConfiguration.GetConfiguration<DefaultObjectFormatterConfiguration>() ?? new DefaultObjectFormatterConfiguration();
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
					string propertyName = new PropertyNamingStrategyFactory().GetStrategy(Config.NamingStrategyType).GetName(prop);
					builder.Append(string.Format(Config.LoggedPropertyFormat, a.Name ?? propertyName, prop.GetValue(convertedObject)));
				}
			}
			foreach (var prop in convertedObject.GetType().GetFields()) {
				if (prop.GetCustomAttribute(typeof(LoggedProperty)) is LoggedProperty a) {
					if (a.IsDebug == true && log.Level != LogLevel.Debug) {
						continue;
					}
					string propertyName = new PropertyNamingStrategyFactory().GetStrategy(Config.NamingStrategyType).GetName(prop);
					builder.Append(string.Format(Config.LoggedPropertyFormat, a.Name ?? propertyName, prop.GetValue(convertedObject)));
				}
			}
			if (string.IsNullOrEmpty(builder.ToString())) {
				return convertedObject.ToString();
			}
			return string.Format(Config.FormattedObjectHeader, convertedObject.GetType().FullName) +
				builder.ToString() +
				string.Format(Config.FormattedObjectTail, convertedObject.GetType().FullName);
		}
	}
}
