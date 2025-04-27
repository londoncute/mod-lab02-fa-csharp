using Microsoft.VisualStudio.TestTools.UnitTesting;
using fans;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFA1()
        {
            FA1 fa1 = new FA1();
            
            // Should accept: exactly one 0 and at least one 1
            Assert.IsTrue(fa1.Run("01"));
            Assert.IsTrue(fa1.Run("011"));
            Assert.IsTrue(fa1.Run("101"));
            
            // Should reject
            Assert.IsFalse(fa1.Run("0"));     // no 1s
            Assert.IsFalse(fa1.Run("1"));     // no 0s
            Assert.IsFalse(fa1.Run("001"));   // two 0s
            Assert.IsFalse(fa1.Run("11"));    // no 0s
            Assert.IsNull(fa1.Run("01a"));    // invalid character
        }

        [TestMethod]
        public void TestFA2()
        {
            FA2 fa2 = new FA2();
            
            // Should accept: odd number of 0s and odd number of 1s
            Assert.IsTrue(fa2.Run("01"));
            Assert.IsTrue(fa2.Run("00111"));
            Assert.IsTrue(fa2.Run("101"));
            
            // Should reject
            Assert.IsFalse(fa2.Run("00"));    // even 0s, even 1s
            Assert.IsFalse(fa2.Run("11"));    // even 0s, even 1s
            Assert.IsFalse(fa2.Run("001"));   // odd 0s, even 1s
            Assert.IsFalse(fa2.Run("011"));   // even 0s, odd 1s
            Assert.IsNull(fa2.Run("01a"));    // invalid character
        }

        [TestMethod]
        public void TestFA3()
        {
            FA3 fa3 = new FA3();
            
            // Should accept: contains '11'
            Assert.IsTrue(fa3.Run("11"));
            Assert.IsTrue(fa3.Run("011"));
            Assert.IsTrue(fa3.Run("0011"));
            
            // Should reject
            Assert.IsFalse(fa3.Run("0"));
            Assert.IsFalse(fa3.Run("1"));
            Assert.IsFalse(fa3.Run("101"));
            Assert.IsFalse(fa3.Run("010"));
            Assert.IsNull(fa3.Run("11a"));    
        }
    }
}
