using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.ConvertCopy
{
    [MapDestination(typeof(NullableFoo), typeof(NonNullableFoo))]
    public class NullableBar
    {
        public string FirstName { get; set; }
        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
