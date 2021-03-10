using NUnit.Framework;
using System;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RunTypeAttribute : PropertyAttribute
    {
        public RunTypeAttribute(string value) : base(value) { }
    }
}