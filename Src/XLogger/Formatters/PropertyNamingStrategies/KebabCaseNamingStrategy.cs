using System.Reflection;

namespace XLogger.Formatters.PropertyNamingStrategies {
	public class KebabCaseNamingStrategy : SeparatedCaseNamingStrategy {

		public override string GetName(MemberInfo member) {
			return CreatePropertyNameWithSeparator(PropertyNameParser.Parse(member.Name), '-');
		}
	}
}
