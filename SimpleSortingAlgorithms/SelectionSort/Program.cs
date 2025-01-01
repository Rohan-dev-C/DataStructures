using System;
using System.Collections.Generic;

namespace SelectionSort
{
    class Program
    {



        static void SelectionSort(ref List<int> list)
        {
            int smallestNumber = list[list.Count - 1];
            int index = 0;
            int sortedIndex = 0; 

            while (sortedIndex < list.Count)
            {   
                smallestNumber = list[sortedIndex];
                index = sortedIndex; 
                for (int i = sortedIndex; i < list.Count; i++)
                {
                    if (list[i] < smallestNumber)
                    {
                        smallestNumber = list[i];
                        index = i; 
                    }
                    
                }
                int temp = list[sortedIndex];
                list[sortedIndex] = smallestNumber;
                list[index] = temp;
                sortedIndex++;
                
            }
        }

      
       

        

        static void Main(string[] args)
        {

            List<int> list = new List<int>();
            Random rand = new Random(3);

            int randomNum = rand.Next(5, 10);

            for (int i = 0; i < randomNum; i++)
            {
                list.Add(rand.Next(0, 10));
                Console.Write(list[i].ToString());
            }
            Console.WriteLine();

            SelectionSort(ref list);

            for (int i = 0; i < list.Count; i++)
            { 
                Console.Write(list[i].ToString());
            }


        }
    }
}
