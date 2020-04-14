using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLogger.Configuration;

namespace XLogger.Tests {
	[TestClass]
	public class CustomLogMethodTests {

		[TestMethod]
		public void CustomLogMethodTest() {
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder
					.UseDefaultConfiguration()
					.UseCustomLogMethod<TestUtils.TestableLogMethod>();
			});
			Logger.Debug("0");
			Logger.Info("1");
			Logger.Warn("2");
			Logger.Error("3");
			Logger.Fatal("4");
		}

		[TestMethod]
		public void AlternateUseCustomMethod() {
			TestUtils.TestableLogMethod method = new TestUtils.TestableLogMethod();
			method.Callback += delegate (FormattedLogMessage log) { Console.WriteLine("LOGGED " + log.PrimaryMessage.Message); };
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder
					.UseDefaultConfiguration()
					.UseLogLevel(LogLevel.Debug)
					.UseCustomLogMethod(method)
					.UseConsoleLogging();
			});
			Logger.Debug("0");
			Logger.Info("1");
			Logger.Warn("2");
			Logger.Error("3");
			Logger.Fatal("4");
			for (int i = 0; i < 5; ++i) {
				Console.WriteLine("Validate " + i);
				Console.WriteLine(method.WritedLogs[i].PrimaryMessage.Message);
				Assert.IsTrue(method.WritedLogs[i].PrimaryMessage.Message == i.ToString());
			}
			Assert.IsTrue(method.WritedLogs.Count == 5);
		}

	}
}
