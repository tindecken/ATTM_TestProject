using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TestProject.Framework.MongoDB.Helpers;
using TestProject.Framework.MongoDB.Models;

namespace TestProject.Framework
{
    public static class Logger
    {
        private static DebugTest _debugTest = new DebugTest();
        private static RegressionTest _regressionDoc = new RegressionTest();
        private static string _runType = string.Empty;
        static Logger()
        {
        }

        public static void Info(string message)
        {
            GetTestCaseInfo();
            
            switch (_runType.ToUpper())
            {
                case "DEBUG":
                    // Get call stack
                    StackTrace stackTrace = new StackTrace();
                    // Get calling method name
                    var methodName = stackTrace.GetFrame(1)?.GetMethod()?.Name;
                    if (methodName != null && methodName.Contains(_debugTest.TestCaseId))
                    {
                        _debugTest.Log = $"{DateTime.Now}: {message}";
                        Console.WriteLine($"{DateTime.Now}: {message}");
                    }
                    else
                    {
                        _debugTest.Log = $"{DateTime.Now} - [{methodName}]: {message}";
                        Console.WriteLine($"{DateTime.Now} - [{methodName}]: {message}");
                    }
                    MongoDBHelpers.AddInfoForDebugCase(_debugTest);
                    break;
                case "REGRESSION":
                    break;
            }
        }

        public static void Pass()
        {
            GetTestCaseInfo();

            switch (_runType.ToUpper())
            {
                case "DEBUG":
                    // Get call stack
                    StackTrace stackTrace = new StackTrace();
                    // Get calling method name
                    _debugTest.EndAt = DateTime.Now;
                    _debugTest.ExecuteTime = (_debugTest.EndAt - _debugTest.StartAt).Seconds;
                    MongoDBHelpers.UpdatePassForDebugCase(_debugTest);
                    break;
                case "REGRESSION":
                    break;
            }
        }

        public static void Fail()
        {
            GetTestCaseInfo();
            switch (_runType.ToUpper())
            {
                case "DEBUG":
                    ObjectId debugScreenShotId = MongoDBHelpers.TakeScreenShotAndUpload($"debug_{_debugTest.TestCaseId}");
                    // Get call stack
                    StackTrace stackTrace = new StackTrace();
                    // Get calling method name
                    var methodName = stackTrace.GetFrame(1)?.GetMethod()?.Name;
                    if (methodName != null && methodName.ToUpper().Equals("TEARDOWN"))
                    {
                        _debugTest.ErrorMessage = $"{TestContext.CurrentContext.Result.Message} {TestContext.CurrentContext.Result.StackTrace}";
                        Console.WriteLine($"{DateTime.Now}: {TestContext.CurrentContext.Result.Message} {TestContext.CurrentContext.Result.StackTrace}");
                    }
                    else
                    {
                        _debugTest.ErrorMessage = $"[{methodName}]: {TestContext.CurrentContext.Result.Message} {TestContext.CurrentContext.Result.StackTrace}";
                        Console.WriteLine($"{DateTime.Now} - [{methodName}]: {TestContext.CurrentContext.Result.Message} {TestContext.CurrentContext.Result.StackTrace}");
                    }

                    _debugTest.EndAt = DateTime.Now;
                    _debugTest.ExecuteTime = (_debugTest.EndAt - _debugTest.StartAt).Seconds;
                    _debugTest.Log += $"\n{DateTime.Now}: {_debugTest.ErrorMessage}";
                    _debugTest.ErrorScreenshot = debugScreenShotId.ToString();
                    MongoDBHelpers.UpdateFailForDebugCase(_debugTest);
                    break;
                case "REGRESSION":
                    ObjectId regressionScreenShotId = MongoDBHelpers.TakeScreenShotAndUpload($"debug_{_debugTest.TestCaseId}");
                    break;
            }
        }

        /// <summary>
        /// Using in case of steps in teardown failed, it will take screenshot but store in property: ErrorTearDownScreenshot
        /// </summary>
        /// <param name="ex">Exception</param>
        public static void FailInTearDown(Exception ex)
        {
            GetTestCaseInfo();
            ObjectId screenShotId = MongoDBHelpers.TakeScreenShotAndUpload(_debugTest.TestCaseId);

            switch (_runType.ToUpper())
            {
                case "DEBUG":
                    Console.WriteLine($"{DateTime.Now}: {ex.GetType()} - {ex.Message}");
                    _debugTest.Status = TestStatus.Failed.ToString();
                    _debugTest.EndAt = DateTime.Now;
                    _debugTest.ExecuteTime = (_debugTest.EndAt - _debugTest.StartAt).Seconds;
                    _debugTest.Log += $"\n{DateTime.Now}: {ex.GetType()} - {ex.Message}";
                    _debugTest.ErrorMessage += $"\n [Failed in teardown]: {ex.GetType()} - {ex.Message}";
                    _debugTest.ErrorTearDownScreenshot = screenShotId.ToString();
                    MongoDBHelpers.UpdateFailForDebugCase(_debugTest);
                    break;
                case "REGRESSION":
                    break;
            }
        }
        private static void GetTestCaseInfo()
        {
            _debugTest.Id = TestContext.CurrentContext.Test.Properties.Get("Id")?.ToString();
            _debugTest.TestCaseId = TestContext.CurrentContext.Test.Properties.Get("TestCaseId")?.ToString();
            _debugTest.Status = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            _runType = TestContext.CurrentContext.Test.Properties.Get("RunType")?.ToString();
        }
    }
}
