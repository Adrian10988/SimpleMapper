using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.ConvertCopy
{
    [MapDestination(typeof(FooBoolToEnum))]
    public class BarBoolToEnum
    {
        public bool Enum { get; set; }
    }
}
