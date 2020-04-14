using System;
using XLogger;
using XLogger.Configuration;
using XLogger.Formatters;

namespace XLogger.AppTests {
	class Program {

		private class CustomExceptionFormatter : ExceptionFormatter<CustomException> {
			public override string Format(LogMessage e) {
				return "custom exception message";
			}
		}

		private class CustomException : Exception {

		}

		private class TestableObject {

			[LoggedProperty]
			public string Field1;

			[LoggedProperty]
			public string Prop1 { get; set; }

			[LoggedProperty]
			public int Field2;

			[LoggedProperty]
			public int Prop2 { get; set; }

			[LoggedProperty]
			public double Field3;

			[LoggedProperty]
			public double Prop3 { get; set; }

			[LoggedProperty(Name = "custom name")]
			public string CustomNamedProperty { get; set; }

			[LoggedProperty(IsDebug = true)]
			public string DebugProperty { get; set; }

		}

		static void Main(string[] args) {
			/*Logger.Info("info log");
			Logger.Debug("debug log");
			Logger.Error("error log");
			Logger.Warn("warn log");
			Logger.Fatal("fatal log");
			Console.WriteLine("primary color log");*/

			//Logger.Error(new Exception("exception message"));
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder.UseDefaultConfiguration()
				.UseLogLevel(LogLevel.Debug)
				.AddFormatter(new CustomExceptionFormatter());
			});
			
			/*Logger.Info(new CustomException());
			Logger.Info(new Exception("exp message"));*/

			TestableObject obj = new TestableObject {
				Field1 = "abc",
				Field2 = 42,
				Field3 = 3.14159265,
				Prop1 = "cde",
				Prop2 = 63,
				Prop3 = 1.66667,
				CustomNamedProperty = "fgh",
				DebugProperty = "deb"
			};
			Logger.Info(obj);
			Logger.Debug(obj);
		}
	}
}
