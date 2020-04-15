using Microsoft.VisualStudio.TestTools.UnitTesting;
using XLogger.Configuration;
using XLogger.Formatters;

namespace XLogger.Tests.FormattersTesting {
	[TestClass]
	public class CustomLogFormatterTest {

		private class CustomLogFormatter : IFormatter {

			public const string CustomLogFormatterResult = "____1234567890____";

			public string Format(LogMessage log) {
				return CustomLogFormatterResult;
			}
		}

		[TestMethod]
		public void Test() {
			TestUtils.ClearSpace();
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder
					.AddFormatter(new CustomLogFormatter())
					.UseFileLogging("log.log");
			});
			Logger.Info(string.Empty);
			Assert.IsTrue(TestUtils.FileContainsString(CustomLogFormatter.CustomLogFormatterResult));
		}
	}
}
