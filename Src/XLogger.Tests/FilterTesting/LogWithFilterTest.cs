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
			if (File.Exists("log.txt")) {
				File.Delete("log.txt");
			}
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder
					.UseFileLogging("log.txt", x => x.Message.Contains("123"));
			});
			Logger.Debug("123123123");
			Logger.Debug("__1243__");
			string lines = File.ReadAllText("log.txt");
			Assert.IsTrue(lines.Contains("123123123"));
			Assert.IsFalse(lines.Contains("__1243__"));
			File.Delete("log.txt");
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder
					.UseFileLogging("log.txt");
			});
			Logger.Debug("123123123");
			Logger.Debug("__1243__");
			lines = File.ReadAllText("log.txt");
			Assert.IsTrue(lines.Contains("123123123"));
			Assert.IsTrue(lines.Contains("__1243__"));
		}

	}
}
