using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleMapper;
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

            var fooMapResult = Mapper.Copy<Bar, Foo>(bar);
            var boxMapResult = Mapper.Copy<Bar, Box>(bar);

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

            var data = Mapper.Copy<Bar, FooRequireAllProperties>(bar);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DefaultCopy_RejectNullReferenceClassLevel()
        {
            var d = Mapper.Copy<Bar, FooRejectNullReferences>(null);
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

            var data = Mapper.Copy<Bar, FooRejectNullReferences>(bar);
        }

        [TestMethod]
        public void DefaultCopy_ReturnNullWhenPassedNullType()
        {
            var data = Mapper.Copy<Foo, Bar>(null);

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

            var fooMapResult = Mapper.Copy<Bar, FooMapFrom>(bar);

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

            var data = Mapper.Copy<NullableBar, NullableFoo>(nBar);

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

            var data = Mapper.Copy<NullableBar, NonNullableFoo>(nBar);
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

            var data = Mapper.Copy<Bar, NullableFooToBar>(bar);

            Assert.AreEqual(bar.FirstName, data.FirstName);
            Assert.IsNotNull(data.Age);
            Assert.AreEqual(bar.Age, data.Age);
        }

        [TestMethod]
        public void DefaultCopy_Short_To_Short()
        {
            var bar = new BarShort()
            {
                Day = 5
            };

            var data = Mapper.Copy<BarShort, FooShort>(bar);

            Assert.AreEqual(bar.Day, data.Day);
        }


        [TestMethod]
        public void DefaultCopy_Short_To_Short_WithNullableProps()
        {
            var bar = new BarShortNullable()
            {
                Day = 5
            };

            var data = Mapper.Copy<BarShortNullable, FooShortNullable>(bar);

            Assert.AreEqual(bar.Day, data.Day);

            bar.Day = null;

            data = Mapper.Copy<BarShortNullable, FooShortNullable>(bar);

            Assert.IsNull(data.Day);
        }

        [TestMethod]
        public void DefaultCopy_Short_To_Short_WithNullableProps_MapFrom()
        {
            var bar = new BarShortMapFrom()
            {
                DayNumber = 5
            };

            var mapSlave = new FooShortMapFrom();

            var data = Mapper.Copy<BarShortMapFrom, FooShortMapFrom>(bar);

            Assert.AreEqual(bar.DayNumber, data.Day);

            bar.DayNumber = null;

            data = Mapper.Copy<BarShortMapFrom, FooShortMapFrom>(bar);

            Assert.IsNull(data.Day);
        }

    }
}
