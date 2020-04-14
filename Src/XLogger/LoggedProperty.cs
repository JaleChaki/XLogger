using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger {

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public sealed class LoggedProperty : Attribute {

		public bool IsDebug { get; set; }

		public string Name { get; set; }

		/*public LoggedProperty(bool isDebug = false, string name = null) {
			IsDebug = isDebug;
			Name = name;
		}*/



	}
}
