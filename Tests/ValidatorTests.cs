using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleMapper.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        [Ignore]
        public void Validate_HappyPath()
        {
            Validator.ValidateMappings(new List<System.Reflection.Assembly>()
            {
                GetType().Assembly
            });
        }
    }
}
