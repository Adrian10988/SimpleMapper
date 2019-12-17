using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Models.DefaultCopy;

namespace Tests.Models.ConvertCopy
{
    [ImplicitConversion]
    public class NonNullableFoo
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
