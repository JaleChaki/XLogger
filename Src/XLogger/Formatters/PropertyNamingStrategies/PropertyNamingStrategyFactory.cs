namespace XLogger.Formatters.PropertyNamingStrategies {
	internal class PropertyNamingStrategyFactory {

		public IPropertyNamingStrategy GetStrategy(NamingStrategyType type) {
			if (type == NamingStrategyType.CamelCase) {
				return new CamelCaseNamingStrategy();
			}
			if (type == NamingStrategyType.SnakeCase) {
				return new SnakeCaseNamingStrategy();
			}
			if (type == NamingStrategyType.KebabCase) {
				return new KebabCaseNamingStrategy();
			}
			if (type == NamingStrategyType.PascalCase) {
				return new PascalCaseNamingStrategy();
			}
			if (type == NamingStrategyType.UpperCase) {
				return new UpperCaseNamingStrategy();
			}
			return new DefaultNamingStrategy();
		}

	}
}
