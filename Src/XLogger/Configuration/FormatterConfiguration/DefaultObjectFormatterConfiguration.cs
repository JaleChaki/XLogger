using System;
using System.Collections.Generic;
using System.Text;
#if USE_JSON
using Newtonsoft.Json;
#endif

namespace XLogger.Configuration.FormatterConfiguration {
	public class DefaultObjectFormatterConfiguration : IConfiguration {

#if USE_JSON
		[JsonProperty]
#endif
		public string FormattedObjectHeader { get; set; }

#if USE_JSON
		[JsonProperty]
#endif
		public string FormattedObjectTail { get; set; }

#if USE_JSON
		[JsonProperty]
#endif
		public string NullObjectResult { get; set; }

#if USE_JSON
		[JsonProperty]
#endif
		public string LoggedPropertyFormat { get; set; }

		public IConfiguration CreateDefaultConfiguration() {
			return new DefaultObjectFormatterConfiguration {
				NullObjectResult = "null",
				FormattedObjectHeader = "{0}\n[\n",
				LoggedPropertyFormat = "{0} = {1}\n",
				FormattedObjectTail = "]"
			};
		}
	}
}
