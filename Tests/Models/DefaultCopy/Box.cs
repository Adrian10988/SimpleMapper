using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models.DefaultCopy
{
    [MapDestination(typeof(Bar))]
    public class Box
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public long SecondsAlive { get; set; }
    }
}
