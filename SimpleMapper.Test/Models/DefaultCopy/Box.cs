using SimpleMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBob.Mapper.Test.Models.DefaultCopy
{
    public class Box : BaseMappable<Bar, Box>
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public long SecondsAlive { get; set; }
    }
}
