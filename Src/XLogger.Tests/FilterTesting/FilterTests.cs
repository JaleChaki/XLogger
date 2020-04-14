using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLogger.Tests.FilterTesting {

	[TestClass]
	public class FilterTests {

		private static LogMessage CreateLogMessageWithLevel(LogLevel level) {
			return new LogMessage(string.Empty, level);
		}

		[TestMethod]
		public void LogLevelFilterExactlyTest() {
			LogLevelFilter filter = new LogLevelFilter(LogLevel.Debug);
			Assert.IsTrue(filter.Filter(CreateLogMessageWithLevel(LogLevel.Debug)));
			for (LogLevel i = LogLevel.Info; i <= LogLevel.Fatal; ++i) {
				Assert.IsFalse(filter.Filter(CreateLogMessageWithLevel(i)));
			}
			
		}

		[TestMethod]
		public void LogLevelFilterHigherTest() {
			LogLevelFilter filter = LogLevelFilter.ByHigherLevel(LogLevel.Error);
			Assert.IsTrue(filter.Filter(CreateLogMessageWithLevel(LogLevel.Error)));
			Assert.IsTrue(filter.Filter(CreateLogMessageWithLevel(LogLevel.Fatal)));
			for (LogLevel i = LogLevel.Warn; i >= LogLevel.Debug; --i) {
				Assert.IsFalse(filter.Filter(CreateLogMessageWithLevel(i)));
			}
		}

		[TestMethod]
		public void LogLevelFilterLowerTest() {
			LogLevelFilter filter = LogLevelFilter.ByLowerLevel(LogLevel.Error);
			Assert.IsFalse(filter.Filter(CreateLogMessageWithLevel(LogLevel.Fatal)));
			for (LogLevel i = LogLevel.Error; i >= LogLevel.Debug; --i) {
				Assert.IsTrue(filter.Filter(CreateLogMessageWithLevel(i)));
			}
		}

		[TestMethod]
		public void PredicateFilterTest() {
			PredicateFilter filter = new PredicateFilter(x => x.Message.Contains("abc"));
			Assert.IsTrue(filter.Filter(new LogMessage("adeabcde", LogLevel.Debug)));
			Assert.IsFalse(filter.Filter(new LogMessage("adeabbcde", LogLevel.Debug)));
			filter = new PredicateFilter(x => x.Exception != null);
			Assert.IsTrue(filter.Filter(new LogMessage(new Exception(), LogLevel.Debug)));
			Assert.IsFalse(filter.Filter(new LogMessage("exception", LogLevel.Debug)));
			filter = new PredicateFilter(x => x.Object != null);
			Assert.IsTrue(filter.Filter(new LogMessage(new string[0], LogLevel.Debug)));
			Assert.IsFalse(filter.Filter(new LogMessage(o: null, LogLevel.Debug)));
		}

	}
}
