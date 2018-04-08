using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleMapper.Models;
using SimpleMapper.Utilities;

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

                if (toProps.Except(fromProps).Any())
                {
                    throw new MissingMemberException(@"There are missing properties in one of the mapping targets. If this is not desired behavior please remove 
the class level attribute entitled [RequireAllPropertiesAttribute] from class: [" + to.Name + "]");
                }
            }
        }
    }
}
