using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AVLTree
{
    [DebuggerDisplay("{value}")]
    class Node<T>
    {
        public T value;

        public Node<T> rightChild;
        public Node<T> leftChild;
        public int Height { get; set;  }


        public Node(T value)
        {
            this.value = value;
            Height = 1; 
        }

        public Node<T> First
        {
            get
            {
                if (leftChild != null) return leftChild;
                if (rightChild != null) return rightChild;
                return null;
            }
        }

        public int Balance  
        { 
            get 
            {
                int heightLC = leftChild == null ? 0 : leftChild.Height;
                int heightRC = rightChild == null ? 0 : rightChild.Height;
                return heightRC - heightLC;
            } 
        }

        public int ChildCount
        {
            get
            {
                int count = 0;
                if (leftChild != null) count++;
                if (rightChild != null) count++;
                return count;
            }
        }

    }

    //TODO: Fix me!
    class AVLTree<T>
          where T: IComparable<T> 
    {  
        public Node<T> root; 
        public int Count { get; private set;  }
        public AVLTree()
        {
            root = null;
            Count = 0; 
        }

        public void Clear()
        {
            root = null;
            Count = 0; 
        }
        public bool IsEmpty()
        {
            return Count > 0; 
        }
        public void UpdateHeight(Node<T> parent)
        {
            int tempHeight1 = 0;
            int tempHeight2 = 0; 
            if(parent.rightChild == null)
            {
                tempHeight1 = 0; 
            }
            else
            {
                tempHeight1 = parent.rightChild.Height;
            }
            if(parent.leftChild == null)
            {
                tempHeight2 = 0; 
            }
            else
            {
                tempHeight2 = parent.leftChild.Height;
            }
            parent.Height = tempHeight2 > tempHeight1 ? tempHeight2 + 1 : tempHeight1 + 1; 
        }


        private Node<T> RotateLeft(Node<T> subTreeParent)
        {
            Node<T> rotate = subTreeParent.rightChild;
            subTreeParent.rightChild = rotate.leftChild;
            rotate.leftChild = subTreeParent;
            UpdateHeight(subTreeParent); 
            return rotate;
        }
        private Node<T> RotateRight(Node<T> subTreeParent)
        {
            Node<T> rotate = subTreeParent.leftChild;
            subTreeParent.leftChild = rotate.rightChild;
            rotate.rightChild = subTreeParent;
            UpdateHeight(subTreeParent); 
            return rotate;
        }


        public Node<T> BalanceTree(Node<T> node)
        {
            if (node.Balance <= -2)
            {
                if (node.leftChild.Balance > 0)
                {
                    node.leftChild = RotateLeft(node.leftChild); 
                }
                node = RotateRight(node);
            }
            else if(node.Balance >= 2)
            {
                if (node.rightChild.Balance < 0)
                {
                    node.rightChild = RotateRight(node.rightChild);
                }
                node = RotateLeft(node); 
            }
            return node; 
        }
        #region insert

        public void Insert(T value)
        {
            Count++;
            if (root == null)
            {
                root = new Node<T>(value);
                return; 
            }
            root = Insert(value, root);  
        }
        private Node<T> Insert(T value, Node<T> temp)
        {
            UpdateHeight(temp); 
            if(value.CompareTo(temp.value) > 0)
            {
                if (temp.rightChild == null)
                {
                    temp.rightChild = new Node<T>(value);
                    return temp; 
                }
                else
                {
                    temp.rightChild = Insert(value, temp.rightChild);
                }
                UpdateHeight(temp);
                return BalanceTree(temp); 
            }
            else if(value.CompareTo(temp.value) <= 0)
            {
                if (temp.leftChild == null)
                {
                    temp.leftChild = new Node<T>(value);
                    return temp; 
                }
                else
                {
                    temp.leftChild = Insert(value, temp.leftChild);
                }
                UpdateHeight(temp);
                return BalanceTree(temp); 
            }
            throw new Exception("something is broken");
        }
        #endregion

        #region REMOVE
        public void Remove(T value)
        {
            Count--;
            root = Remove(value, root); 
        }

        private Node<T> Delete(Node<T> temp)
        {
            if (temp.ChildCount == 0)
            {
                return null;
            }
            if (temp.ChildCount == 1)
            {
                if (temp.rightChild == null)
                {
                    return temp.leftChild;
                }
                else
                {
                    return temp.rightChild;
                }
            }
            if (temp.ChildCount == 2)
            {
                Node<T> original = temp;
                Node<T> parent = original;
                temp = temp.leftChild; 
                while(temp.rightChild != null)
                {
                    parent = temp;
                    temp = temp.rightChild; 
                }
                original.value = temp.value;
      
                
                if (temp == original.leftChild)
                {
                    original.leftChild = Delete(original.leftChild);
                    //temp = null;
                }
                else
                {
                    parent.rightChild = Delete(parent.rightChild);
                    //temp = null;      
                }

                return original;
            }
            else
            {
                throw new Exception("shouldnt have more than 2 children");
            }
        }

        public Node<T> Remove(T value, Node<T> temp)
        {
            
            if (temp == null) return null;

            
            if (value.CompareTo(temp.value) < 0)
            {
                temp.leftChild = Remove(value, temp.leftChild);
            }
            else if (value.CompareTo(temp.value) > 0)
            {
                temp.rightChild = Remove(value, temp.rightChild);
            }
       
            else if(value.CompareTo(temp.value) == 0)
            {
                return Delete(temp); 
            }
            UpdateHeight(temp);
            return BalanceTree(temp);
        }
        #endregion


        #region traversal

        public List<Node<T>> InOrder()
        {



        }

        private void InOrder(List<Node<T>> list)
        {
            if (list.Count == 0)
            {
                list.Add(root); 
            }
            




            
        }

        #endregion 
    }



}
