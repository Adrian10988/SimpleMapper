using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.ConvertCopy
{
    [MapDestination(typeof(FooIntToEnum))]
    public class BarIntToEnum
    {
        public int Enum { get; set; }
    }
}
