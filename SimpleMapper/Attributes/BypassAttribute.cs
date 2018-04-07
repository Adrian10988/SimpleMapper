using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    [Obsolete("As of 2.0.0.0 this attribute does not make sense. To bypass an attribute simple ommit it from the definition class")]
    public class BypassAttribute : Attribute
    {
    }
}
