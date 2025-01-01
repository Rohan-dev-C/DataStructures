using Red_Black_Tree;

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RedBlackTreeValidator
{

    public class UnitTest1
    {

        public List<int> InOrder(RedBlackTree<int> tree)
        {
            List<int> result = new List<int>();
            void helper(Node<int> node, ref List<int> list)
            {
                if (node.HasLeftChild && !list.Contains(node.LeftChild.Value)) helper(node.LeftChild, ref list);
                else if(node.HasRightChild && !list.Contains(node.RightChild.Value)) helper(node.RightChild, ref list);
                list.Add(node.Value); 
            }
            helper(tree.rootNode, ref result);
            return result;
        }

        public bool isValidTree(RedBlackTree<int> tree,   List<int> result)
        {
            bool isValid = true; 
           var temp = result;
           temp.Sort();
           for (int i = 0; i < temp.Count; i++)
           {
               if (!temp[i].Equals(result[i]))
               {
                    return false;
                }
           }
            int blackCount = 0;
            Node<int> temp2 = tree.rootNode;
            while (temp2.LeftChild != null)
            {
                if (temp2.IsBlack)
                { 
                    blackCount++;
                }
                temp2 = temp2.LeftChild;
            }

            Node<int> node = tree.rootNode;
            int currBlackCount = 0;
            void helper(Node<int> node, int currBlackCount)
            {
                if (node.IsRed)
                {
                    if (node.RightChild?.IsRed == true || node.LeftChild?.IsRed == true)
                    {
                        isValid = false;
                        return;
                    }
                }
                if (node.HasLeftChild)
                {
                    if(node.IsBlack)
                    {
                        currBlackCount++;
                    }
                    helper(node.LeftChild, currBlackCount);
                }
                else if (node.HasRightChild)
                {
                    if (node.IsBlack)
                    {
                        currBlackCount++; 
                    }
                    helper(node.RightChild, currBlackCount);
                }
            }
            helper(tree.rootNode, currBlackCount);

            if(tree.rootNode.IsRed)
            {
                return false; 
            }



            if(!isValid)
            {
                return false; 
            }
            return true;
        }
        [Theory]
        //[ClassData(typeof(DataGenerator))]
        [InlineData(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)]
        public void Test1(params int[] nums)
        {
            RedBlackTree<int> b = new RedBlackTree<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                b.Add(nums[i]);
            }
           
            List<int> result = InOrder(b);

            var valid = isValidTree(b, result);
            ;
        }
    }
}