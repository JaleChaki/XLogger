using Microsoft.VisualStudio.TestTools.UnitTesting;
using XLogger.Formatters.PropertyNamingStrategies;

namespace XLogger.Tests.FormattersTesting.PropertyNamingStrategyTesting {
	[TestClass]
	public class NamingStrategiesTest {

		private class TestInstance {

			public string PropertyName;

			public string PROPERTY_NAME;

			public string propertyName;

		}


		[TestMethod]
		public void PascalCaseNamingStrategyTests() {
			IPropertyNamingStrategy strategy = new PascalCaseNamingStrategy();
			TestInstance instance = new TestInstance();
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("PropertyName")[0]), "PropertyName");
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("propertyName")[0]), "PropertyName");
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("PROPERTY_NAME")[0]), "PropertyName");
		}

		[TestMethod]
		public void CamelCaseNamingStrategyTests() {
			IPropertyNamingStrategy strategy = new CamelCaseNamingStrategy();
			TestInstance instance = new TestInstance();
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("PropertyName")[0]), "propertyName");
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("propertyName")[0]), "propertyName");
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("PROPERTY_NAME")[0]), "propertyName");
		}

		[TestMethod]
		public void UpperCaseNamingStrategyTests() {
			IPropertyNamingStrategy strategy = new UpperCaseNamingStrategy();
			TestInstance instance = new TestInstance();
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("PropertyName")[0]), "PROPERTY_NAME");
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("propertyName")[0]), "PROPERTY_NAME");
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("PROPERTY_NAME")[0]), "PROPERTY_NAME");
		}

		[TestMethod]
		public void SnakeCaseNamingStrategyTests() {
			IPropertyNamingStrategy strategy = new SnakeCaseNamingStrategy();
			TestInstance instance = new TestInstance();
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("PropertyName")[0]), "property_name");
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("propertyName")[0]), "property_name");
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("PROPERTY_NAME")[0]), "property_name");
		}

		[TestMethod]
		public void KebabCaseNamingStrategyTests() {
			IPropertyNamingStrategy strategy = new KebabCaseNamingStrategy();
			TestInstance instance = new TestInstance();
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("PropertyName")[0]), "property-name");
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("propertyName")[0]), "property-name");
			Assert.AreEqual(strategy.GetName(instance.GetType().GetMember("PROPERTY_NAME")[0]), "property-name");
		}

	}
}
