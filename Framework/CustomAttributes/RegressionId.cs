using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RegressionIdAttribute : PropertyAttribute
    {
        public RegressionIdAttribute(string value) : base(value) { }
    }
}
