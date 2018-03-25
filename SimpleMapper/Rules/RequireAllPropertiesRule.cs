using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShipBob.Mapper.Models;
using ShipBob.Mapper.Utilities;

namespace SimpleMapper.Rules
{
    public class RequireAllPropertiesRule : IClassLevelRule
    {
        private readonly IGetProperties _getProps;
        public RequireAllPropertiesRule(IGetProperties getProps)
        {
            _getProps = getProps;
        }

        public void Run(ClassMappingConfiguration config, Type from, Type to, object inObject = null)
        {
            if (config.RequireAllProperties)
            {
                var fromProps = _getProps.Get(from).Select(a => a.Name).ToList();
                var toProps = _getProps.Get(to).Select(a => a.Name).ToList();

                if (fromProps.Except(toProps).Any())
                {
                    throw new MissingMemberException(@"There are missing properties in one of the mapping targets. If this is not desired behavior please remove 
any class level attributes entitled [RequireAllPropertiesAttribute]");
                }
            }
        }
    }
}
