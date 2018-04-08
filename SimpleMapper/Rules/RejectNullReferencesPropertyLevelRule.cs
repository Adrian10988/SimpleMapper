using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SimpleMapper.Models;

namespace SimpleMapper.Rules
{
    public class RejectNullReferencesPropertyLevelRule : IPropertyLevelRule
    {
        public void Run<TOut>(PropertyMappingConfiguration toPropConfig, object tFrom, TOut tTo, PropertyInfo toProp, PropertyInfo fromProp)
        {
            if(toPropConfig.RejectNullReferences && (fromProp.GetValue(tFrom) is null))
            {
                throw new NullReferenceException(@"A null property reference was passed into the mapper. If this is not desired behavior please remove 
the property level attribute entitled [RejectNullReferences] from ["+tTo.GetType().Name+ "].["+toProp.Name+"]");
            }
        }
    }
}
