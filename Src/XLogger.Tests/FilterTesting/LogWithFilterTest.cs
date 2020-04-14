using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLogger.Configuration;

namespace XLogger.Tests.FilterTesting {

	[TestClass]
	public class LogWithFilterTest {

		[TestMethod]
		public void SingleFilterTest() {
			TestUtils.ClearSpace();
			string validStringMask = "123";
			string validString = validStringMask + validStringMask;
			string wrongString = "__1243__";
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder
					.UseFileLogging("log.log", x => x.Message.Contains(validStringMask));
			});
			Logger.Info(validString);
			Logger.Info(wrongString);
			Assert.IsTrue(TestUtils.FileContainsString(validString));
			Assert.IsFalse(TestUtils.FileContainsString(wrongString));
			TestUtils.ClearSpace();
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder
					.UseFileLogging("log.log");
			});
			Logger.Info(validString);
			Logger.Info(wrongString);
			Assert.IsTrue(TestUtils.FileContainsString(validString));
			Assert.IsTrue(TestUtils.FileContainsString(wrongString));
		}

	}
}
