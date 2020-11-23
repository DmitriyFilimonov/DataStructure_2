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

        [TestCase(new int[] { 1, 0, 8, -5, 5 }, 2, 7, new int[] { 1, 0, 7, -5, 5 })]
        [TestCase(new int[] { 1, 0, 8, -5, 5 }, 3, -4, new int[] { 1, 0, 8, -4, 5 })]
        [TestCase(new int[] { 1, 0, 8, -5, 5 }, 4, 18, new int[] { 1, 0, 8, -5, 18 })]
        [TestCase(new int[] { 1, 0, 8, -5, 5 }, 0, 7, new int[] { 7, 0, 8, -5, 5 })]
        [TestCase(new int[] { 1, 0, 8, -5, 5 }, 1, 12, new int[] { 1, 12, 8, -5, 5 })]
        public void SetterTest(int[] inputArr, int index, int value, int[] expectedArr)
        {
            DoubleLinkedList actual = new DoubleLinkedList(inputArr);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArr);
            actual[index] = value;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 0, new int[] { 0 })]
        [TestCase(new int[] { 1 }, 0, new int[] { 1, 0 })]
        [TestCase(new int[] { 1, 0 }, 1, new int[] { 1, 0, 1 })]
        public void PutLastTest(int[] inputList, int value, int[] expectedList)
        {
            DoubleLinkedList actual = new DoubleLinkedList(inputList);
            DoubleLinkedList expected = new DoubleLinkedList(expectedList);
            
            actual.PutLast(value);

            Assert.AreEqual(expected, actual);
        }

    }
}