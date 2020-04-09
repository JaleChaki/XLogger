using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.Configuration.MethodsConfiguration {
	public class FileLogMethodConfiguration : IConfiguration {

		public string FilePattern { get; set; }

		public bool GenerateNewFile { get; set; }

		public string FileDirectory { get; set; }

		public IConfiguration CreateDefaultConfiguration() {
			return new FileLogMethodConfiguration {
				FilePattern = "{0}_{1}.log",
				GenerateNewFile = true,
				FileDirectory = string.Empty
			};
		}
	}
}
