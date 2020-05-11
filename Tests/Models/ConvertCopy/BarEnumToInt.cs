using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.ConvertCopy
{
    [MapDestination(typeof(FooEnumToInt))]
    public class BarEnumToInt
    {
        public TestEnum Enum { get; set; }
    }
}
