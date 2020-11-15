using NUnit.Framework;
using System;
using DataStructure_2Lib.LL;
//using DataStructure.LL;

namespace LLTests
{
    public class Tests
    {
        public class LinkedListTests
        {
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3, new int[] { 1, 2, 4, 3, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 3, new int[] { 1, 4, 3, 2, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 4, new int[] { 1, 2, 5, 4, 3 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 3, new int[] { 4, 2, 3, 1, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 4, new int[] { 5, 2, 3, 4, 1 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1, new int[] { 2, 1, 3, 4, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 4, new int[] { 1, 2, 3, 5, 4 })]

            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 2, new int[] { 1, 2, 4, 3, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 1, new int[] { 1, 4, 3, 2, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 2, new int[] { 1, 2, 5, 4, 3 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 0, new int[] { 4, 2, 3, 1, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 0, new int[] { 5, 2, 3, 4, 1 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 0, new int[] { 2, 1, 3, 4, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 3, new int[] { 1, 2, 3, 5, 4 })]

            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 3, new int[] { 1, 2, 3, 4, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 0, new int[] { 1, 2, 3, 4, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 4, new int[] { 1, 2, 3, 4, 5 })]

            [TestCase(new int[] { 1, 2 }, 0, 1, new int[] { 2, 1 })]
            [TestCase(new int[] { 1 }, 0, 0, new int[] { 1 })]
            public void SwapTest(int[] a, int i1, int i2, int[] b)
            {
                LinkedList expected = new LinkedList(b);
                LinkedList actual = new LinkedList(a);

                actual.Swap(i1, i2);

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 2, 3 }, 1, 4, new int[] { 1, 4, 2, 3 })]
            [TestCase(new int[] { 1, 2, 3 }, 0, 4, new int[] { 4, 1, 2, 3 })]
            [TestCase(new int[] { 1, 2, 3 }, 3, 4, new int[] { 1, 2, 3, 4 })]
            [TestCase(new int[] { }, 0, 4, new int[] { 4 })]
            [TestCase(new int[] { 1 }, 0, 4, new int[] { 4, 1 })]
            public void AddByIndexTest(int[] array, int index, int value, int[] expArray)
            {
                LinkedList expected = new LinkedList(expArray);
                LinkedList actual = new LinkedList(array);

                actual.AddByIndex(index, value);

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 2, 3 }, 5, 4)]
            public void AddByIndexTestNegative(int[] array, int index, int value)
            {
                LinkedList a = new LinkedList(array);


                Assert.Throws<IndexOutOfRangeException>(() => a.AddByIndex(index, value));
            }

            [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
            [TestCase(new int[] { 1, 2 }, new int[] { 1 })]
            [TestCase(new int[] { 1 }, new int[] { })]
            [TestCase(new int[] { }, new int[] { })]
            public void DeleteLastTest(int[] a, int[] b)
            {
                LinkedList expected = new LinkedList(b);
                LinkedList actual = new LinkedList(a);
                actual.DeleteLast();

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
            public void DeleteFirstTest(int[] a, int[] b)
            {
                LinkedList expected = new LinkedList(b);
                LinkedList actual = new LinkedList(a);
                actual.DeleteFirst();

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3, 4 })]
            [TestCase(new int[] { 1, 2, 3, 4 }, 1, new int[] { 1, 3, 4 })]
            [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 3 })]
            [TestCase(new int[] { 1 }, 0, new int[] { })]
            public void DeleteByIndexTest(int[] actualList, int index, int[] expectedList)
            {
                LinkedList expected = new LinkedList(expectedList);
                LinkedList actual = new LinkedList(actualList);
                actual.DeleteByIndex(index);

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { }, 0)]
            [TestCase(new int[] { }, -1)]
            [TestCase(new int[] { 3 }, -1)]
            [TestCase(new int[] { 1, 2 }, 2)]
            [TestCase(new int[] { 1, 2 }, -1)]
            public void DeleteByIndexTestNegative(int[] actualList, int index)
            {
                LinkedList a = new LinkedList(actualList);


                Assert.Throws<IndexOutOfRangeException>(() => a.DeleteByIndex(index));
            }

            [TestCase(new int[] { 1, 2, 3, 4 }, 4)] //нужен ли негативный тест?
            [TestCase(new int[] { }, 0)]
            public void GetLengthTest(int[] array, int expected)
            {
                LinkedList a = new LinkedList(array);
                int actual = a.GetLength();

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 2, 3, 4 }, 2, 3)]
            public void GetByIndexTest(int[] array, int index, int expected)
            {
                LinkedList a = new LinkedList(array);
                int actual = a[index];

                a[index] = 321;

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
            [TestCase(new int[] { 1, 2, 3, 4 }, -1)]
            public void GetByIndexTestNegative(int[] array, int index)
            {
                LinkedList a = new LinkedList(array);


                Assert.Throws<IndexOutOfRangeException>(() => a[index]++);
            }

            [TestCase(new int[] { 0, 1, 1, 1, 1 }, 1, 1)]
            [TestCase(new int[] { 1 }, 1, 0)]
            public void GetIndexByValueTest(int[] array, int value, int expected)
            {
                LinkedList a = new LinkedList(array);
                int actual = a.GetIndexByValue(value);

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { }, 1)]
            [TestCase(new int[] { 2 }, 1)]
            public void GetIndexByValueTestNegative(int[] array, int value)
            {
                LinkedList a = new LinkedList(array);
                int actual;

                Assert.Throws<NullReferenceException>(() => actual = a.GetIndexByValue(value));
            }

