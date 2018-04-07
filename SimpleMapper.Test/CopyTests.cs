using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShipBob.Mapper.Test.Models;
using ShipBob.Mapper.Test.Models.DefaultCopy;

namespace SimpleMapper.Test
{
    [TestClass]
    public class CopyTests
    {

        [TestMethod]
        public void DefaultCopy_HappyPath()
        {
            var bar = new Bar()
            {
                FirstName = "Adrian",
                Age = 29,
                Birthdate = new DateTime(1988, 10, 9),
                GPA = 3.0,
                IsHappy = true,
                MoneyToTheWallet = 1789.23M,
                SecondsAlive = 102928392839383928,
                TimeSpanAlive = DateTime.Now  - new DateTime(1988, 10, 9)
            };

            var mapSlave = new Foo();
            var mappedResult = mapSlave.Map<Foo>(bar);

            Assert.AreEqual(bar.FirstName, mappedResult.FirstName);
            Assert.AreEqual(bar.Age, mappedResult.Age);
            Assert.AreEqual(bar.Birthdate, mappedResult.Birthdate);
            Assert.AreEqual(bar.GPA, mappedResult.GPA);
            Assert.AreEqual(bar.IsHappy, mappedResult.IsHappy);
            Assert.AreEqual(bar.MoneyToTheWallet, mappedResult.MoneyToTheWallet);
            Assert.AreEqual(bar.SecondsAlive, mappedResult.SecondsAlive);
            Assert.AreEqual(bar.TimeSpanAlive, mappedResult.TimeSpanAlive);
        }
    }
}
