using System;
using XLogger;
using XLogger.Configuration;
using XLogger.Formatters;

namespace XLogger.AppTests {
	class Program {

		private class CustomExceptionFormatter : ExceptionFormatter<CustomException> {
			public override string Format(LogMessage e) {
				return "qwe";
			}
		}

		private class CustomException : Exception {

		}

		static void Main(string[] args) {
			Logger.Info("test log");
			Logger.Debug("debug log");
			Logger.Error("error log");
			Logger.Warn("warn log");
			Logger.Fatal("fatal log");
			Console.WriteLine("primary color log");

			Logger.Error(new Exception("exception message"));
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder.UseDefaultConfiguration()
				.AddFormatter(new CustomExceptionFormatter());
			});
			
			Logger.Info(new CustomException());
			Logger.Info(new Exception("exp message"));
		}
	}
}
