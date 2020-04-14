using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XLogger.Configuration;
using XLogger.Configuration.FormatterConfiguration;

namespace XLogger.Tests {
	[TestClass]
	public class ObjectLogTest {

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

			[LoggedProperty(Name = "debugProp", IsDebug = true)]
			public string DebugProperty { get; set; }

		}

		[TestMethod]
		public void SimpleTest() {
			Logger.Debug(o: null);
			Logger.Info(o: null);
			Logger.Warn(o: null);
			Logger.Error(o: null);
			Logger.Fatal(o: null);
		}

		[TestMethod]
		public void AttributeTest() {
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
		}

		[TestMethod]
		public void AttributePropertyDebugTest() {
			TestableObject obj = new TestableObject();
			DefaultObjectFormatterConfiguration config = new DefaultObjectFormatterConfiguration {
				FormattedObjectHeader = "",
				LoggedPropertyFormat = "{0},",
				FormattedObjectTail = ""
			};
			TestUtils.TestableLogMethod method = new TestUtils.TestableLogMethod();
			LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
				builder
					.UseDefaultConfiguration()
					.UseLogLevel(LogLevel.Debug)
					.AddConfiguration(config)
					.UseCustomLogMethod(method);
			});
			Logger.Debug(obj);
			Logger.Info(obj);
			Assert.IsTrue(method.WritedLogs[0].FormattedMessage.Contains("debugProp"));
			Assert.IsFalse(method.WritedLogs[1].FormattedMessage.Contains("debugProp"));
		}
	}
}
