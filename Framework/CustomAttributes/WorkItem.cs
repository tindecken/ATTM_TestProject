using NUnit.Framework;
using System;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class WorkItemAttribute : PropertyAttribute
    {
        public WorkItemAttribute(string value) : base(value) { }
    }
}
