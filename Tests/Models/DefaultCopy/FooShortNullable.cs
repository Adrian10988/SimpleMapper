using SimpleMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.DefaultCopy
{
    public class FooShortNullable : BaseMappable<BarShortNullable, FooShortNullable>
    {
        public short? Day { get; set; }
    }
}
