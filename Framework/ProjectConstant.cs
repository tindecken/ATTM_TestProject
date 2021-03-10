using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestProject.Framework
{
    public class ProjectConstant
    {
        private static string sRootDLL = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public static string sRootPath = Path.GetDirectoryName(sRootDLL);
        private static DirectoryInfo drInfoRoot = new DirectoryInfo(sRootPath);
        public static string sProjectPath = drInfoRoot.Parent.Parent.FullName;
        public static string sBufferFile = Path.Combine(sProjectPath, "ReleaseSrc", @"TestRepo", "TestData", "Buffer.xml");
        public static string sLog4Net = Path.Combine(sProjectPath, "Framework", "log4net.config.xml");
        public static string sWebDriverPath = Path.Combine(sProjectPath, "ReleaseSrc", @"TestRepo", "WebDriver");
    }
}
