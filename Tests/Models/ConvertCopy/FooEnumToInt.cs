using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.ConvertCopy
{
    [ImplicitConversion]
    public class FooEnumToInt : BaseMappable<BarEnumToInt, FooEnumToInt>
    {
        public int Enum { get; set; }
    }
}
