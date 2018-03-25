using ShipBob.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBob.Mapper.Test.Models
{
    [RequireAllProperties]
    public class BarMissingMember: BaseMappable<BarMissingMember, FooMissingMember>
    {
        public string A { get; set; }
        public string B { get; set; }
    }
}
