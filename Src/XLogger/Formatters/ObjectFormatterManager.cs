using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XLogger.Formatters {
	internal static class ObjectFormatterManager {

		private static ICollection<ObjectFormatter> ObjectFormatters;

		private static IDictionary<Type, ObjectFormatter> ConcreteObjectFormatters;

		static ObjectFormatterManager() {
			Reset();
		}

		internal static void Reset() {
			ConcreteObjectFormatters = new Dictionary<Type, ObjectFormatter>();
			ObjectFormatters = new List<ObjectFormatter>();
		}

		public static void AddFormatter(ObjectFormatter formatter) {
			if (formatter.IsConcreteTypeFormatter) {
				if (ConcreteObjectFormatters.ContainsKey(formatter.FormattingType)) {
					ConcreteObjectFormatters[formatter.FormattingType] = formatter;
				} else {
					ConcreteObjectFormatters.Add(formatter.FormattingType, formatter);
				}
			} else {
				ObjectFormatters.Add(formatter);
			}
		}

		public static ObjectFormatter GetFormatter(object obj) {
			return (GetMultiFormatter(obj) ?? GetConcreteFormatter(obj)) ?? new DefaultObjectFormatter();
		}

		private static ObjectFormatter GetMultiFormatter(object e) {
			foreach (var formatter in ObjectFormatters) {
				if (formatter.AllowFormat(e)) {
					return formatter;
				}
			}
			return null;
		}

		private static ObjectFormatter GetConcreteFormatter(object e) {
			if (e == null) {
				return null;
			}
			if (ConcreteObjectFormatters.ContainsKey(e.GetType())) {
				return ConcreteObjectFormatters[e.GetType()];
			}

			List<ObjectFormatter> allowFormatters = new List<ObjectFormatter>();
			Type objectType = e.GetType();
			foreach (var formatter in ConcreteObjectFormatters.Values) {
				if (objectType.IsSubclassOf(formatter.FormattingType) || objectType == formatter.FormattingType) {
					allowFormatters.Add(formatter);
				}
			}

			allowFormatters.Sort((a, b) => {
				return a.FormattingType.IsSubclassOf(b.FormattingType) ? -1 : 1;
			});

			return allowFormatters.FirstOrDefault();
		}

	}
}
