using System;
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
	}
}
