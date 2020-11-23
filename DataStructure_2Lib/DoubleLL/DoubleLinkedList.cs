using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure_2Lib.DoubleLL
{
    public class DoubleLinkedList: IMyLists
    {
        int Length;
        
        DoubleNode _root;
        DoubleNode _tail;

        public DoubleLinkedList(int value)
        {
            _root = new DoubleNode(value);
            _tail = _root;
            Length = 1;
        }

        public DoubleLinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new DoubleNode(array[0]);
                DoubleNode current = _root;
                //DoubleNode pre = null;

                for (int i = 1; i < array.Length; i++)
                {
                    
                    current.Next = new DoubleNode(array[i]);
                    current.Next.Pre = current;
                    current = current.Next;
                }

                _tail = current;

                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
                _tail = null;
            }



        }

        public int this[int index]
        {
            get
            {
                if ((index >= Length) || (index < 0))
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {

                    int worstCase = (Length / 2 + 1);

                    if (index < worstCase)
                    {
                        DoubleNode tmp = _root;
                        for (int i = 1; i <= index; i++)
                        {
                            tmp = tmp.Next;
                            
                        }
                        return tmp.Value;
                    }
                    else
                    {
                        DoubleNode tmp = _tail;
                        for (int i = Length; i > index+1; i--)
                        {
                            tmp = tmp.Pre;
                            
                        }
                        return tmp.Value;
                    }
                }
                
            }

            set 
            {
                if ((index >= Length) || (index < 0))
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    int worstCase = (Length / 2 + 1);

                    if (index < worstCase)
                    {

                        DoubleNode tmp = _root;
                        for (int i = 1; i <= index; i++)
                        {
                            tmp = tmp.Next;
                        }
                        tmp.Value = value;
                    }
                    else
                    {
                        DoubleNode tmp = _tail;
                        for (int i = Length; i > index+1; i--)
                        {
                            tmp = tmp.Pre;
                        }
                        tmp.Value = value;
                    }
                }
            }
        }

        public void PutLast(int value)
        {
            if (Length != 0)
            {
                DoubleNode tmp = _tail;
                tmp.Next = new DoubleNode(value);
                tmp.Next.Pre = tmp;
                tmp = tmp.Next;
                _tail = tmp;
                Length++;
            }
            else
            {
                _root = new DoubleNode(value);
                _tail = _root;
                Length = 1;
            }
        }
        
        public void PutFirst(int value)
        {

        }
        public void DeleteLast()
        {

        }
        public void DeleteFirst()
        {

        }
        public void DeleteByIndex(int index)
        {

        }
        public void Reverse()
        {

        }
        public int GetMaxElementValue()
        {
            return 1;
        }
        public int GetMinElementValue()
        {
            return 1;
        }
        public int GetIndexOfMaxElement()
        {
            return 1;
        }
        public int GetIndexOfMinElement()
        {
            return 1;
        }
        public void SortAscend()
        {
            
        }
        public void SortDescend()
        {
            
        }
        public void DeleteByValue(int value)
        {
            
        }
        public void DeleteEveryByValue(int value)
        {
            
        }
        public void PutArrayToEnd(int[] argumentArray)
        {
            
        }
        public void PutArrayToStart(int[] argumentArray)
        {
            
        }
        public void PutArrayToIndex(int index, int[] argumentArray)
        {
           
        }
        public void DeleteFromEnd(int number)
        {
            
        }
        public void DeleteFromStart(int number)
        {
            
        }
        public void DeleteFromIndex(int index, int number)
        {
            
        }
        public override bool Equals(object obj)
        {
            DoubleLinkedList doubleLinkedList = (DoubleLinkedList)obj;

            if (Length != doubleLinkedList.Length)
            {
                return false;
            }

            //for (int i = 0; i < Length; i++)
            //{
            //    if(this[i]!=linkedList[i])
            //    {
            //        return false;
            //    }
            //}

            DoubleNode tmp1 = _root;
            DoubleNode tmp2 = doubleLinkedList._root;//в дабл добавить _tail и шагать previous-ами
            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            
            tmp1 = _tail;
            tmp2 = doubleLinkedList._tail;

            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Pre;
                tmp2 = tmp2.Pre;
            }

            return true;
        }

        public override string ToString()
        {
            string s = "";

            if (_root != null)
            {
                DoubleNode tmp = _root;

                while (tmp != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;
                }
            }
            return s;
        }
    }
}
