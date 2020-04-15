using System.Linq;
using System.Reflection;

namespace XLogger.Formatters.PropertyNamingStrategies {
	public class UpperCaseNamingStrategy : SeparatedCaseNamingStrategy {

		public override string GetName(MemberInfo member) {
			return CreatePropertyNameWithSeparator(PropertyNameParser.Parse(member.Name).Select(x => x.ToUpper()).ToArray(), '_');
		}
	}
}