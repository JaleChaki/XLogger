namespace XLogger.Formatters {
	internal static class LogFormatterManager {

		private static IFormatter Formatter { get; set; }

		public static void SetFormatter(IFormatter formatter) {
			Formatter = formatter;
		}

		public static IFormatter GetFormatter() {
			return Formatter ?? new DefaultLogFormatter();
		}

	}
}
