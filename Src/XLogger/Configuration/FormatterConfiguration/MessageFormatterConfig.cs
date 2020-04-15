namespace XLogger.Configuration.FormatterConfiguration {
	public class MessageFormatterConfig : IConfiguration {

		public string MessageFormat { get; set; }

		public MessageFormatterConfig() {
			MessageFormat = "{0: HH:mm:ss} {1}:\t{2}";
		}

	}
}
