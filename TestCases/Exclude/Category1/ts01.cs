using System;
using NUnit.Framework;
using TestProject.Framework;
using TestProject.Framework.CustomAttributes;
using TestProject.Framework.WrapperFactory;

namespace TestProject.TestCases.Exclude.Category1
{
    [TestFixture]
	public class ts01 : SetupAndTearDown
	{
		static int RunId;

		[OneTimeSetUp]
		public void Init()
        {
            //throw new ApplicationException("fasfs");
            //throw new ApplicationException("fasfs");
			Console.WriteLine("ClassSetup-------------");
			//TestExecutionContext.CurrentContext.CurrentTest.Properties.Add("RunId", RunId);
		}

		[OneTimeTearDown]
		public void ClassTearDown()
		{
            Console.WriteLine("ClassTearDown-------------");
		}

		[Test, Timeout(3600000), Order(1)]
		[TestCaseId("tc01")]
		[TestCaseName("test case 1")]
		[Description("Description of test case 1")]
		[Category("Category1")]
		[TestSuite("ts01")]
		[TestGroup("tg01")]
		[IsDebug("false")]
		[RunType("Debug")]
		[Author("")]
		[Team("")]
		[RunOwner("HVNLT091")]
		[TestCaseType("Normal")]
		[WebDriver("Chrome1")]
		[WebDriver("FireFox1")]
		[WorkItem("WorkItem of test case 1")]
		// test case 1
		public void tc01()
		{
            WebDriverFactory.InitBrowser("Chrome1");
            
            //WebDriverFactory.InitBrowser("Chrome2");
            // None_ = new ();
            // Chrome1_ = new (WebDriverFactory.Driver1);
            // FireFox1_ = new (WebDriverFactory.Driver1);
            //// ------------------------------------------------------

            //// Teardown
            AdditionalTearDown(() =>
            {
                //Logger.Info("[TearDown]");
                throw new ApplicationException("xxxxxxxxxxx");
                //Console.WriteLine("[TearDown]");
            });
            //// ------------------------------------------------------

            //None_.CombineVariables("loginPage", "http://automationpractice.com/index.php", "?controller=authentication&back=my-account", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            //Chrome1_.GoToUrl("@loginPage@", null);
            //Assert.Fail("assert fail");
            Assert.AreEqual("a", "a");
            //throw new ApplicationException("heheeeeeeeeeeeeeeeeeeeeeeee");
        }

        [Test, Timeout(3600000), Order(2)]
        [TestCaseId("tc02")]
        [TestCaseName("test case 2")]
        [Description("Description of test case 2")]
        [Category("Category1")]
        [TestSuite("ts01")]
        [TestGroup("tg01")]
        [IsDebug("false")]
        [RunType("Regression")]
        [Author("")]
        [Team("")]
        [RunOwner("HVNLT091")]
        [TestCaseType("Normal")]
        [WebDriver("Chrome1")]
        [WebDriver("FireFox1")]
        [WorkItem("WorkItem of test case 1")]
        // test case 2
        public void tc02()
        {
            Logger.Info("heheeeeeeeeeeeeeeeeee");
			//WebDriverFactory.InitBrowser("Chrome1");
            //WebDriverFactory.InitBrowser("Chrome2");
            // None_ = new ();
            // Chrome1_ = new (WebDriverFactory.Driver1);
            // FireFox1_ = new (WebDriverFactory.Driver1);
            //// ------------------------------------------------------

            //// Teardown
            //AdditionalTearDown(() => FireFox1_.Login("tindecken", "rivaldo", null, null, null));
            //// ------------------------------------------------------

            //None_.CombineVariables("loginPage", "http://automationpractice.com/index.php", "?controller=authentication&back=my-account", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            //Chrome1_.GoToUrl("@loginPage@", null);
        }

	}
}

