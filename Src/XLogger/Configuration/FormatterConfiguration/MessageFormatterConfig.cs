namespace XLogger.Configuration.FormatterConfiguration {
	public class MessageFormatterConfig : IConfiguration {

		public string MessageFormat { get; set; }

		public bool PrintExceptions { get; set; }

		public IConfiguration CreateDefaultConfiguration() {
			return new MessageFormatterConfig {
				MessageFormat = "{0:dd.MM.yyyy HH:mm:ss} {1}:\t{2}",
				PrintExceptions = true
			};
		}

	}
}
