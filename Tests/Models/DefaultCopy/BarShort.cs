using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.DefaultCopy
{
    [MapDestination(typeof(FooShort))]
    public class BarShort
    {
        public short Day { get; set; }
    }
}
