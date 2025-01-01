using System;

namespace RecursiveAdding
{
    class Program
    {
        public static int addArray(int[] array, int current)
        {
            if (current == 0)
            {
                return array[0]; 
            }
            return array[current] + addArray(array, current - 1); 
        }
        static void Main(string[] args)
        {
            int[] array = new int[5];
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = i; 
            }

            Console.WriteLine(addArray(array, 3)); 


        }
    }
}
