using System.Runtime.Serialization;

namespace XLogger.Formatters.PropertyNamingStrategies {
	public enum NamingStrategyType {

		[EnumMember(Value = "Default")]
		Default = 0,

		[EnumMember(Value = "CamelCase")]
		CamelCase = 1,

		[EnumMember(Value = "PascalCase")]
		PascalCase = 2,

		[EnumMember(Value = "SnakeCase")]
		SnakeCase = 3,

		[EnumMember(Value = "UpperCase")]
		UpperCase = 4,

		[EnumMember(Value = "Kebab")]
		KebabCase = 5
	}
}
