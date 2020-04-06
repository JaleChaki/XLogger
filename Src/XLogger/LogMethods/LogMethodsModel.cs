using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.LogMethods {
	internal class LogMethodsModel {

		public List<ILogMethod> Methods { get; set; }

		public LogMethodsModel() {
			Methods = new List<ILogMethod>();
		}

	}
}
