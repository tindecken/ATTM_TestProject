using NUnit.Framework;
using System;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestCaseTypeAttribute : PropertyAttribute
    {
        public TestCaseTypeAttribute(string value) : base(value) { }
    }
}
