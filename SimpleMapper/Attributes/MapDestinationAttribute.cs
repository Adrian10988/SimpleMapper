using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMapper.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class MapDestinationAttribute : Attribute
    {
        public Type[] Types { get; private set; }
        public MapDestinationAttribute(params Type[] types)
        {
            Types = types;
            RejectPrimitiveMappings();
        }

        /// <summary>
        /// Will make sure people do not try to map primitives with this attribute
        /// </summary>
        private void RejectPrimitiveMappings()
        {
            if (Types.Any(a => Constants.TypeWhiteList.Contains(a)))
                throw new ArgumentException($"Only complex types are allowed to be defined as mappable objects");
        }
    }

}
