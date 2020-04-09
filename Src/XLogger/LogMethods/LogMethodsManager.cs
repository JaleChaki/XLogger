using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.LogMethods {
	internal static class LogMethodsManager {

		public static LogMethodsModel LogMethodsModel { get; set; }

		static LogMethodsManager() {
			LogMethodsModel = new LogMethodsModel();
		}

	}
}
