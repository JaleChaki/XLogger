using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.LogMethods {
	internal static class LogMethodsManager {

		public static LogMethodsModel LogMethodsModel { get; set; }

		static LogMethodsManager() {
			LogMethodsModel = new LogMethodsModel();
		}

		public static void AddLogMethod(ILogMethod method, IFilter filter) {
			LogMethodsModel.AddMethod(method, filter);
		}

		public static void AddLogMethod(ILogMethod method, Predicate<LogMessage> predicate) {
			LogMethodsModel.AddMethod(method, new PredicateFilter(predicate));
		}

	}
}
