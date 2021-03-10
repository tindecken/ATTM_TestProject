using NUnit.Framework;
using System;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestCaseIdAttribute : PropertyAttribute
    {
        public TestCaseIdAttribute(string value) : base(value) { }
    }
}
