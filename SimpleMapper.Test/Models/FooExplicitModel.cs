using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBob.Mapper.Test.Models
{
    public class FooExplicitModel : BaseMappable<FooExplicitModel, BarExplicitModel>
    {
        [MapTo(PropertyName = "A2")]
        public string A1 { get; set; }
        [MapTo(PropertyName = "B2")]
        public int B1 { get; set; }
        [MapTo(PropertyName = "C2")]
        public double C1 { get; set; }
        [MapTo(PropertyName = "D2")]
        public decimal D1 { get; set; }
        [MapTo(PropertyName = "E2")]
        public bool E1 { get; set; }
        [MapTo(PropertyName = "F2")]
        public long F1 { get; set; }
    }
}
