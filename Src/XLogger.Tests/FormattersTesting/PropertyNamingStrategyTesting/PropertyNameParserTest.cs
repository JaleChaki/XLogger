using Microsoft.VisualStudio.TestTools.UnitTesting;
using XLogger.Formatters.PropertyNamingStrategies;

namespace XLogger.Tests.FormattersTesting.PropertyNamingStrategyTesting {
	[TestClass]
	public class PropertyNameParserTest {
		[TestMethod]
		public void KebabCaseParseTest() {
			CollectionAssert.AreEqual(PropertyNameParser.Parse("kebab-property-name"), new string[] { "kebab", "property", "name" });
			CollectionAssert.AreEqual(PropertyNameParser.Parse("Kebab-Property-Name"), new string[] { "kebab", "property", "name" });
			CollectionAssert.AreEqual(PropertyNameParser.Parse("kebab-property-Name"), new string[] { "kebab", "property", "name" });
		}

		[TestMethod]
		public void SnakeCaseParseTest() {
			CollectionAssert.AreEqual(PropertyNameParser.Parse("snake-property-name"), new string[] { "snake", "property", "name" });
			CollectionAssert.AreEqual(PropertyNameParser.Parse("Snake-Property-Name"), new string[] { "snake", "property", "name" });
			CollectionAssert.AreEqual(PropertyNameParser.Parse("Snake-property-Name"), new string[] { "snake", "property", "name" });
		}

		[TestMethod]
		public void CamelAndPascalCaseParseTest() {
			CollectionAssert.AreEqual(PropertyNameParser.Parse("PascalPropertyName"), new string[] { "pascal", "property", "name" });
			CollectionAssert.AreEqual(PropertyNameParser.Parse("camelPropertyName"), new string[] { "camel", "property", "name" });
		}

		[TestMethod]
		public void UpperCaseTest() {
			CollectionAssert.AreEqual(PropertyNameParser.Parse("UPPER_CASE_PROPERTY_NAME"), new string[] { "upper", "case", "property", "name" });
			CollectionAssert.AreEqual(PropertyNameParser.Parse("UPPERCASE_PROPERTY_NAME"), new string[] { "uppercase", "property", "name" });
		}

		[TestMethod]
		public void MultipleStyleTest() {
			CollectionAssert.AreEqual(PropertyNameParser.Parse("hard-PROPERTY_NameWith multipleStyles"), new string[] { "hard", "property", "name", "with", "multiple", "styles" });
			CollectionAssert.AreEqual(PropertyNameParser.Parse("-- _ _insane-PRoPeRTY_NameWIth multipleStyles- _ "), new string[] { "insane", "p", "ro", "pe", "rty", "name", "w", "ith", "multiple", "styles" });
			CollectionAssert.AreEqual(PropertyNameParser.Parse("h_a_rd_-PROPERTY_NameWith multiple-Styles- _ "), new string[] { "h", "a", "rd", "property", "name", "with", "multiple", "styles" });
		}

	}
}
