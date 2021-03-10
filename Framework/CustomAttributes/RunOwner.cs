﻿using NUnit.Framework;
using System;

namespace TestProject.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RunOwnerAttribute : PropertyAttribute
    {
        public RunOwnerAttribute(string value) : base(value) { }
    }
}
