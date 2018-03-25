using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBob.Mapper.Test.Models
{
    public class FooReference : BaseMappable<FooReference, BarReference>
    {
        public string ConvertTest { get; set; }
        public FooMissingMember ReferenceObject { get; set; }
    }
}
