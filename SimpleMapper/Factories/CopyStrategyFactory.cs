using ShipBob.Mapper.CopyStrategies;
using ShipBob.Mapper.Models;
using ShipBob.Mapper.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper.Factories
{
    public class CopyStrategyFactory : ICopyStrategyFactory
    {
        public CopyStrategyFactory()
        {
        }

        public ICopyStrategy GetStrategy(ClassMappingConfiguration classConfig, PropertyMappingConfiguration propConfig)
        {
            if (propConfig.Bypass)
            {
                return new BypassCopyStrategy();
            }


            if (classConfig.ConvertPrimitives)
            {
                
                if (propConfig.RejectNullReferences)
                {
                    return new ConvertCopyStrategy(new List<IPropertyLevelRule>()
                    {
                        new RejectNullReferencesPropertyLevelRule()
                    });
                }
                else
                {
                    return new ConvertCopyStrategy(null);
                }
            }
            else
            {
                if (propConfig.RejectNullReferences)
                {
                    return new DefaultCopyStrategy(new List<IPropertyLevelRule>()
                    {
                        new RejectNullReferencesPropertyLevelRule()
                    });
                }
                else
                {
                    return new DefaultCopyStrategy(null);
                }
            }
            

            
        }
    }
}
