using NUnit.Framework;
using System;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestGroupAttribute : PropertyAttribute
    {
        public TestGroupAttribute(string value) : base(value) { }
    }
}
