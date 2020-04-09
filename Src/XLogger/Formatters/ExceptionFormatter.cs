using System;
using System.Collections.Generic;
using System.Text;

namespace XLogger.Formatters {
	public abstract class ExceptionFormatter : IFormatter {
		
		internal virtual bool IsConcreteTypeFormatter => false;

		internal virtual Type FormattingType => null;

		public ExceptionFormatter() {

		}

		public abstract string Format(LogMessage e);

		public abstract bool AllowFormat(Exception e);

		protected static ExceptionFormatter GetExceptionFormatter(Exception e) {
			return ExceptionFormattersManager.GetFormatter(e);
		}
	}

	public abstract class ExceptionFormatter<T> : ExceptionFormatter where T : Exception {

		internal override bool IsConcreteTypeFormatter => true;

		internal override Type FormattingType => typeof(T);

		public ExceptionFormatter() : base() {

		}

		public sealed override bool AllowFormat(Exception e) {
			return e is T;
		}

	}
}
