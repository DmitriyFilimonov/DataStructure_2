using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure_2Lib
{
    public interface IMyLists
    {
        public int Length { get; }
        public void PutLast(int value);//добавить значение в конец
        public int this[int i] { get; set; }//индексатор
        public void PutFirst(int value);
        public void DeleteLast();
        public void DeleteFirst();
        public void DeleteByIndex(int index);
        public void Reverse();
        public int GetMaxElementValue();
        public int GetMinElementValue();
        public int GetIndexOfMaxElement();
        public int GetIndexOfMinElement();
        public void SortAscend();
        public void SortDescend();
        public void DeleteByValue(int value);
        public void DeleteEveryByValue(int value);
        public void PutArrayToEnd(int[] argumentArray);
        public void PutArrayToStart(int[] argumentArray);
        public void PutArrayToIndex(int index, int[] argumentArray);
        public void DeleteFromEnd(int number);
        public void DeleteFromStart(int number);
        public void DeleteFromIndex(int index, int number);

        public bool Equals(object obj);
        public string ToString();
    }
}
