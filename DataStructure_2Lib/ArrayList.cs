using System;

namespace DataStructure_2Lib
{
    public class ArrayList
    {
        public int Length { get; private set; } //полезная длина (для пользователя)

        private int[] _array; //массив внутри списка
        private int _ArrayLength //полная длина
        {
            get
            {
                return _array.Length;
            }
        }

        public ArrayList()//конструктор пустого списка
        {
            _array = new int[0];
            Length = 0;
        }

        public ArrayList(int[] list)//конструктор заполняющий список N элементами
        {
            if (list.Length > 0)
            {
                _array = list;//переделать через Array.Copy
                Length = list.Length;
            }
            else
            {
                _array = new int[0];
                Length = 0;
            }
        }

        public int this[int i] //получение и запись по индексу
        {
            get
            {
                if (i < 0)
                {
                    throw new IndexOutOfRangeException("Index can not be below zero");
                }
                else if (i >= Length)
                {
                    throw new IndexOutOfRangeException($"Index can not be {i} because your list contains {Length} items. ");
                }
                return _array[i];
            }
            set
            {
                if (i < 0)
                {
                    throw new IndexOutOfRangeException("Index can not be below zero");
                }
                else if (i >= Length)
                {
                    throw new IndexOutOfRangeException($"Index can not be {i} because your list contains {Length} items. ");
                }
                _array[i] = value;
            }
        }

        private void IncreaseLenght(int number = 1)
        {
            int newLength = Length;
            while (newLength <= Length + number)
            {
                newLength = (int)(newLength * 4 / 3 + 1);//разобраться с приведениями
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _ArrayLength);

            _array = newArray;
        }

        private void DecreaseLength(int number = 1)
        {
            int newLength = Length;
            while (newLength >= Length - number)
            {
                newLength = (int)((newLength * 2 + 1) / 3);//разобраться с приведениями
            }

            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, newLength);

            _array = newArray;
        }

        public void PutLast(int value)
        {
            if (_ArrayLength <= Length)
            {
                IncreaseLenght();
            }
            _array[Length] = value;
            Length++;
        }

        public void PutFirst(int value)
        {
            if (_ArrayLength <= Length)
            {
                IncreaseLenght(1);
            }
            for (int i = Length + 1; i > 0; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[0] = value;
            Length++;
        }

        public void DeleteLast()
        {

            if (Length <= _ArrayLength / 2)
            {
                DecreaseLength();
            }
            Length--;
        }

        public override bool Equals(object obj)//для тестов, переделка системного метода
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
