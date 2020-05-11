using SimpleMapper;
using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.ConvertCopy
{
    [ImplicitConversion]
    public class NullableFoo
    {
        public string FirstName { get; set; }
        public string Age { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
