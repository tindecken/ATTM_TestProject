using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using TestProject.Framework.MongoDB.Helpers;
using TestProject.Framework.MongoDB.Models;
using TestProject.Framework.WrapperFactory;

namespace TestProject.Framework
{
    public class SetupAndTearDown
    {
        private Action _additionalTearDown;
        private string _tcMongoId = string.Empty;
        [SetUp]
        public void Setup()
        {
            //MongoDBHelpers.InitDebugRecord()
            //Console.WriteLine("Setup of Test Case");
            string runType = TestContext.CurrentContext.Test.Properties.Get("RunType")?.ToString();
            switch (runType.ToUpper())
            {
                case "DEBUG":
                    DebugTest debugTest = new DebugTest()
                    {
                        TestCaseId = TestContext.CurrentContext.Test.Properties.Get("TestCaseId")?.ToString(),
                        TestCaseName = TestContext.CurrentContext.Test.Properties.Get("TestCaseName")?.ToString(),
                        Description = TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString(),
                        Category = TestContext.CurrentContext.Test.Properties.Get("Category")?.ToString(),
                        TestSuite = TestContext.CurrentContext.Test.Properties.Get("TestSuite")?.ToString(),
                        TestGroup = TestContext.CurrentContext.Test.Properties.Get("TestGroup")?.ToString(),
                        Team = TestContext.CurrentContext.Test.Properties.Get("Team")?.ToString(),
                        StartAt = DateTime.Now,
                        RunMachine = Environment.MachineName,
                        WorkItem = TestContext.CurrentContext.Test.Properties.Get("WorkItem")?.ToString(),
                        Status = TestContext.CurrentContext.Result.Outcome.Status.ToString(),
                        TestCaseType = TestContext.CurrentContext.Test.Properties.Get("TestCaseType")?.ToString(),
                    };

                    //TestCase Info
                    Console.WriteLine(
                        $"---------------------{new string('-', debugTest.TestCaseId.Length)}--{new string('-', debugTest.TestCaseName.Length)}-------");
                    Console.WriteLine(
                        $"------ Run TestCase: {debugTest.TestCaseId}: {debugTest.TestCaseName} ------");
                    Console.WriteLine(
                        $"---------------------{new string('-', debugTest.TestCaseId.Length)}--{new string('-', debugTest.TestCaseName.Length)}-------");
                    Console.WriteLine("");

                    debugTest.Log = $"{DateTime.Now} - [Setup]: -------- Setup --------";
                    debugTest.Log += "\nTest Case attributes:";
                    IList<string> lstPros = TestContext.CurrentContext.Test.Properties.Keys.ToList<string>();
                    foreach (var key in lstPros)
                    {
                        if (!key.Equals("WebDriver")) //WebDriver attribute is multiple, so need to get list of it before action
                        {
                            Console.WriteLine($"[{key}]: {TestContext.CurrentContext.Test.Properties.Get(key)}");
                            debugTest.Log += $"\n[{key}]: {TestContext.CurrentContext.Test.Properties.Get(key)}";
                        }
                        else
                        {
                            IList lstDriver = (IList)TestContext.CurrentContext.Test.Properties["WebDriver"];
                            foreach (string driver in lstDriver)
                            {
                                Console.WriteLine($"[{key}]: {driver}");
                                debugTest.Log += $"\n[{key}]: {driver}";
                            }
                        }
                    }

                    debugTest.Log += "\n";
                    _tcMongoId = MongoDBHelpers.InitDebugRecord(debugTest);
                    TestExecutionContext.CurrentContext.CurrentTest.Properties.Set("Id", _tcMongoId);
                    break;
                case "REGRESSION":
                    // TODO
                    break;
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Logger.Fail();
            }

            try
            {
                _additionalTearDown?.Invoke();
            }
            catch (Exception ex)
            {
                Logger.FailInTearDown(ex);
                Assert.Fail($"{ex.GetType()}: ${ex.Message}");
            }
            finally
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                {
                    Logger.Pass();
                }
                //if isDebug = don't close webdrivers
                var isDebug = TestContext.CurrentContext.Test.Properties.Get("IsDebug").ToString().ToUpper()
                    .Equals("TRUE");
                if (!isDebug)
                {
                    IList lstDriverName = (IList) TestContext.CurrentContext.Test.Properties["WebDriver"];
                    foreach (string dv in lstDriverName)
                    {
                        switch (dv.Substring(dv.Length - 1))
                        {
                            case "1":
                                if (WebDriverFactory.Driver1 != null) WebDriverFactory.Driver1.Quit();
                                WebDriverFactory.Driver1 = null;
                                break;
                            case "2":
                                if (WebDriverFactory.Driver2 != null) WebDriverFactory.Driver2.Quit();
                                WebDriverFactory.Driver2 = null;
                                break;
                            case "3":
                                if (WebDriverFactory.Driver3 != null) WebDriverFactory.Driver3.Quit();
                                WebDriverFactory.Driver3 = null;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        protected void AdditionalTearDown(Action action)
        {
            _additionalTearDown += action;
        }
    }
}
