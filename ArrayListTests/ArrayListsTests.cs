using NUnit.Framework;
using DataStructure_2Lib;
using System;

namespace ArrayListTests
{
    public class Tests
    {
        [Test]
        public void ConstructEmptyListTest()
        {
            ArrayList myList = new ArrayList();
            Assert.AreEqual(0, myList.Length);
        }

        

        

        [TestCase(new int[] { })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { -1 })]
        [TestCase(new int[] { -500, 200, 0 })]
        public void ConstructListOfNumberFilledItemsTest(int[] items)
        {
            ArrayList myList = new ArrayList(items);
            int expected = items.Length;
            int actual = myList.Length;


            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 1, 700, -4 }, 1, 700)]
        public void ArrayListGetterTest(int[] inputList, int index, int value)
        {
            int expected = value;
            ArrayList myList = new ArrayList(inputList);
            int actual = myList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { }, 1)]
        [TestCase(new int[] { }, -1)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1 }, -1)]
        [TestCase(new int[] { 1, -1 }, 2)]
        [TestCase(new int[] { 1, -1 }, -1)]
        public void ArrayListGetterTestNegative(int[] inputList, int index)
        {
            ArrayList myList = new ArrayList(inputList);

            Assert.Throws<IndexOutOfRangeException>(() => myList[index]++);
        }

        [TestCase(new int[] { }, 0, new int[] { 0 })]
        [TestCase(new int[] { 1 }, 0, new int[] { 1, 0 })]
        [TestCase(new int[] { 1, 0 }, 1, new int[] { 1, 0, 1 })]
        public void PutLastTest(int[] inputList, int value, int[] expectedList)
        {
            ArrayList actual = new ArrayList(inputList);
            ArrayList expected = new ArrayList(expectedList);
            actual.PutLast(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 0, new int[] { 0 })]
        [TestCase(new int[] { 1 }, 0, new int[] { 0, 1 })]
        [TestCase(new int[] { 0, 1 }, 1, new int[] { 1, 0, 1 })]
        public void PutFirstTest(int[] inputList, int value, int[] expectedList)
        {
            ArrayList actual = new ArrayList(inputList);
            ArrayList expected = new ArrayList(expectedList);

            actual.PutFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 700, -4 }, 1, 800, new int[] { 1, 800, -4 })]
        public void ArrayListSetterTest(int[] inputList, int index, int value, int[] expectedList)
        {
            ArrayList actual = new ArrayList(inputList);
            ArrayList expected = new ArrayList(expectedList);

            actual[index] = value;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { }, 1)]
        [TestCase(new int[] { }, -1)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1 }, -1)]
        [TestCase(new int[] { 1, -1 }, 2)]
        [TestCase(new int[] { 1, -1 }, -1)]
        public void ArrayListSetterTestNegative(int[] inputList, int index) // исправить - проверить уточнение ошибки, не только сам факт ошибки
        {
            ArrayList myList = new ArrayList(inputList);

            Assert.Throws<IndexOutOfRangeException>(() => myList[index]++);
        }

        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 1, 0 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 0, 500, -5, -700 }, new int[] { 1, 0, 500, -5 })]
        public void DeleteLastTest(int[] inputList, int[] expectedList)
        {
            ArrayList actual = new ArrayList(inputList);
            ArrayList expected = new ArrayList(expectedList);

            actual.PutLast(5);
            actual.DeleteLast();
            actual.DeleteLast();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void DeleteLastTestNegative(int[] inputList)
        {
            ArrayList myList = new ArrayList(inputList);

            Assert.Throws<IndexOutOfRangeException>(() => myList.DeleteLast());
        }
    }
}