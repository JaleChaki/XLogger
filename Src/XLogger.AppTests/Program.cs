using System;
using XLogger;

namespace XLogger.AppTests {
	class Program {
		static void Main(string[] args) {
			Logger.Info("test log");
			Logger.Debug("debug log");
			Logger.Error("error log");
			Logger.Warn("warn log");
			Logger.Fatal("fatal log");
			Console.WriteLine("primary color log");
		}
	}
}
