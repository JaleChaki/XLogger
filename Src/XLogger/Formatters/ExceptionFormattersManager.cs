﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logging.Formatters {
	internal static class ExceptionFormattersManager {

		public static ICollection<ExceptionFormatter> ExceptionFormatters;

		public static IDictionary<Type, ExceptionFormatter> ConcreteExceptionFormatters;


		static ExceptionFormattersManager() {
			ConcreteExceptionFormatters = new Dictionary<Type, ExceptionFormatter>();
			ExceptionFormatters = new List<ExceptionFormatter>();
		}

		public static void AddFormatter(ExceptionFormatter formatter) {
			if (formatter.IsConcreteTypeFormatter) {
				
				if (ConcreteExceptionFormatters.ContainsKey(formatter.FormattingType)) {
					ConcreteExceptionFormatters[formatter.FormattingType] = formatter;
				} else {
					ConcreteExceptionFormatters.Add(formatter.FormattingType, formatter);
				}

			} else {
				ExceptionFormatters.Add(formatter);
			}
		}

		public static ExceptionFormatter GetFormatter(Exception e) {
			return GetMultiFormatter(e) ?? GetConcreteFormatter(e);
		}

		private static ExceptionFormatter GetMultiFormatter(Exception e) {
			foreach (var formatter in ExceptionFormatters) {
				if (formatter.AllowFormat(e)) {
					return formatter;
				}
			}
			return null;
		}

		public static ExceptionFormatter GetConcreteFormatter(Exception e) {
			if (ConcreteExceptionFormatters.ContainsKey(e.GetType())) {
				return ConcreteExceptionFormatters[e.GetType()];
			}

			List<ExceptionFormatter> allowFormatters = new List<ExceptionFormatter>();
			Type exceptionType = e.GetType();
			foreach (var formatter in ConcreteExceptionFormatters.Values) {
				if (exceptionType.IsSubclassOf(formatter.FormattingType) || exceptionType == formatter.FormattingType) {
					allowFormatters.Add(formatter);
				}
			}

			allowFormatters.Sort((a, b) => {
				return a.FormattingType.IsSubclassOf(b.FormattingType) ? -1 : 1;
			});

			return allowFormatters.First();
		}

	}
}