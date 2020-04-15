using System.Reflection;

namespace XLogger.Formatters.PropertyNamingStrategies {
	internal class DefaultNamingStrategy : IPropertyNamingStrategy {

		public string GetName(MemberInfo member) {
			return member.Name;
		}

	}
}
