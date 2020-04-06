using Logging.Configuration;
using Logging.Configuration.MethodsConfiguration;
using System;

namespace Logging.LogMethods {
	public class ConsoleLogMethod : ILogMethod {

		protected static readonly object Sync = new object();

		public ConsoleLogMethodConfiguration Config { get; set; }

		public ConsoleLogMethod() : this(LoggerConfiguration.GetConfiguration<ConsoleLogMethodConfiguration>()) {

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

		public ConsoleLogMethod(ConsoleLogMethodConfiguration config) {
			Config = config;
		}

		public void Write(FormattedLogMessage formattedLog) {
			lock (Sync) {
				ConsoleColor previousConsoleColor = Console.ForegroundColor;
				Console.ForegroundColor = GetTextHightlighting(formattedLog);
				Console.WriteLine(formattedLog);
				Console.ForegroundColor = previousConsoleColor;
			}
		}
	}
}
