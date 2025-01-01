using System;

namespace Recursion
{
    class Program
    {

        public static void countDown(int start, int end)
        {
            Console.WriteLine(start);
            start -= 1;
            if (start == end)
            {
                return; 
            }

            countDown(start, end); 
        }

        static void Main(string[] args)
        {
            countDown(5, 0); 
        }
    }
}
