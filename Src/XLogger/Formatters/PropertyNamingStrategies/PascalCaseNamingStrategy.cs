using System.Reflection;
using System.Text;

namespace XLogger.Formatters.PropertyNamingStrategies {
	public class PascalCaseNamingStrategy : IPropertyNamingStrategy {

		public string GetName(MemberInfo member) {
			string[] words = PropertyNameParser.Parse(member.Name);
			StringBuilder result = new StringBuilder();
			foreach (var w in words) {
				result.Append(PropertyNameParser.ParseWordAsPascalCase(w));
			}
			return result.ToString();
		}
	}
}
