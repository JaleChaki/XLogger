using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.LogMethods {
	internal class LogMethodsModel {

		public List<LoggingInstance> Instances { get; set; }

		public LogMethodsModel() {
			Instances = new List<LoggingInstance>();
		}

		public void AddMethod(ILogMethod method, IFilter filter = null) {
			Instances.Add(new LoggingInstance(method, filter));
		}

	}
}
