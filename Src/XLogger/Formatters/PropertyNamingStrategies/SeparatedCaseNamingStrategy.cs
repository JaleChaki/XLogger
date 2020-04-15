using System.Reflection;
using System.Text;

namespace XLogger.Formatters.PropertyNamingStrategies {
	public abstract class SeparatedCaseNamingStrategy : IPropertyNamingStrategy {
		public abstract string GetName(MemberInfo member);

		protected string CreatePropertyNameWithSeparator(string[] words, char separator) {
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < words.Length; ++i) {
				result.Append(words[i]);
				if (i != words.Length - 1) {
					result.Append(separator);
				}
			}
			return result.ToString();
		}

	}
}
