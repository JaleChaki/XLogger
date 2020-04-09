using System.Runtime.Serialization;

namespace XLogger {
	public enum LogLevel {

		[EnumMember(Value = "Debug")]
		Debug,

		[EnumMember(Value = "Info")]
		Info,

		[EnumMember(Value = "Warn")]
		Warn,

		[EnumMember(Value = "Error")]
		Error,

		[EnumMember(Value = "Fatal")]
		Fatal

	}
}
