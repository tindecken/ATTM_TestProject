using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using TestProject.Framework;
using TestProject.Framework.CustomAttributes;
using TestProject.Keywords;
using TestProject.Framework.WrapperFactory;
using TestProject.Keywords.Saucedemo;

namespace TestProject.TestCases
{
	[TestFixture]
	class ts01 : SetupAndTearDown
	{
		static int RunId;

		[OneTimeSetUp]
		public void ClassSetup()
		{
			TestExecutionContext.CurrentContext.CurrentTest.Properties.Add("RunId", RunId);
		}

		[OneTimeTearDown]
		public void ClassTearDown()
		{
		}

		[Test, Timeout(3600000), Order(1)]
		[TestCaseId("tc18")]
		[TestCaseName("test case 18")]
		[Description("Description of test case 18")]
		[Category("Category1")]
		[TestSuite("ts01")]
		[TestGroup("tg01")]
		[IsDebug("false")]
		[RunType("Debug")]
		[Author("")]
		[Team("")]
		[RunOwner("HVNLT091")]
		[TestCaseType("TimeShift")]
		[WebDriver("Chrome2")]
		[WorkItem("WorkItem of testcase 18")]
		// test case 18
		public void tc18()
		{
			WebDriverFactory.InitBrowser("Chrome2");
			CommonKeyword Chrome2_CommonKeyword = new CommonKeyword(WebDriverFactory.Driver2);
			SauceDemoLogin Nokia8.1_SauceDemoLogin = new SauceDemoLogin();
			CommonKeyword Win_CommonKeyword = new CommonKeyword();
			// ------------------------------------------------------

			// Teardown
			AdditionalTearDown(() => Chrome2_CommonKeyword.CombineVariables("zzz", "z1", "z2", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null));
			AdditionalTearDown(() => Nokia8.1_SauceDemoLogin.Login("tindecken", "rivaldo", null, null, null));
			AdditionalTearDown(() => Win_CommonKeyword.GoToUrl("http://tindecken.com", null));
			// ------------------------------------------------------

		}

	}
}

