using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapper.Test.Models.DefaultCopy
{
    public class Foo
    {
        public string A { get; set; }
        public int B { get; set; }
        public double C { get; set; }
        public decimal D { get; set; }
        public long E { get; set; }
        public double ShouldBypass { get; set; }
    }
}
