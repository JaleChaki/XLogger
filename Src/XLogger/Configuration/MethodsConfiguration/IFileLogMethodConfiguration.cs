using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Configuration.MethodsConfiguration {
	public interface IFileLogConfiguration : IAbstractConfiguration {

		string GetFileName();

	}
}
