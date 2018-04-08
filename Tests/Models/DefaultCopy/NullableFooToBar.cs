using SimpleMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models.DefaultCopy
{
    public class NullableFooToBar : BaseMappable<Bar, NullableFooToBar>
    {
        public string FirstName { get; set; }
        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
