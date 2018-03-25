using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ShipBob.Mapper.Models;

namespace SimpleMapper.Rules
{
    public class RejectNullReferencesPropertyLevelRule : IPropertyLevelRule
    {
        public void Run<TOut>(PropertyMappingConfiguration config, object tFrom, TOut tTo, PropertyInfo from, PropertyInfo to)
        {
            if(config.RejectNullReferences && (from.GetValue(tFrom) is null))
            {
                throw new NullReferenceException(@"A null property reference was passed into the mapper. If this is not desired behavior please remove 
any property level attributes entitled [RejectNullReferences]");
            }
        }
    }
}
