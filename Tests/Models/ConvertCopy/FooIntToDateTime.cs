using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.ConvertCopy
{
    [ImplicitConversion]
    public class FooIntToDateTime : BaseMappable<BarIntToDateTime, FooIntToDateTime>
    {
        public DateTime Property { get; set; }
    }
}
