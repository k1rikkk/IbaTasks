using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringClass;

namespace Tests
{
    [TestClass]
    public class StringClassTest
    {
        [TestMethod]
        public void TextTransformer_Process()
        {
            TextTransformer tt = new TextTransformer("Hello, world!");
            Assert.AreEqual("HELLO, WORLD!", tt.Process());
        }

        [TestMethod]
        public void TextTransformer_Process_Null()
        {
            Assert.AreEqual(TextTransformer.Null, new TextTransformer("").Process());
            Assert.AreEqual(TextTransformer.Null, new TextTransformer(null).Process());
        }
    }
}
