﻿using System.Reflection;

namespace XLogger.Formatters.PropertyNamingStrategies {
	public class SnakeCaseNamingStrategy : SeparatedCaseNamingStrategy {

		public override string GetName(MemberInfo member) {
			return CreatePropertyNameWithSeparator(PropertyNameParser.Parse(member.Name), '_');
		}
	}
}
