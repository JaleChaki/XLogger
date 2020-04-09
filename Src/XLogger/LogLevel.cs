using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace XLogger {
	public enum LogLevel {

		[EnumMember(Value = "Debug")]
		Debug,

		[EnumMember(Value = "Info")]
		Info,

		[EnumMember(Value = "Warning")]
		Warning,

		[EnumMember(Value = "Error")]
		Error,

		[EnumMember(Value = "Fatal")]
		Fatal

	}
}
