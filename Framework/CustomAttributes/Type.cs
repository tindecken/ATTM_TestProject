using NUnit.Framework;
using System;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TypeAttribute : PropertyAttribute
    {
        public TypeAttribute(string value) : base(value) { }
    }
}
