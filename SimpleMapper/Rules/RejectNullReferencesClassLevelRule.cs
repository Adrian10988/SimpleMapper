using System;
using System.Collections.Generic;
using System.Text;
using SimpleMapper.Models;

namespace SimpleMapper.Rules
{
    public class RejectNullReferencesClassLevelRule : IClassLevelRule
    {
        public void Run(ClassMappingConfiguration config, Type from, Type to, object inObject = null)
        {
            if (config.RejectNullReferences && (inObject is null))
            {
                throw new NullReferenceException(@"A null reference was passed into the mapper. If this is not desired behavior please remove 
the class level attribute [RejectNullReferences] from [" + from.Name + "]");
            }
        }
    }
}
