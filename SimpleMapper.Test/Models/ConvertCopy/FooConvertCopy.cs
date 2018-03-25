using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapper.Test.Models.ConvertCopy
{
    [ImplicitlyConvertPrimitives]
    public class FooConvertCopy: BaseMappable<FooConvertCopy, BarConvertCopy>
    {
        public string StringToDouble { get; set; }
        public string StringToInt { get; set; }
        public string StringToDecimal { get; set; }
        public string StringToBool { get; set; }
        public string StringToLong { get; set; }
    }
}
