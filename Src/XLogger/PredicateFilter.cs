using System;

namespace XLogger {
	public class PredicateFilter : IFilter {

		protected Predicate<LogMessage> Predicate { get; set; }

		public PredicateFilter(Predicate<LogMessage> predicate) {
			this.Predicate = predicate;
		}

		public bool Filter(LogMessage log) {
			return Predicate(log);
		}
	}
}
