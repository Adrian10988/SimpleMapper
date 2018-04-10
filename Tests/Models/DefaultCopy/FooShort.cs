using SimpleMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.DefaultCopy
{
    public class FooShort : BaseMappable<BarShort, FooShort>
    {
        public short Day { get; set; }
    }
}
