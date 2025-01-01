using System;
using System.Collections.Generic;

namespace InsertionSort
{
    class Program
    {
        static void InsertionSort(ref List<int> list)
        {
            int currentIndex = 0;
            int checkCount = 0;
            while (currentIndex < list.Count)
            {
                for (int i = currentIndex; i > 0; i--)
                {
                    checkCount++;
                    if (list[i] < list[i - 1])
                    {
                        int temp = list[i];
                        list[i] = list[i - 1];
                        list[i - 1] = temp;
                    }
                    else
                    {
                        break;
                    }

                }
                currentIndex++;
            }
            Console.WriteLine(checkCount); 
        }


        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Random rand = new Random(4723);

            int randomNum = rand.Next(50, 100);

            for (int i = 0; i < randomNum; i++)
            {
                list.Add(rand.Next(0, 10));
                Console.Write(list[i].ToString());
            }
            Console.WriteLine();

            InsertionSort(ref list);


            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i].ToString());
            }
        }
    }
}
