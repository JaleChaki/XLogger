using System.Reflection;

namespace XLogger.Formatters.PropertyNamingStrategies {
	public interface IPropertyNamingStrategy {

		string GetName(MemberInfo member);

	}
}
