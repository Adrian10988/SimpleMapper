using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.DefaultCopy
{
    [MapDestination(typeof(BarShort))]
    public class FooShort
    {
        public short Day { get; set; }
    }
}
