using System;

namespace DataStructure_2Lib
{
    public class ArrayList: IMyLists
    {
        public int Length { get; protected set; } //полезная длина (для пользователя)

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

        private void IncreaseLength(int number = 1)
        {
            int newLength = Length;
            while (newLength <= Length + number)
            {
                newLength = (int)(newLength * 1.33 + 1);//разобраться с приведениями
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _ArrayLength);

            _array = newArray;
        }

        private void DecreaseLength(int number = 1)
        {
            int newLength = Length;
            while (newLength >= 2 * Length + number)
            {
                newLength = (int)(newLength * 0.66 + 1);//разобраться с приведениями
            }

            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, newLength);

            _array = newArray;
        }

        public void PutLast(int value)
        {
            if (_ArrayLength <= Length)
            {
                IncreaseLength();
            }
            _array[Length] = value;
            Length++;
        }

        public void PutFirst(int value)
        {
            if (_ArrayLength <= Length)
            {
                IncreaseLength();
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
            if (Length != 0)
            {
                DecreaseLength();
                Length--;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void DeleteFirst()
        {
            if (Length != 0)
            {
                DecreaseLength();
                Length--;
                for (int i =0; i < Length; i++)
                {
                    _array[i] = _array[i + 1];
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void DeleteByIndex(int index)
        {
            if (Length != 0)
            {
                DecreaseLength();
                Length--;
                for (int i = index; i < Length; i++)
                {
                    _array[i] = _array[i + 1];
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Reverse()
        {
            int tmp;
            for (int i=0; i<Length / 2; i++)
            {
                tmp = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = tmp;
            }
        }

        public int GetMaxElementValue()
        {
            int max = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (max < _array[i])
                {
                    max = _array[i];
                }
            }
            return max;
        }

        public int GetMinElementValue()
        {
            int min = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (min > _array[i])
                {
                    min = _array[i];
                }
            }
            return min;
        }

        public int GetIndexOfMaxElement()
        {
            int max = _array[0];
            int index = 0;

            for (int i = 1; i < Length; i++)
            {
                if (max < _array[i])
                {
                    max = _array[i];
                    index = i;
                }
            }
            return index;
        }

        public int GetIndexOfMinElement()
        {
            int min = _array[0];
            int index = 0;

            for (int i = 1; i < Length; i++)
            {
                if (min > _array[i])
                {
                    min = _array[i];
                    index = i;
                }
            }
            return index;
        }

        public void SortAscend()
        {
            int buffer = 0;

            for (int i = 1; i < Length; i++)
            {
                for (int j = 0; j < Length - i; j++)
                {
                    if (_array[j] > _array[j + 1])
                    {
                        buffer = _array[j + 1];
                        _array[j + 1] = _array[j];
                        _array[j] = buffer;
                    }
                }
            }
        }

        public void SortDescend()
        {
            int buffer = 0;

            for (int i = 0; i < Length - 1; i++)
            {

                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[i] < _array[j])
                    {
                        buffer = _array[i];
                        _array[i] = _array[j];
                        _array[j] = buffer;
                    }
                }
            }
        }

        public void DeleteByValue(int value)
        {
            int index=0;
            int i;

            if (Length != 0)
            {
                
                while (_array[index] != value)
                {
                    index++;
                    
                }
                for (i=index; i<Length-1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                DecreaseLength();
                Length--;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void DeleteEveryByValue(int value)
        {
            if (Length != 0)
            {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i]==value)
                {
                    for (int j=i; j<Length-1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    DecreaseLength();
                    Length--;
                    i--;
                }
            }
            }
            else
            {
                throw new NullReferenceException();
            }
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

        public override string ToString()
        {
            string s = "";

            if (Length != 0)
            {
                for (int i=0; i<Length; i++)
                {
                    s += _array[i] + ";";
                    
                }
            }
            return s;
        }

    }
}
