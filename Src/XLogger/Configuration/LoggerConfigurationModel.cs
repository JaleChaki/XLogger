using System.Collections.Generic;

namespace Logging.Configuration {
	internal class LoggerConfigurationModel {

		public LogLevel CurrentLogLevel { get; set; }

		private List<IConfiguration> Configurations;

		public LoggerConfigurationModel() {
			Configurations = new List<IConfiguration>();
		}

		public void AddConfiguration<T>(T config) where T : IConfiguration {
			for (int i = 0; i < Configurations.Count; ++i) {
				if (Configurations[i] is T) {
					Configurations[i] = config;
				}
			}
		}

		public T GetConfiguration<T>() where T : IConfiguration {
			foreach (var item in Configurations) {
				if (item is T castedItem) {
					return castedItem;
				}
			}
			return default;
		}

	}
}
