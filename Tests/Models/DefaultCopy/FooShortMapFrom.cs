using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.DefaultCopy
{
    [MapDestination(typeof(BarShortMapFrom))]
    public class FooShortMapFrom
    {
        [MapFrom(PropertyName ="DayNumber")]
        public short? Day { get; set; }
    }
}
