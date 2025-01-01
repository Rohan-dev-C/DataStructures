
using System;

namespace BinaryHeap
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] nums = new int[] {10, 4, 1, 2, 7, 0 };
            BinaryHeap<int> heap = new BinaryHeap<int>(nums);
            Random rand = new Random();


            //for (int i = 0; i < 10; i++)
            //{
            //    heap.Insert(rand.Next(0, 10));
            //}

            

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{heap[i]} , ");
            //heap[i]
            //heap.ts[i]
                int test = heap[0];
            }
            
            
            
            
            
        }
    }
}
