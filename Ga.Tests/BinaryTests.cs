using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ga.Infrastructure;

namespace Ga.Tests
{
    [TestClass]
    public class BinaryTests
    {
        [TestMethod]
        public void Can_Parse_Int()
        {
            int number = 2;
            Binary b = new Binary(number);
            var resultBin = b.ToString();
            var resultInt = b.NumericValue;
            Assert.AreEqual("010", resultBin, "int to bin failed");
            Assert.AreEqual(number, resultInt, "bin to int failed");
        }

        [TestMethod]
        public void Can_Parse_Negative_Int()
        {
            int number = -2;
            Binary b = new Binary(number);
            var resultBin = b.ToString();
            var resultInt = b.NumericValue;
            Assert.AreEqual("110", resultBin, "int to bin failed");
            Assert.AreEqual(number, resultInt, "bin to int failed");
        }

        [TestMethod]
        public void Can_Parse_Double()
        {
            double number = 2.2;
            Binary b = new Binary(number);
            var resultBin = b.ToString();
            var resultDouble = b.NumericValue;
            Assert.AreEqual("01010", resultBin, "double to bin failed");
            Assert.AreEqual(number, resultDouble, "bin to double failed");
        }

        [TestMethod]
        public void Can_Parse_Negative_Double()
        {
            double number = -2.2;
            Binary b = new Binary(number);
            var resultBin = b.ToString();
            var resultDouble = b.NumericValue;
            Assert.AreEqual("11010", resultBin, "double to bin failed");
            Assert.AreEqual(number, resultDouble, "bin to double failed");
        }

        [TestMethod]
        public void Can_Parse_Double_Without_Fraction()
        {
            double number = -2.0;
            Binary b = new Binary(number);
            var resultBin = b.ToString();
            var resultDouble = b.NumericValue;
            Assert.AreEqual("110", resultBin, "double to bin failed");
            Assert.AreEqual(number, resultDouble, "bin to double failed");
        }

        [TestMethod]
        public void Can_Binary_Add_Integers()
        {
            Binary b1 = new Binary(2);
            Binary b2 = new Binary(-3);
            var b3 = b1 & b2;
            var result = b3.ToString();
            Assert.AreEqual("010", result, "bin ADD failed");
        }

        [TestMethod]
        public void Can_Binary_Or_Integers()
        {
            Binary b1 = new Binary(2);
            Binary b2 = new Binary(-3);
            var b3 = b1 | b2;
            var result = b3.ToString();
            Assert.AreEqual("111", result, "bin OR failed");
        }

        [TestMethod]
        public void Can_Represent_Not_Max_Integer()
        {
            int number = 2;
            Binary b = new Binary(number, 0, 8, 4);
            var resultBin = b.ToString();
            var resultInt = b.NumericValue;
            Assert.AreEqual("00010", resultBin, "double to bin failed");
            Assert.AreEqual(number, resultInt, "bin to double failed");
        }

        [TestMethod]
        public void Can_Represent_Not_Max_Double()
        {
            double number = 2.2;
            Binary b = new Binary(number, 1, 8, 4);
            var resultBin = b.ToString();
            var resultInt = b.NumericValue;
            Assert.AreEqual("000100010", resultBin, "double to bin failed");
            Assert.AreEqual(number, resultInt, "double to int failed");
        }

        [TestMethod]
        public void Can_Concat_Binaries()
        {
            var b1 = new Binary(2);
            var b2 = new Binary(2);
            var result = b1.Concat(b2).ToString();
            Assert.AreEqual("010010", result, "bin concat failed");
        }

        [TestMethod]
        public void Can_Parse_String()
        {
            var str = "010";
            var b = new Binary(str);
            var intResult = b.NumericValue;
            var strResult = b.ToString();
            Assert.AreEqual(str, strResult, "str to bin failed");
            Assert.AreEqual(2, intResult, "bin from str to int failed");
        }

        [TestMethod]
        public void Can_Parse_String_WithScale()
        {
            var str = "1100010";
            var b = new Binary(str, 1);
            var intResult = b.NumericValue;
            var strResult = b.ToString();
            Assert.AreEqual(str, strResult, "str to bin failed");
            Assert.AreEqual(-2.2, intResult, "bin from str to int failed");
        }
    }
}
