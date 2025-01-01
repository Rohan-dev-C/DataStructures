using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

#nullable enable 
namespace Red_Black_Tree
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public bool IsRed { get; set; }
        public bool IsBlack => !IsRed;
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
        public bool IsLeaf => LeftChild == null && RightChild == null;
        public bool Is4Node => LeftChild?.IsRed == true && RightChild?.IsRed == true;
        public bool Is2Node => LeftChild?.IsRed == false && IsBlack;
        public bool HasRightChild => RightChild != null;
        public bool HasLeftChild => LeftChild != null;
        public bool Has2Children => HasLeftChild && HasRightChild;

        public Node(T value, bool isRed)
        {
            Value = value;
            IsRed = isRed;
        }

        public override string ToString()
        {
            return $"Value: {Value}";
        }

    }
    public class RedBlackTree<T> where T : IComparable<T>
    {
        public Node<T> rootNode;
        public int Count { get; set; }
        public RedBlackTree()
        {
            Count = 0;
            rootNode = null;
        }

        public void FlipColor(Node<T> node)
        {
            if (!node.IsLeaf)
            {
                node.LeftChild.IsRed = node.IsRed;
                node.RightChild.IsRed = node.IsRed;
                node.IsRed = !node.IsRed;
                if (rootNode.Value.CompareTo(node.Value) == 0)
                {
                    node.IsRed = false;
                }
                if (rootNode.IsRed)
                {
                    rootNode.IsRed = false;
                }

            }
        }
        public Node<T> RotateRight(Node<T> node)
        {
            Node<T> rotate = node.LeftChild;
            node.LeftChild = rotate.RightChild;
            rotate.RightChild = node;
            rotate.IsRed = node.IsRed;
            node.IsRed = true;
            return rotate;
        }
        public Node<T> RotateLeft(Node<T> node)
        {
            Node<T> rotate = node.RightChild;
            node.RightChild = rotate.LeftChild;
            rotate.LeftChild = node;
            rotate.IsRed = node.IsRed;
            node.IsRed = true;
            return rotate;
        }

        public void Add(T value)
        {
            if (rootNode == null)
            {
                rootNode = new Node<T>(value, false);
                Count++;
                return;
            }
            rootNode = Add(value, rootNode);
        }
        private Node<T> Add(T value, Node<T> curr)
        {
            if (curr == null)
            {
                return new Node<T>(value, true);
            }
            if (curr.Is4Node)
            {
                FlipColor(curr);
            }
            if (curr.Value.CompareTo(value) > 0)
            {
                curr.LeftChild = Add(value, curr.LeftChild);
            }
            else
            {
                curr.RightChild = Add(value, curr.RightChild);
            }
            if (curr.Is4Node)
            {
                FlipColor(curr);
            }
            if (curr?.LeftChild != null && curr.LeftChild.IsRed && curr.LeftChild.LeftChild != null && curr.LeftChild.LeftChild.IsRed)
            {
                curr = RotateRight(curr);
            }
            if (curr.RightChild != null && curr.RightChild.IsRed)
            {
                curr = RotateLeft(curr);
            }
            return curr;
        }


        public void Remove(T value)
        {
            Node<T> curr = rootNode;
            if (rootNode.Value.CompareTo(value) == 0)
            {
                if (curr.IsLeaf)
                {
                    rootNode = null;
                    return;
                }
                curr = curr.RightChild;
                while (curr.LeftChild != null)
                {
                    curr = curr.LeftChild;
                }
                var temp = rootNode.Value;
                rootNode.Value = curr.Value;
                curr.Value = temp;
                curr = null;
                return;
            }
            rootNode = Remove(value, curr, null);
        }



        private Node<T> Remove(T value, Node<T> curr, Node<T> parent)
        {
            if(curr == null)
            {
                throw new Exception("not in tree");
            }
            if (value.CompareTo(curr.Value) < 0)
            {
                curr = MoveLeft(value, curr);
            }
            else
            {
                if (value.CompareTo(curr.Value) == 0 && curr.IsLeaf)
                {
                    return null;
                }
                else
                {
                    if (curr.RightChild != null)
                    {
                        curr = MoveRedRight(curr);
                    }
                    if (curr.Value.CompareTo(value) == 0)
                    {
                        if (curr.HasRightChild || curr.HasLeftChild)
                        {
                            if (curr.Has2Children)
                            {
                                var tempParent = parent; 
                                var temp = curr;
                                tempParent = temp; 
                                temp = temp.RightChild;

                                while (temp.LeftChild != null)
                                {
                                   tempParent = temp; ;
                                   temp = temp.LeftChild;
                                }
                                var temp2 = curr.Value; 
                                curr.Value = temp.Value;
                                temp.Value = temp2;
                                tempParent.RightChild = temp.RightChild;
                                curr.RightChild = Remove(value, curr.RightChild, curr);                         
                                FixUp(curr);
                                return curr;
                            }
                            else if (curr.HasLeftChild)
                            {
                                parent.RightChild = curr.LeftChild;

                                FixUp(curr);
                                return curr.LeftChild;
                            }
                            else
                            {
                                parent.RightChild = curr.RightChild;

                                FixUp(curr);
                                return curr.RightChild;
                            }
                        }
                    }
                }
                if (value.CompareTo(curr.Value) >= 0)
                {
                    curr = MoveRight(value, curr);
                }
            }
            FixUp(curr);
            return curr;
        }

        Node<T> MoveLeft(T value, Node<T> curr)
        {
            if (curr.LeftChild != null)
            {
                if (curr.Is2Node)
                {
                    MoveRedLeft(curr);
                }
                 curr.LeftChild = Remove(value, curr.LeftChild, curr);
            }
            return curr;
        }

        Node<T> MoveRight(T value, Node<T> curr)
        {
            if (curr.RightChild != null)
            {
                if (curr.Is2Node)
                {
                    MoveRedRight(curr);
                }
                curr.RightChild = Remove(value, curr.RightChild, curr);
            }
            return curr;
        }

        private Node<T> MoveRedRight(Node<T> node)
        {
            if (node.RightChild?.RightChild?.IsRed == false && node.RightChild?.LeftChild?.IsRed == false)
            {
                FlipColor(node);
            }
            if (node.LeftChild?.IsRed == true && node.LeftChild?.LeftChild?.IsRed == true)
            {
                node = RotateRight(node);
                FlipColor(node.LeftChild);
            }
            return node;
        }

        private Node<T> MoveRedLeft(Node<T> node)
        {
            if (node.LeftChild?.RightChild?.IsRed == false && node.LeftChild?.LeftChild?.IsRed == false)
            {
                FlipColor(node);
            }
            if (node.RightChild?.IsRed == true && (node.RightChild?.LeftChild?.IsRed == true))
            {
                node.RightChild = RotateRight(node.RightChild);
                node = RotateLeft(node);
                FlipColor(node);
            }
            return node;
        }

        private Node<T> FixUp(Node<T> node)
        {
            if (node.RightChild != null && node.RightChild.IsRed)
            {
                node = RotateLeft(node);
            }
            if (node.LeftChild == null)
            {
                return node;
            }
            if (node.LeftChild.LeftChild != null & node.LeftChild.IsRed && node.LeftChild.LeftChild.IsRed)
            {
                node = RotateRight(node);
            }
            if (node.Is4Node)
            {
                FlipColor(node);
            }
            if (node.LeftChild.RightChild != null && node.LeftChild.RightChild.IsRed)
            {
                node = RotateLeft(node);
            }
            return node;
        }
    }
}
