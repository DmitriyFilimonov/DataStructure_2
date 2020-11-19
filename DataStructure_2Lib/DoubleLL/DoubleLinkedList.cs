using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure_2Lib.DoubleLL
{
    public class DoubleLinkedList
    {
        int Length;
        
        DoubleNode _root;
        DoubleNode _tail;

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

            set //должен ли быть private?
            {
                if ((index >= Length) || (index < 0))
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    int worstCase = (Length / 2 + 1);

                    if (index <= worstCase)
                    {

                        DoubleNode tmp = _root;
                        for (int i = 1; i <= worstCase; i++)
                        {
                            tmp = tmp.Next;
                        }
                        tmp.Value = value;
                    }
                    else
                    {
                        DoubleNode tmp = _tail;
                        for (int i = Length; i > worstCase; i--)
                        {
                            tmp = tmp.Pre;
                        }
                        tmp.Value = value;
                    }
                }
            }
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
    }
}
