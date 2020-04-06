﻿#if USE_JSON
using Newtonsoft.Json;
#endif
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Configuration.FormatterConfiguration {
	public class ExceptionFormatterConfig : IAbstractConfiguration {

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

		internal static ExceptionFormatterConfig GetDefaultConfiguration() {
			return new ExceptionFormatterConfig {
				ExceptionHeaderFormat = "{0}: {1}",
				ExceptionStackTraceHeader = "StackTrace:",
				PrintStackTrace = true,
				PrintInnerExceptions = true
			};
		}



	}
}
