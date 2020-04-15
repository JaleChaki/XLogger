using System;
using XLogger.Configuration;
using XLogger.Configuration.MethodsConfiguration;

namespace XLogger.LogMethods {
	public class ConsoleLogMethod : ILogMethod {

		protected static readonly object Sync = new object();

		public ConsoleLogMethodConfiguration Config { get; set; }

		public ConsoleLogMethod() : this(null) {

		}

		public ConsoleLogMethod(ConsoleLogMethodConfiguration config) {
			Config = config ?? LoggerConfiguration.GetConfiguration<ConsoleLogMethodConfiguration>() ?? new ConsoleLogMethodConfiguration();
		}

		protected ConsoleColor GetTextHightlighting(FormattedLogMessage formattedLog) {
			if (Config.TextHighlighting == null) {
				return Console.ForegroundColor;
			}
			if (Config.TextHighlighting.ContainsKey(formattedLog.Level)) {
				return Config.TextHighlighting[formattedLog.Level];
			} else {
				return Config.DefaultConsoleColor;
			}
		}

		public void Write(FormattedLogMessage formattedLog) {
			ConsoleColor previousConsoleColor = Console.ForegroundColor;
			Console.ForegroundColor = GetTextHightlighting(formattedLog);
			Console.WriteLine(formattedLog.FormattedMessage);
			Console.ForegroundColor = previousConsoleColor;
		}
	}
}
