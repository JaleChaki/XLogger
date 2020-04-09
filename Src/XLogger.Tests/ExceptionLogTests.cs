using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLogger.Configuration;
using XLogger.Formatters;

namespace XLogger.Tests {
	[TestClass]
	public class ExceptionLogTests {

		private class CustomExceptionFormatter : ExceptionFormatter<Exception> {
			public override string Format(LogMessage e) {
				return "qwe";
			}
		}

		private class CustomException : Exception {

		}

		[TestMethod]
		public void SimpleExceptionTest() {
			Logger.Debug(new Exception("exception message"));
		}

		[TestMethod]
		public void CustomExceptionFormatterTest() {
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder.AddFormatter(new CustomExceptionFormatter());
			});
			Logger.Info(new CustomException());
		}

	}
}
