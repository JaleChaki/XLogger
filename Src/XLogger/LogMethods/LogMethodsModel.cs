using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.LogMethods {
	internal class LogMethodsModel {

		public List<ILogMethod> Methods { get; set; }

		public LogMethodsModel() {
			Methods = new List<ILogMethod>();
		}

		public void AddMethod(ILogMethod method) {
			Methods.Add(method);
		}

	}
}
