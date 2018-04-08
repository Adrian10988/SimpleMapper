using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShipBob.Mapper.Test.Models.ConvertCopy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBob.Mapper.Test
{
    [TestClass]
    public class ConversionCopyIntegrationTests
    {
        [TestMethod]
        public void Parse_HappyPath()
        {
            var barParse = new BarParse()
            {
                Age = "29",
                GPA = "3.0",
                SecondsAlive = "1234567",
                TimeSpanAlive = DateTime.Now - DateTime.Parse("10/09/1988"),
                Birthdate = DateTime.Parse("10/09/1988"),
                FirstName = "Adrian",
                IsHappy = true,
                MoneyToTheWallet = "1800.23"
            };

            var mapSlave = new FooParse();
            var result = mapSlave.Map(barParse);

            Assert.AreEqual(result.Age, 29);
            Assert.AreEqual(result.GPA, 3);
            Assert.AreEqual(result.MoneyToTheWallet, 1800.23M);
            Assert.AreEqual(result.SecondsAlive, 1234567);
        }

        [TestMethod]
        public void ToString_HappyPath()
        {
            var bar = new Bar()
            {
                Age = 10
            };

            var mapSlave = new Foo();

            var data = mapSlave.Map(bar);

            Assert.IsTrue(data.Age == "10");
        }
    }
}
