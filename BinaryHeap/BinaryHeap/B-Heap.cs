using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryHeap
{
    class BinaryHeap<T>
        where T : IComparable<T>
    {
        private T[] ts;

        public int Count { get; private set; }


        public T this[int index]
        {
            get
            {
                return ts[index];
            }
        }

        public BinaryHeap()
        {
            ts = new T[5];
            Count = 0; 
        }

        public BinaryHeap(T[] array)
        {
            ts = new T[5];
            Count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Insert(array[i]);
            }
        }

        int getRightChild(int index)
        {
            return index * 2 + 2;
        }

        int getLeftChild(int index)
        {
            return index * 2 + 1;
        }

        int getParent(int index)
        {
            return (index - 1) / 2;
        }


        private void Resize(int newSize)
        {
            if (newSize == ts.Length)
            {
                return;
            }
            T[] temp = new T[newSize];
            for (int i = 0; i < ts.Length; i++)
            {
                temp[i] = ts[i];
            }
            ts = temp;
        }

        public void Insert(T value)
        {
            if(Count < ts.Length)
            {
                ts[Count] = value; 
            }
            else
            {
                Resize(ts.Length*2);
                ts[Count] = value;
            }
            HeapifyUp(Count);
            Count++; 
        }

        public void HeapifyUp(int index)
        {
            while(ts[index].CompareTo(ts[getParent(index)]) < 0 && getParent(index) >= 0)
            {
                T temp = ts[getParent(index)];
                ts[getParent(index)] = ts[index];
                ts[index] = temp;
            }
        }

        public T Pop()
        {
            T temp = ts[0];

            ts[0] = ts[ts.Length - 1];
            HeapifyDown(0);
            Count--; 

            return temp; 
        }

        public void HeapifyDown(int index)
        {
            //1. figure what the smallest child is
            //2. if the current value is greater than the smallest child, we still have to swap
            //3. repeat steps 1 and 2 until current value is less than both its children, or the current value reaches a leaf position

            while(ts[index].CompareTo(ts[getRightChild(index)]) > 0 || ts[index].CompareTo(ts[getRightChild(index)]) > 0 || getRightChild(index) > ts.Length || getLeftChild(index) > ts.Length)
            {
                if(ts[getRightChild(index)].CompareTo(ts[getLeftChild(index)]) > 0)
                {
                    T temp = ts[getLeftChild(index)];
                    ts[getLeftChild(index)] = ts[index];
                    ts[index] = temp;
                }
                else
                { 
                    T temp = ts[getRightChild(index)];
                    ts[getRightChild(index)] = ts[index];
                    ts[index] = temp;
                }
            }
        }
    }
}
