using NUnit.Framework;
using System;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TeamAttribute : PropertyAttribute
    {
        public TeamAttribute(string value) : base(value) { }
    }
}