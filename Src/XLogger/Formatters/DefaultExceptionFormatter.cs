﻿using XLogger.Configuration.FormatterConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.Formatters {
	public class DefaultExceptionFormatter : ExceptionFormatter<Exception> {

		public ExceptionFormatterConfig Config { get; set; }

		public DefaultExceptionFormatter() : this((new ExceptionFormatterConfig()).CreateDefaultConfiguration() as ExceptionFormatterConfig) {
			
		}

		public DefaultExceptionFormatter(ExceptionFormatterConfig config) : base() {
			Config = config;
		}

		public override string Format(LogMessage log) {
			return InternalFormat(log);
		}

		protected internal virtual string InternalFormat(LogMessage log) {
			Exception e = log.Exception;
			StringBuilder result = new StringBuilder(string.Format(Config.ExceptionHeaderFormat, e.GetType().Name, e.Message));
			if (Config.PrintStackTrace) {
				result.Append("\n")
					.Append(Config.ExceptionStackTraceHeader)
					.Append("\n")
					.Append(e.StackTrace);
			}
			return result.ToString();
		}

	}
}
