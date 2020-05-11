using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.ConvertCopy
{
    [MapDestination(typeof(FooEnumToBool))]
    public class BarEnumToBool
    {
        public TestEnum Enum { get; set; }
    }
}
