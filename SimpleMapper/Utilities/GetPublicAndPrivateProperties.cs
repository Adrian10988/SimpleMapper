using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleMapper.Utilities
{
    public class GetPublicAndPrivateProperties : IGetProperties
    {
        public IEnumerable<PropertyInfo> Get(Type t)
        {
            return t.GetProperties().ToList();
        }
    }
}
