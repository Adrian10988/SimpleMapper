using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapper.Test.Models
{
    public class FooNullProperty : BaseMappable<FooNullProperty, BarNullProperty>
    {
        [RejectNullReferences]
        public string NullProp { get; set; }
    }
}
