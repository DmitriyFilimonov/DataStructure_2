using System;
//using System.Collections;
using DataStructure_2Lib;
using DataStructure_2Lib.DoubleLL;
using DataStructure_2Lib.LL;

namespace DataStructure_2
{
    class Program
    {
        static void Main(string[] args)
        {
            IMyLists[] list = new IMyLists[3];
            
            list[0] = new ArrayList(1);
            list[1] = new LinkedList(new int[]{ 1, 7, 3 });
            list[2] = new DoubleLinkedList(new int[] { 1, 2, 18, 4, 5 });

            for (int i = 0; i < list.Length; i++)//вывод: 1 7 18
            {
                Console.Write(list[i][i]+" ");
            }
        }
    }
}
