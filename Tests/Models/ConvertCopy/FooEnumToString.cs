using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.ConvertCopy
{
    [ImplicitConversion]
    public class FooEnumToBool : BaseMappable<BarEnumToBool, FooEnumToBool>
    {
        public bool Enum { get; set; }
    }
}
