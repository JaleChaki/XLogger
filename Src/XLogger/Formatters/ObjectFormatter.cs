using System;

namespace XLogger.Formatters {
	public abstract class ObjectFormatter : IFormatter {

		protected internal virtual Type FormattingType => null;

		protected internal virtual bool IsConcreteTypeFormatter => false;

		public abstract string Format(LogMessage log);

		public abstract bool AllowFormat(object o);

	}

	public abstract class ObjectFormatter<T> : ObjectFormatter {

		protected internal override Type FormattingType => typeof(T);

		protected internal override bool IsConcreteTypeFormatter => false;

		public sealed override bool AllowFormat(object o) {
			return o is T;
		}

	}
}
