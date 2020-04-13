using System;
using XLogger;
using XLogger.Configuration;

namespace SimpleFileLogging {
	class Program {
		static void Main(string[] args) {
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				// here we got configuration builder, which configure logging "targets",
				// methods and message format
				builder
					.UseConsoleLogging()	// set logging to console
					.UseFileLogging("applicationlog.log");	// set logging to file "application.log"
			});
			Logger.Info("Hello, world!");
			Console.ReadKey();
		}
	}
}
