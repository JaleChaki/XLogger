using System.Collections.Generic;

namespace Logging.Configuration {
	internal class LoggerConfigurationModel {

		public LogLevel CurrentLogLevel { get; set; }

		private List<IAbstractConfiguration> Configurations;

		public LoggerConfigurationModel() {
			Configurations = new List<IAbstractConfiguration>();
		}

		public void AddConfiguration<T>(T config) where T : IAbstractConfiguration {
			for (int i = 0; i < Configurations.Count; ++i) {
				if (Configurations[i] is T) {
					Configurations[i] = config;
				}
			}
		}

		public T GetConfiguration<T>() where T : IAbstractConfiguration {
			foreach (var item in Configurations) {
				if (item is T castedItem) {
					return castedItem;
				}
			}
			return default;
		}

	}
}
