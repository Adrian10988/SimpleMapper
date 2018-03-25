using ShipBob.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBob.Mapper.Test.Models.DefaultCopy
{
    public class Bar : BaseMappable<Bar, Foo>
    {
        public string A { get; set; }
        public int B { get; set; }
        public double C { get; set; }
        public decimal D { get; set; }
        public long E { get; set; }

        [Bypass]
        public double ShouldBypass { get; set; }
        public string DoesNotExistInFoo { get; set; }
    }
}
