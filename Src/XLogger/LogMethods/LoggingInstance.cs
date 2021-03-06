﻿namespace XLogger.LogMethods {
	internal sealed class LoggingInstance {

		public ILogMethod Method { get; set; }

		public IFilter Filter { get; set; }

		public LoggingInstance(ILogMethod method, IFilter filter = null) {
			this.Method = method;
			this.Filter = filter;
		}

		public void WriteIfNeed(FormattedLogMessage formattedLog) {
			if (Filter == null || Filter.Filter(formattedLog.PrimaryMessage)) {
				Method.Write(formattedLog);
			}
		}
	}
}
