using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.DefaultCopy
{
    [MapDestination(typeof(NullableBar))]
    public class NullableFoo
    {
        public string FirstName { get; set; }
        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
