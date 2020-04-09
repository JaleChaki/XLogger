using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XLogger;
using XLogger.Configuration;

namespace XLogger.Tests {
	[TestClass]
	public class LoggerTests {
		[TestMethod]
		public void SimpleSetupTest() {
			Logger.Info("test log");
			Logger.Debug("debug log");
			Logger.Error("error log");
			Logger.Warn("warn log");
			Logger.Fatal("fatal log");
		}

		[TestMethod]
		public void FileOutputTest() {
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder.UseFileLogging("log.txt");
			});
			string loggedStr = TestUtils.GenerateString();
			Logger.Info(loggedStr);
			string fileText = File.ReadAllText("log.txt");
			Assert.IsTrue(fileText.Contains(loggedStr));
		}

		[TestMethod]
		public void ExceptionLog() {
			Logger.Error(new Exception("exception message"));
		}
	}
}
