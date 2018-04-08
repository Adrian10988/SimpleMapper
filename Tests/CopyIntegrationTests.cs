using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Models;
using Tests.Models.DefaultCopy;

namespace Tests
{
    [TestClass]
    public class CopyTests
    {

        [TestMethod]
        //Testing the fact that we can have two different classes being mapped from the same class
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
                TimeSpanAlive = DateTime.Now  - new DateTime(1988, 10, 9),
                Enum = TestEnum.One
            };

            var fooSlave = new Foo();
            var fooMapResult = fooSlave.Map(bar);

            var boxSlave = new Box();
            var boxMapResult = boxSlave.Map(bar);

            Assert.AreEqual(bar.FirstName, fooMapResult.FirstName);
            Assert.AreEqual(bar.Age, fooMapResult.Age);
            Assert.AreEqual(bar.Birthdate, fooMapResult.Birthdate);
            Assert.AreEqual(bar.GPA, fooMapResult.GPA);
            Assert.AreEqual(bar.IsHappy, fooMapResult.IsHappy);
            Assert.AreEqual(bar.MoneyToTheWallet, fooMapResult.MoneyToTheWallet);
            Assert.AreEqual(bar.SecondsAlive, fooMapResult.SecondsAlive);
            Assert.AreEqual(bar.TimeSpanAlive, fooMapResult.TimeSpanAlive);
            Assert.AreEqual(bar.Enum, fooMapResult.Enum);


            Assert.AreEqual(boxMapResult.Age, bar.Age);
            Assert.AreEqual(boxMapResult.FirstName, bar.FirstName);
            Assert.AreEqual(boxMapResult.SecondsAlive, bar.SecondsAlive);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void DefaultCopy_AllPropertiesRequired()
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
                TimeSpanAlive = DateTime.Now - new DateTime(1988, 10, 9)
            };

            var mapSlave = new FooRequireAllProperties();
            var data = mapSlave.Map(bar);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DefaultCopy_RejectNullReferenceClassLevel()
        {
            var mapSlave = new FooRejectNullReferences();
            var data = mapSlave.Map(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DefaultCopy_RejectNullReferencePropertyLevel()
        {
            var bar = new Bar()
            {
                FirstName = null,
                Age = 29,
                Birthdate = new DateTime(1988, 10, 9),
                GPA = 3.0,
                IsHappy = true,
                MoneyToTheWallet = 1789.23M,
                SecondsAlive = 102928392839383928,
                TimeSpanAlive = DateTime.Now - new DateTime(1988, 10, 9)
            };

            var mapSlave = new FooRejectNullReferences();
            var data = mapSlave.Map(bar);
        }

        [TestMethod]
        public void DefaultCopy_ReturnNullWhenPassedNullType()
        {
            var mapSlave = new Foo();
            var data = mapSlave.Map(null);

            Assert.IsNull(data);
        }

        [TestMethod]
        public void DefaultCopy_MapFromAttribute()
        {
            var bar = new Bar()
            {
                FirstName = "Perez",
                Age = 29,
                Birthdate = new DateTime(1988, 10, 9),
                GPA = 3.0,
                IsHappy = true,
                MoneyToTheWallet = 1789.23M,
                SecondsAlive = 102928392839383928,
                TimeSpanAlive = DateTime.Now - new DateTime(1988, 10, 9)
            };

            var mapSlave = new FooMapFrom();
            var fooMapResult = mapSlave.Map(bar);

            Assert.AreEqual(bar.FirstName, fooMapResult.LastName);
            Assert.AreEqual(bar.Age, fooMapResult.Age);
            Assert.AreEqual(bar.Birthdate, fooMapResult.Birthdate);
            Assert.AreEqual(bar.GPA, fooMapResult.GPA);
            Assert.AreEqual(bar.IsHappy, fooMapResult.IsHappy);
            Assert.AreEqual(bar.MoneyToTheWallet, fooMapResult.MoneyToTheWallet);
            Assert.AreEqual(bar.SecondsAlive, fooMapResult.SecondsAlive);
            Assert.AreEqual(bar.TimeSpanAlive, fooMapResult.TimeSpanAlive);
        }

        [TestMethod]
        public void DefaultCopy_Nullable_HappyPath()
        {
            var nBar = new NullableBar()
            {
                FirstName = "John",
                Age = 12,
                BirthDate = null
            };

            var mapSlave = new NullableFoo();

            var data = mapSlave.Map(nBar);

            Assert.AreEqual(data.FirstName, nBar.FirstName);
            Assert.AreEqual(data.Age, nBar.Age);
            Assert.IsNull(data.BirthDate);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void DefaultCopy_Nullable_To_NonNullable()
        {
            var nBar = new NullableBar()
            {
                FirstName = "John",
                Age = 12,
                BirthDate = null
            };

            var mapSlave = new NonNullableFoo();

            var data = mapSlave.Map(nBar);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void DefaultCopy_NonNullale_To_Nullable()
        {
            var bar = new Bar()
            {
                FirstName = "John",
                Age = 11
            };

            var mapSlave = new NullableFooToBar();

            var data = mapSlave.Map(bar);

            Assert.AreEqual(bar.FirstName, data.FirstName);
            Assert.IsNotNull(data.Age);
            Assert.AreEqual(bar.Age, data.Age);
        }

    }
}
