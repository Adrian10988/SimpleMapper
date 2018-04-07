using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBob.Mapper.Test.Models.DefaultCopy
{
    [RejectNullReferences]
    public class FooRejectNullReferences : BaseMappable<Bar, FooRejectNullReferences>
    {
        [RejectNullReferences]
        public string FirstName { get; set; }
        public int Age { get; set; }
        public long SecondsAlive { get; set; }
        public decimal MoneyToTheWallet { get; set; }
        public double GPA { get; set; }
        public DateTime Birthdate { get; set; }
        public TimeSpan TimeSpanAlive { get; set; }
        public bool IsHappy { get; set; }
    }
}
