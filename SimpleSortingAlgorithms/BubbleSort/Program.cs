using System;
using System.Collections.Generic;

namespace BubbleSort
{
 



    class Program
    {


        static void sort(ref List<int> list)
        {
            int listLength = list.Count - 1;
            bool sorted = false;

            while (!sorted)
            {
                sorted = true; 
                for (int i = 0; i < listLength; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        int temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        sorted = false;
                    }
                } 
            }
        }


        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Random rand = new Random();

            int randomNum = rand.Next(0, 10);

            for (int i = 0; i < randomNum; i++)
            {
                list.Add(rand.Next(0, 10));
                Console.Write(list[i].ToString()); 
            }
            Console.WriteLine(); 
            

            sort(ref list);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i].ToString());
            }


        }
    }
}