            [TestCase(new int[] { 1, 2, 3, 4 }, 3, 5, new int[] { 1, 2, 3, 5 })]
            public void SetByIndexTest(int[] actualArray, int index, int value, int[] expectedArray)
            {
                LinkedList actual = new LinkedList(actualArray);
                LinkedList expected = new LinkedList(expectedArray);

                actual[index] = value;

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 2, 3, 4 }, 4, 5)]
            [TestCase(new int[] { 1, 2, 3, 4 }, -4, 5)]
            [TestCase(new int[] { }, 4, 5)]
            [TestCase(new int[] { }, -4, 5)]
            public void SetByIndexTestNegative(int[] actualArray, int index, int value)
            {
                LinkedList actual = new LinkedList(actualArray);

                Assert.Throws<IndexOutOfRangeException>(() => actual[index] = value);
            }

            [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
            public void ReverseTest(int[] arrayForActual, int[] arrayForExpected)
            {
                LinkedList actual = new LinkedList(arrayForActual);
                LinkedList expected = new LinkedList(arrayForExpected);

                actual.Reverse();

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 4, 8, 5 }, 8)]
            [TestCase(new int[] { 1, -4, 8, 5 }, 8)]
            [TestCase(new int[] { -1, -4, -8, -5 }, -1)]
            [TestCase(new int[] { -4, -4, -8, -5 }, -4)]
            [TestCase(new int[] { -4 }, -4)]
            [TestCase(new int[] { 0 }, 0)]
            [TestCase(new int[] { 0, 0 }, 0)]
            public void GetMaxElementTest(int[] arrayForActual, int expected)
            {
                LinkedList actual = new LinkedList(arrayForActual);

                Assert.AreEqual(expected, actual.GetMaxElement());
            }

            [TestCase(new int[] { })]
            public void GetMaxElementTestNegative(int[] arrayForActual)
            {
                LinkedList actual = new LinkedList(arrayForActual);

                Assert.Throws<NullReferenceException>(() => actual.GetMaxElement());
            }

            [TestCase(new int[] { 1, 4, 8, 5 }, 1)]
            [TestCase(new int[] { 1, -4, 8, 5 }, -4)]
            [TestCase(new int[] { -1, -4, -8, -5 }, -8)]
            [TestCase(new int[] { -4 }, -4)]
            [TestCase(new int[] { 0 }, 0)]
            [TestCase(new int[] { 1, 0, -1, 1 }, -1)]
            public void GetMinElementTest(int[] arrayForActual, int expected)
            {
                LinkedList actual = new LinkedList(arrayForActual);


                Assert.AreEqual(expected, actual.GetMinElement());
            }

            [TestCase(new int[] { })]
            public void GetMinElementTestNegative(int[] arrayForActual)
            {
                LinkedList actual = new LinkedList(arrayForActual);

                Assert.Throws<NullReferenceException>(() => actual.GetMinElement());
            }

            [TestCase(new int[] { -4 }, 0)]
            [TestCase(new int[] { 0 }, 0)]
            [TestCase(new int[] { 1, 0, 2, -1 }, 2)]
            [TestCase(new int[] { 0, 0, -1, 1 }, 3)]
            [TestCase(new int[] { 0, 0, -1, 3 }, 3)]
            public void GetIndexOfMaxElementTest(int[] arrayForActual, int expected)
            {
                LinkedList actual = new LinkedList(arrayForActual);


                Assert.AreEqual(expected, actual.GetIndexOfMaxElement());
            }

            [TestCase(new int[] { -4 }, 0)]
            [TestCase(new int[] { 0 }, 0)]
            [TestCase(new int[] { 1, 0, -1, 3 }, 2)]
            [TestCase(new int[] { 0, -20, -1, 3 }, 1)]
            public void GetIndexOfMinElementTest(int[] arrayForActual, int expected)
            {
                LinkedList actual = new LinkedList(arrayForActual);


                Assert.AreEqual(expected, actual.GetIndexOfMinElement());
            }

            [TestCase(new int[] { 3, 2, 4 }, new int[] { 2, 3, 4 })]
            [TestCase(new int[] { 4, 1, 3, 5 }, new int[] { 1, 3, 4, 5 })]
            [TestCase(new int[] { 4, 1, 3, 5 }, new int[] { 1, 3, 4, 5 })]
            [TestCase(new int[] { 4, 1, 2, 5, 4 }, new int[] { 1, 2, 4, 4, 5 })]
            [TestCase(new int[] { }, new int[] { })]
            [TestCase(new int[] { 1 }, new int[] { 1 })]
            [TestCase(new int[] { 2, 1 }, new int[] { 1, 2 })]
            [TestCase(new int[] { 1, 2, 8, 7, 6, 0 }, new int[] { 0, 1, 2, 6, 7, 8 })]
            public void SortAscendTest(int[] arrayForActual, int[] expectedArray)
            {
                LinkedList actual = new LinkedList(arrayForActual);
                LinkedList expected = new LinkedList(expectedArray);

                actual.SortAscend();

                Assert.AreEqual(expected, actual);
            }
            [TestCase(new int[] { 3, 2, 4 }, new int[] { 4, 3, 2 })]
            [TestCase(new int[] { 4, 1, 3, 5 }, new int[] { 5, 4, 3, 1 })]
            [TestCase(new int[] { 4, 1, 2, 5, 4 }, new int[] { 5, 4, 4, 2, 1 })]
            [TestCase(new int[] { }, new int[] { })]
            [TestCase(new int[] { 1 }, new int[] { 1 })]
            [TestCase(new int[] { 2, 1 }, new int[] { 2, 1 })]
            [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
            [TestCase(new int[] { 1, 2, 8, 7, 6, 0 }, new int[] { 8, 7, 6, 2, 1, 0 })]
            public void SortDescendTest(int[] arrayForActual, int[] expectedArray)
            {
                LinkedList actual = new LinkedList(arrayForActual);
                LinkedList expected = new LinkedList(expectedArray);

                actual.SortDescend();

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 2, 1, 3, 2, 1 }, 2, new int[] { 1, 3, 2, 1 })]
            [TestCase(new int[] { 2, 1, 3, 2, 1 }, 3, new int[] { 2, 1, 2, 1 })]
            [TestCase(new int[] { 2, 1, 3, 2, 4 }, 4, new int[] { 2, 1, 3, 2 })]
            [TestCase(new int[] { 2, 8, 3, 2, 1 }, 1, new int[] { 2, 8, 3, 2 })]
            [TestCase(new int[] { }, 3, new int[] { })]
            public void DeleteFirstByValue(int[] arrayForActual, int value, int[] arrayForExpected)
            {
                LinkedList actual = new LinkedList(arrayForActual);
                LinkedList expected = new LinkedList(arrayForExpected);

                actual.DeleteFirstByValue(value);

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 2, 1, 3, 2, 1 }, 2, new int[] { 1, 3, 1 })]
            [TestCase(new int[] { 2, 1, 3, 2, 1 }, 3, new int[] { 2, 1, 2, 1 })]
            [TestCase(new int[] { 2, 1, 3, 2, 1 }, 1, new int[] { 2, 3, 2 })]
            [TestCase(new int[] { }, 3, new int[] { })]
            public void DeleteAllBuValueTest(int[] arrayForActual, int value, int[] arrayForExpected)
            {
                LinkedList actual = new LinkedList(arrayForActual);
                LinkedList expected = new LinkedList(arrayForExpected);

                actual.DeleteAllByValue(value);

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { }, new int[] { 4 }, new int[] { 4 })]
            [TestCase(new int[] { }, new int[] { 4, 5 }, new int[] { 4, 5 })]
            [TestCase(new int[] { 4}, new int[] { 4}, new int[] { 4, 4})]
            [TestCase(new int[] { 4 }, new int[] { 4, 7 }, new int[] { 4, 4, 7 })]
            [TestCase(new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 1, 2, 3, 4 })]
            public void PutArrayToEnd(int[] arrayForActual, int[] argumentArray, int[] arrayForExpected)
            {
                LinkedList actual = new LinkedList(arrayForActual);
                LinkedList expected = new LinkedList(arrayForExpected);

                actual.PutArrayToEnd(argumentArray);

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { }, new int[] { 4 }, new int[] { 4 })]
            [TestCase(new int[] { }, new int[] { 4, 5 }, new int[] { 4, 5 })]
            [TestCase(new int[] { 4 }, new int[] { 4 }, new int[] { 4, 4 })]
            [TestCase(new int[] { 4 }, new int[] { 4, 7 }, new int[] { 4, 7, 4 })]
            [TestCase(new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 3, 4, 1, 2 })]
            public void PutArrayToStart(int[] arrayForActual, int[] argumentArray, int[] arrayForExpected)
            {
                LinkedList actual = new LinkedList(arrayForActual);
                LinkedList expected = new LinkedList(arrayForExpected);

                actual.PutArrayToStart(argumentArray);

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { }, 0, new int[] { 4 }, new int[] { 4 })]
            [TestCase(new int[] { }, 0, new int[] { 4, 5 }, new int[] { 4, 5 })]
            [TestCase(new int[] { 4 }, 1, new int[] { 4 }, new int[] { 4, 4 })]
            [TestCase(new int[] { 4 }, 0, new int[] { 4 }, new int[] { 4, 4 })]
            [TestCase(new int[] { 4 }, 1, new int[] { 4, 7 }, new int[] { 4, 4, 7 })]
            [TestCase(new int[] { 4 }, 0, new int[] { 4, 7 }, new int[] { 4, 7, 4 })]
            [TestCase(new int[] { 1, 2 }, 2, new int[] { 3, 4 }, new int[] { 1, 2, 3, 4 })]
            [TestCase(new int[] { 1, 2 }, 1, new int[] { 3, 4 }, new int[] { 1, 3, 4, 2 })]
            [TestCase(new int[] { 1, 2 }, 0, new int[] { 3, 4 }, new int[] { 3, 4, 1, 2 })]
            public void PutArrayToIndexTest(int[] arrayForActual,int index, int[] argumentArray, int[] arrayForExpected)
            {
                LinkedList actual = new LinkedList(arrayForActual);
                LinkedList expected = new LinkedList(arrayForExpected);

                actual.PutArrayToIndex(index, argumentArray);

                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 0, 3, 6, 1, 7, 3 }, 2, new int[] { 0, 3, 6, 1 })]
            [TestCase(new int[] { 0, 3, 6, 1, 7, 3 }, 6, new int[] {  })]
            [TestCase(new int[] { 0, 3, 6, 1, 7, 3 }, 5, new int[] { 0 })]
            [TestCase(new int[] { 0, 3, 6, 1, 7, 3 }, 0, new int[] { 0, 3, 6, 1 , 7, 3})]
            [TestCase(new int[] { 0, 3}, 1, new int[] { 0 })]
            [TestCase(new int[] { 0, 3 }, 2, new int[] {})]
            public void DeleteFromEndTest(int[] arrayForActual, int number, int[] arrayForExpected)
            {
                LinkedList actual = new LinkedList(arrayForActual);
                LinkedList expected = new LinkedList(arrayForExpected);

                actual.DeleteFromEnd(number);

                Assert.AreEqual(expected, actual);
            }
        }
    }
}