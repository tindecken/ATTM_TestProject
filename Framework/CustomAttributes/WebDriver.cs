using NUnit.Framework;
using System;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class WebDriverAttribute : PropertyAttribute
    {
        public WebDriverAttribute(string value) : base(value) { }
    }
}
