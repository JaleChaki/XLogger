using System.Reflection;
using System.Text;

namespace XLogger.Formatters.PropertyNamingStrategies {
	public class CamelCaseNamingStrategy : IPropertyNamingStrategy {

		public string GetName(MemberInfo member) {
			string[] words = PropertyNameParser.Parse(member.Name);
			StringBuilder result = new StringBuilder(words[0]);
			for (int i = 1; i < words.Length; ++i) {
				result.Append(PropertyNameParser.ParseWordAsPascalCase(words[i]));
			}
			return result.ToString();
		}
	}
}
