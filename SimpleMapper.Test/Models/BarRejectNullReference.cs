using ShipBob.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBob.Mapper.Test.Models
{
    [RejectNullReferences]
    public class BarRejectNullReference : BaseMappable<BarRejectNullReference, FooMissingMember>
    {
        public string A { get; set; }
    }
}
