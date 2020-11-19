using NUnit.Framework;
using System;
using DataStructure_2Lib.DoubleLL;

namespace DoubleLLTests
{
    public class Tests
    {
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        //public void ConstructorTest(int[] constructArray)
        //{
        //    DoubleLinkedList a = new DoubleLinkedList(constructArray);
        //}

        [TestCase(new int[] { 1, 0, 8, -5, 5 }, 2, 8)]
        [TestCase(new int[] { 1, 0, 8, -5, 5 }, 3, -5)]
        [TestCase(new int[] { 1, 0, 8, -5, 5 }, 4, 5)]
        [TestCase(new int[] { 1, 0, 8, -5, 5 }, 0, 1)]
        [TestCase(new int[] { 1, 0, 8, -5, 5 }, 1, 0)]
        public void GetterTest(int[] inputArr, int index, int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList(inputArr);
            int actual = actualList[index];

            Assert.AreEqual(expected, actual);
        }

    }
}