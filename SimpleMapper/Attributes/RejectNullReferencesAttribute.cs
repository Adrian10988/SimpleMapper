using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper.Attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Property)]
    public class RejectNullReferencesAttribute : Attribute
    {
    }
}
