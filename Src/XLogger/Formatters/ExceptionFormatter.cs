using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Formatters {
	public abstract class ExceptionFormatter {

		internal virtual bool IsConcreteTypeFormatter => false;

		internal virtual Type FormattingType => null;

		public ExceptionFormatter() {

		}

		public abstract string Format(Exception e);

		public abstract bool AllowFormat(Exception e);
	}

	public abstract class ExceptionFormatter<T> : ExceptionFormatter {

		internal override bool IsConcreteTypeFormatter => true;

		internal override Type FormattingType => typeof(T);

		public ExceptionFormatter() : base() {

		}

		public sealed override bool AllowFormat(Exception e) {
			return e is T;
		}

	}
}
