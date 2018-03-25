using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapper.Test.Models.DefaultCopy
{
    public class FooInvalidCastException : BaseMappable<FooInvalidCastException, BarInvalidCast>
    {
        public string InvalidCast { get; set; }
    }
}
