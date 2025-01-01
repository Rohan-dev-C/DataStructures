using System;
using System.Collections.Generic;

namespace MergeSort
{
    class Program
    {
        List<T> MergeSort<T>(List<T> list)
            where T : IComparable<T> 
        {
            List<T> list1 = new List<T>();
            List<T> list2 = new List<T>();

            for (int i = 0; i < list.Count / 2; i++)
            {
                list1.Add(list[i]);
            }
            for (int i = list.Count / 2; i < list.Count; i++)
            {
                list2.Add(list[i]);
            }

            if(list1.Count >= 2)
            {
                MergeSort(list1); 
            }
            if (list2.Count >= 2)
            {
                MergeSort(list2);
            }


            return Sort(list1, list2);
        }
        List<T> Sort<T>(List<T> list1, List<T> list2)
            where T : IComparable<T>
        {
            List<T> list = new List<T>();

            int j = 0;
            for (int i = 0; i < list1.Count;)
            {
                if(list1[i].CompareTo(list2[j]) > 0 )
                {
                    list.Add(list2[j]);
                    j++; 
                }
                else
                {
                    list.Add(list1[i]);
                    i++; 
                }
            }



            return list; 
        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Random rand = new Random();

            int randomNum = rand.Next(100, 101);

            for (int i = 0; i < randomNum; i++)
            {
                list.Add(rand.Next(0, 10));
                Console.Write(list[i].ToString());
            }
            Console.WriteLine();

            
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(MergeSort(list)[i]);
            }
        }
    }
}
