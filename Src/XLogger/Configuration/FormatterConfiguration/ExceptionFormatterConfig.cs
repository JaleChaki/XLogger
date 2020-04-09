#if USE_JSON
using Newtonsoft.Json;
#endif
using System;
using System.Collections.Generic;
using System.Text;

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

#if USE_JSON
		[JsonProperty("InnerExceptionHeader")]
#endif
		public string InnerExceptionHeader { get; set; }

		public bool PrintStackTrace { get; set; }

		public bool PrintInnerExceptions { get; set; }

		public IConfiguration CreateDefaultConfiguration() {
			return new ExceptionFormatterConfig {
				ExceptionHeaderFormat = "{0}: {1}",
				ExceptionStackTraceHeader = "StackTrace:",
				PrintStackTrace = true,
				PrintInnerExceptions = true
			};
		}
	}
}
