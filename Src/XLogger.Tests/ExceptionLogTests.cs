using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLogger.Configuration;
using XLogger.Formatters;

namespace XLogger.Tests {
	[TestClass]
	public class ExceptionLogTests {

		private class CustomExceptionFormatter : ExceptionFormatter<Exception> {

			public const string FormattedString = "CustomExceptionLog";
			
			public override string Format(LogMessage e) {
				return FormattedString;
			}
		}

		private class CustomException : Exception {

			public CustomException(string message) : base(message) {

			}

		}

		[TestMethod]
		public void SimpleExceptionTest() {
			Logger.Debug(new Exception("exception message"));
		}

		[TestMethod]
		public void CustomExceptionFormatterTest() {
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder
					.AddFormatter(new CustomExceptionFormatter())
					.UseFileLogging("log.txt");
			});
			string CustomExceptionMessage = TestUtils.GenerateString();
			Logger.Info(new CustomException(CustomExceptionMessage));
			string line = File.ReadAllText("log.txt");
			Assert.IsTrue(line.Contains(CustomExceptionFormatter.FormattedString));
			Assert.IsFalse(line.Contains(CustomExceptionMessage));
		}

	}
}
