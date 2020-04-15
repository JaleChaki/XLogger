#if USE_JSON
using Newtonsoft.Json;
#endif

namespace XLogger.Configuration.FormatterConfiguration {
	public class ExceptionFormatterConfig : IConfiguration {

#if USE_JSON
		[JsonProperty("HeaderFormat")]
#endif
		public string ExceptionHeaderFormat { get; set; }

#if USE_JSON
		[JsonProperty("StackTraceHeader")]
#endif
		public string ExceptionStackTraceHeader { get; set; }

		public bool PrintStackTrace { get; set; }
		
		public ExceptionFormatterConfig() {
			ExceptionHeaderFormat = "{0}: {1}";
			ExceptionStackTraceHeader = "StackTrace:\n{0}";
			PrintStackTrace = true;
		}
	}
}
