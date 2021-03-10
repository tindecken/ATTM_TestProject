using NUnit.Framework;
using System;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class IsDebugAttribute : PropertyAttribute
    {
        public IsDebugAttribute(string value) : base(value) { }
    }
}
