using System;

namespace XLogger {

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public sealed class LoggedProperty : Attribute {

		public bool IsDebug { get; set; }

		public string Name { get; set; }

	}
}
