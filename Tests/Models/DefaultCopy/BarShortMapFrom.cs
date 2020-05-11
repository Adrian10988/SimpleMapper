using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.DefaultCopy
{
    [MapDestination(typeof(FooShortMapFrom))]
    public class BarShortMapFrom
    {
        public short? DayNumber { get; set; }
    }
}
