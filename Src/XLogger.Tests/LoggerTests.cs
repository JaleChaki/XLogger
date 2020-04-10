using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XLogger;
using XLogger.Configuration;
using XLogger.Configuration.MethodsConfiguration;

namespace XLogger.Tests {
	[TestClass]
	public class LoggerTests {
		[TestMethod]
		public void SimpleSetupTest() {
			Logger.Debug("debug log");
			Logger.Info("test log");
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

		public void CustomFileOutputTest() {
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder
					.AddConfiguration(new FileLogMethodConfiguration { FilePattern = "custom.txt" })
					.UseFileLogging();
			});
			Logger.Info("log");
			Assert.IsTrue(File.Exists("custom.txt"));
		}

		[TestMethod]
		public void ExceptionLog() {
			Logger.Error(new Exception("exception message"));
		}
	}
}
