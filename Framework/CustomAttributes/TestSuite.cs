using NUnit.Framework;
using System;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestSuiteAttribute : PropertyAttribute
    {
        public TestSuiteAttribute(string value) : base(value) { }
    }
}
