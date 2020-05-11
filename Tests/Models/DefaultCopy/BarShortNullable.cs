using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.DefaultCopy
{
    [MapDestination(typeof(FooShortNullable))]
    public class BarShortNullable
    {
        public short? Day { get; set; }
    }
}
