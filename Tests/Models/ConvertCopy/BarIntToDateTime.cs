using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.ConvertCopy
{
    [MapDestination(typeof(FooIntToDateTime))]
    public class BarIntToDateTime
    {
        public int Property { get; set; }
    }
}
