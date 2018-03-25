using ShipBob.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBob.Mapper.Test.Models
{
    public class FooNullProperty : BaseMappable<FooNullProperty, BarNullProperty>
    {
        [RejectNullReferences]
        public string NullProp { get; set; }
    }
}
