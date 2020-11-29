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

            //actual.PutLast(5);
            //actual.DeleteLast();
            actual.DeleteLast();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void DeleteLastTestNegative(int[] inputList)
        {
            ArrayList myList = new ArrayList(inputList);

            Assert.Throws<NullReferenceException>(() => myList.DeleteLast());
        }

        [TestCase(new int[] { 1, 2, 4, 5 }, new int[] { 2, 4, 5 })]
        [TestCase(new int[] { 5 }, new int[] { })]
        public void DeleteFirstTest(int[] arrayForActual, int[] arrayForExpected)
        {
            ArrayList actual = new ArrayList(arrayForActual);
            ArrayList expected = new ArrayList(arrayForExpected);

            actual.DeleteFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 4, 5 }, 0, new int[] { 2, 4, 5 })]
        [TestCase(new int[] { 1, 2, 4, 5 }, 1, new int[] { 1, 4, 5 })]
        [TestCase(new int[] { 1, 2, 4, 5 }, 3, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 5 }, 0, new int[] { })]
        [TestCase(new int[] { 5, 2 }, 0, new int[] { 2 })]
        [TestCase(new int[] { 5, 2 }, 1, new int[] { 5 })]
        public void DeleteByIndexTest(int[] arrayForActual, int index, int[] arrayForExpected)
        {
            ArrayList actual = new ArrayList(arrayForActual);
            ArrayList expected = new ArrayList(arrayForExpected);

            actual.DeleteByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 4, 5 }, 4)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 5 }, 1)]
        [TestCase(new int[] { 5, 2 }, 2)]
        public void LengthGetterTest(int[] array, int expected)
        {
            ArrayList actual = new ArrayList(array);

            Assert.AreEqual(expected, actual.Length);
        }

        [TestCase(new int[] {1, 2, 5, 8}, new int[] {8, 5, 2, 1})]
        [TestCase(new int[] { 1, 2, 5, 8, 0 }, new int[] { 0, 8, 5, 2, 1 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [TestCase(new int[] { 1}, new int[] { 1 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        public void ReverseTest(int[] arrayForActual, int[] arrayForExpected)
        {
            ArrayList actual = new ArrayList(arrayForActual);
            ArrayList expected = new ArrayList(arrayForExpected);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 5, 8 }, 8)]
        [TestCase(new int[] { 1, 2, 5, -1, 0 }, 5)]
        [TestCase(new int[] { 1, 2 }, 2)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 0 }, 0)]
        public void GetMaxElementValueTest(int[] arrayForActual, int expected)
        {
            ArrayList actual = new ArrayList(arrayForActual);
            
            Assert.AreEqual(expected, actual.GetMaxElementValue());
        }

        [TestCase(new int[] { 1, 2, 5, 8 }, 1)]
        [TestCase(new int[] { 1, 2, 5, -1, 0 }, -1)]
        [TestCase(new int[] { 1, 2 }, 1)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 0 }, 0)]
        public void GetMinElementValueTest(int[] arrayForActual, int expected)
        {
            ArrayList actual = new ArrayList(arrayForActual);

            Assert.AreEqual(expected, actual.GetMinElementValue());
        }

        [TestCase(new int[] { 1, 2, 5, 8 }, 3)]
        [TestCase(new int[] { 1, 2, 5, -1, 0 }, 2)]
        [TestCase(new int[] { 1, 2 }, 1)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        public void GetIndexOfMaxElement(int[] arrayForActual, int expected)
        {
            ArrayList actual = new ArrayList(arrayForActual);

            Assert.AreEqual(expected, actual.GetIndexOfMaxElement());
        }

        [TestCase(new int[] { 1, 2, 5, 8 }, 0)]
        [TestCase(new int[] { 1, 2, 5, -1, 0 }, 3)]
        [TestCase(new int[] { 1, 2 }, 0)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        public void GetIndexOfMinElement(int[] arrayForActual, int expected)
        {
            ArrayList actual = new ArrayList(arrayForActual);

            Assert.AreEqual(expected, actual.GetIndexOfMinElement());
        }

        [TestCase(new int[] { 2, 4, 7, 8}, new int[] { 2, 4, 7, 8})]
        [TestCase(new int[] { 2, 4, 8, 7 }, new int[] { 2, 4, 7, 8 })]
        [TestCase(new int[] { 4, 2 }, new int[] { 2, 4})]
        [TestCase(new int[] { 4, 4 }, new int[] { 4, 4 })]
        [TestCase(new int[] { 40 }, new int[] { 40 })]
        public void SortAscendTest(int[] arrayForActual, int[] arrayForExpected)
        {
            ArrayList actual = new ArrayList(arrayForActual);
            ArrayList expected = new ArrayList(arrayForExpected);

            actual.SortAscend();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 4, 7, 8 }, new int[] { 8, 7, 4, 2 })]
        [TestCase(new int[] { 2, 4, 8, 7 }, new int[] { 8, 7, 4, 2 })]
        [TestCase(new int[] { 4, 2 }, new int[] { 4, 2 })]
        [TestCase(new int[] { 2, 4 }, new int[] { 4, 2 })]
        [TestCase(new int[] { 40 }, new int[] { 40 })]
        public void SortDescendTest(int[] arrayForActual, int[] arrayForExpected)
        {
            ArrayList actual = new ArrayList(arrayForActual);
            ArrayList expected = new ArrayList(arrayForExpected);

            actual.SortDescend();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 8, 16 }, 2, new int[] { 8, 16 })]
        [TestCase(new int[] { 2, 8, 16 }, 8, new int[] { 2, 16 })]
        [TestCase(new int[] { 2, 8, 16 }, 16, new int[] { 2, 8 })]
        [TestCase(new int[] { 2, 8 }, 8, new int[] { 2 })]
        [TestCase(new int[] { 2, 8 }, 2, new int[] { 8 })]
        [TestCase(new int[] { 2}, 2, new int[] { })]
        public void DeleteByValueTest(int[] arrayForActual, int value, int[] arrayForExpected)
        {
            ArrayList actual = new ArrayList(arrayForActual);
            ArrayList expected = new ArrayList(arrayForExpected);

            actual.DeleteByValue(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 2, 8, 16, 2 }, 2, new int[] { 8, 16 })]
        [TestCase(new int[] { 2, 8, 8, 16 }, 8, new int[] { 2, 16 })]
        [TestCase(new int[] { 16, 2, 16, 8, 16 }, 16, new int[] { 2, 8 })]
        [TestCase(new int[] { 2, 2, 3, 3, 8 }, 3, new int[] { 2, 2, 8 })]
        [TestCase(new int[] { 2, 8 }, 2, new int[] { 8 })]
        [TestCase(new int[] { 2 }, 2, new int[] { })]
        [TestCase(new int[] { 2, 2, 2, 2, 2 , 2, 8, 16, 2 }, 2, new int[] { 8, 16 })]
        [TestCase(new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 8, 16, 2 }, 2, new int[] { 8, 16 })]
        public void DeleteEveryByValueTest(int[] arrayForActual, int value, int[] arrayForExpected)
        {
            ArrayList actual = new ArrayList(arrayForActual);
            ArrayList expected = new ArrayList(arrayForExpected);

            actual.DeleteEveryByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 8, 16, 2 }, new int[] { 2 }, new int[] { 2, 8, 16, 2, 2 })]
        [TestCase(new int[] { }, new int[] { 1}, new int[] { 1})]
        [TestCase(new int[] { 2, 8, 16, 2 }, new int[] { 2, 4, 19 }, new int[] { 2, 8, 16, 2, 2, 4, 19 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 15 }, new int[] { 1, 2, 15 })]
        public void PutArrayToEndTest(int[] arrayForActual, int[] argumentArray, int[] arrayForExpected)
        {
            ArrayList actual = new ArrayList(arrayForActual);
            ArrayList expected = new ArrayList(arrayForExpected);

            actual.PutArrayToEnd(argumentArray);

            Assert.AreEqual(expected, actual);
        }
    }
}