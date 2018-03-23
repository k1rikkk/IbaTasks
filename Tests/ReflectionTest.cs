using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection;

namespace Tests
{
    [TestClass]
    public class ReflectionTest
    {
        [Serializable]
        public class Test
        {
            public float Value { get; set; }
            public int IntValue => (int)Value;

            public Test(float value) => Value = value;
            public Test() => Value = (float)new Random().NextDouble() * 10;

            public void Add(float delta) => Value += delta;
            public void Reset() => Value = 0;
        }

        private string Join<T>(IEnumerable<T> data) => string.Join(", ", data);

        [TestMethod]
        public void TypeInfo_Attributes()
        {
            TypeInfo info = new TypeInfo(typeof(Test));
            Assert.AreEqual("SerializableAttribute", Join(info.Attributes.Select(ad => ad.AttributeType.Name)));
        }

        [TestMethod]
        public void TypeInfo_Constructors()
        {
            TypeInfo info = TypeInfo.New<Test>();
            Assert.AreEqual("1, 0", Join(info.Constructors.Select(mi => mi.GetParameters().Count())));
        }

        [TestMethod]
        public void TypeInfo_Methods()
        {
            TypeInfo info = new TypeInfo(typeof(Test));
            Assert.AreEqual("Add, Reset, ToString, Equals, GetHashCode, GetType", Join(info.Methods.Select(mi => mi.Name)));
        }

        [TestMethod]
        public void TypeInfo_Props()
        {
            TypeInfo info = TypeInfo.New<Test>();
            Assert.AreEqual("Value, IntValue", Join(info.Properties.Select(pi => pi.Name)));
        }
    }
}
