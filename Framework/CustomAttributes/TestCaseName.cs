using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestCaseNameAttribute : PropertyAttribute
    {
        public TestCaseNameAttribute(string value) : base(value) { }
    }
}
