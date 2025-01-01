using System;
using System.Collections.Generic;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();

            Random rand = new Random(45);


            for (int i = 0; i < 5; i++)
            {
                tree.Insert(rand.Next(0, 100));
            }
            tree.Remove(22); 
            //tree.Insert(10);
            //tree.Insert(5);
            //tree.Insert(3);
            //tree.Insert(2);
            //tree.Insert(11);
            //tree.Insert(12);

        }

    }

}
