#if USE_JSON
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using XLogger.Formatters.PropertyNamingStrategies;
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


#if USE_JSON
		[JsonProperty]
		[JsonConverter(typeof(StringEnumConverter))]
#endif
		public NamingStrategyType NamingStrategyType { get; set; }

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
