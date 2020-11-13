using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure_2Lib.LL
{
    public class LinkedList
    {
        public int Length { get; set; }

        private Node _root;

        //private Node _last;

        public int this[int index]
        {
            get
            {
                if ((index>=Length)||(index<0))
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }

            set //должен ли быть private?
            {
                if ((index >= Length) || (index < 0))
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
            Length = 1;
        }

        public LinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }

                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        public void AddByIndex(int index, int value)
        {
            if ((index>Length)||(index<0))
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
            }
            else
            {
                Node current = _root;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                Node tmp = current.Next;
                current.Next = new Node(value);

                current.Next.Next = tmp;
            }
            Length++;
        }

        public void DeleteLast()
        {
            if (Length == 0)
            {
                return;
            }

            Node current = _root;
            for (int i = 1; i < Length - 1; i++)
            {
                current = current.Next;
            }

            // current.Next?.Dispose();// если Next == null

            current.Next = null;
            Length--;
            
        }

        public void DeleteFirst()
        {
            if (Length == 0)
            {
                return;
            }

            //Node current = _root.Next;//запись в current ссылки на на второй элемент
            //_root = current;//замена ссылки на первый элемент ссылкой на второй элемент

            //current.Next?.Dispose();// если Next == null

            _root = _root.Next;

            Length--;
        }

        public void DeleteByIndex(int index)
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if ((index > Length-1) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                Node tmp = new Node();
                tmp = _root.Next;
                _root = tmp;
            }
            else
            {
                Node current = _root;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                // current.Next?.Dispose();// если Next == null


                current.Next = current.Next.Next;
            }
            Length--;
        }

        public int GetLength()
        {
            return Length;
        }

        public int GetIndexByValue(int value)
        {
            int index = 0;
            Node current = new Node();
            current = _root;

            while(current.Value != value)
            {
                index++;
                current = current.Next;
                if (current.Next == null) throw new NullReferenceException();
            }

            return index;
        }

        public void Reverse()
        {
            Node current = new Node();
            Node runner = new Node();
            Node pre = new Node();
            pre.Next = _root;//в строке нет необходимости, но с ней работает 
            //строка 203 - для наглядности того, что список ограничен null-ами
            current = _root;
            while(current!=null)
            {
                runner = current.Next;
                current.Next = pre;
                pre = current;
                _root = current;
                current = runner;
            }
        }
        
        public int GetMaxElement()
        {
            Node current = new Node();
            current = _root;
            int max = current.Value;

            if (Length==0)
            {
                throw new NullReferenceException();
            }

            do
            {
                if ((current.Next!=null)&&(max < current.Next.Value))
                {
                    max = current.Next.Value;
                }
                if (current.Next != null)
                {
                    current = current.Next;
                }
            }
            while (current.Next != null);
            
            return max;
        }

        public int GetMinElement()
        {
            Node current = new Node();
            current = _root;
            int min = current.Value;

            if (Length == 0)
            {
                throw new NullReferenceException();
            }

            do
            {
                if ((current.Next != null) && (min > current.Next.Value))
                {
                    min = current.Next.Value;
                }
                if (current.Next != null)
                {
                    current = current.Next;
                }
            }
            while (current.Next != null);

            return min;
        }

        public int GetIndexOfMaxElement()
        {
            Node current = new Node();
            current = _root;
            int max = current.Value;
            int index = 0;
            int indexMax = index;

            if (Length == 0)
            {
                throw new NullReferenceException();
            }

            do
            {
                
                if ((current.Next != null) && (max < current.Next.Value))
                {
                    max = current.Next.Value;
                    indexMax = index+1;
                    
                }
                if (current.Next != null)
                {
                    current = current.Next;
                    index++;
                }
            }
            while (current.Next != null);

            return indexMax;
        }

        public int GetIndexOfMinElement()
        {
            Node current = new Node();
            current = _root;
            int min = current.Value;
            int index = 0;
            int indexMin = index;

            if (Length == 0)
            {
                throw new NullReferenceException();
            }

            do
            {
                if ((current.Next != null) && (min > current.Next.Value))
                {
                    min = current.Next.Value;
                    indexMin = index + 1;

                }
                if (current.Next != null)
                {
                    current = current.Next;
                    index++;
                }
            }
            while (current.Next != null);

            return indexMin;
        }

        public void SortAscend()
        {
            
        }

        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
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

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;
            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";

            if (_root != null)
            {
                Node tmp = _root;

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
