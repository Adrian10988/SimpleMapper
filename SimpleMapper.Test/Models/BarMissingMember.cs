using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapper.Test.Models
{
    [RequireAllProperties]
    public class BarMissingMember: BaseMappable<BarMissingMember, FooMissingMember>
    {
        public string A { get; set; }
        public string B { get; set; }
    }
}
