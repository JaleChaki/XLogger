#if USE_JSON
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#endif
using System;
using System.Collections.Generic;

namespace XLogger.Configuration.MethodsConfiguration {
	public class ConsoleLogMethodConfiguration : IConfiguration {

#if USE_JSON
		[JsonProperty("Highlighting")]
#endif
		public Dictionary<LogLevel, ConsoleColor> TextHighlighting { get; private set; }

#if USE_JSON
		[JsonConverter(typeof(StringEnumConverter))]
#endif
		public ConsoleColor DefaultConsoleColor { get; set; } = ConsoleColor.White;

		public ConsoleLogMethodConfiguration() {
			TextHighlighting = new Dictionary<LogLevel, ConsoleColor> {
				{ LogLevel.Debug, ConsoleColor.DarkCyan },
				{ LogLevel.Info, ConsoleColor.DarkGreen },
				{ LogLevel.Warn, ConsoleColor.Yellow },
				{ LogLevel.Error, ConsoleColor.Red },
				{ LogLevel.Fatal, ConsoleColor.Red }
			};
		}
	}
}
