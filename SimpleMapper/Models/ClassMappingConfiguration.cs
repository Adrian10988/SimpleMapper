using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper.Models
{
    public class ClassMappingConfiguration
    {
        public bool ConvertPrimitives { get; set; }
        public bool RejectNullReferences { get; set; }
        public bool RequireAllProperties { get; set; }
    }
}
