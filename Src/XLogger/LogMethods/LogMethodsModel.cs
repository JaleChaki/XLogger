using System.Collections.Generic;

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
