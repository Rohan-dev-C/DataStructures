using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrieNode
    {

        public char Letter { get; private set; }
        public Dictionary<char, TrieNode> Children { get; private set; }
        public bool IsWord { get; set; }

        public TrieNode(char c)
        {
            Children = new Dictionary<char, TrieNode>();
            Letter = c;
            IsWord = false;
        }
    }


    internal class Tries
    {
        public TrieNode root; 
        public int Count { get; private set;  }
        public Tries()
        {
            root = new TrieNode('$');
            Count = 0;
        }


        public void Clear()
        {

        }

        public void Insert(string word)
        {
            int current = 0;
            TrieNode node = root;
            while (current < word.Length)
            {
                if (node.Children.ContainsKey(word[current]) == false)
                {
                    TrieNode nextNode = new TrieNode(word[current]);
                    node.Children.Add(word[current], nextNode);
                    node = nextNode;
                    current++; 
                }
                else
                {
                    node = node.Children[word[current]]; 
                    current++;
                }
            }
            node.IsWord = true; 
            Count++; 
        }

        public bool Contains(string word)
        {
            return searchnode(word) != null; 
        }

        public TrieNode searchnode(string word)
        {
            TrieNode temp = root;
            int curr = 0;
            while (curr < word.Length)
            {
                if (temp.Children.ContainsKey(word[curr]))
                {
                    temp = temp.Children[word[curr]];
                    curr++;
                }
                else
                {
                    return null;
                }
            }
            if (temp.IsWord)
            {
                return temp;
            }
            else
            {
                return null; 
            }
        }

        public List<string> GetAllMatchingPrefix(string prefix)
        {
            List<string> list = new List<string>(); 
            Stack<TrieNode> trieNodes = new Stack<TrieNode>();
            TrieNode temp = root;
            int curr = 0;
            
            while (temp != null)
            {
                foreach (TrieNode i in temp.Children)
                {

                }
            }

                 
         }

       


        public bool Remove(string prefix)
        {
            TrieNode temp = root;
            if (Contains(prefix) == false)
            {
                return false;
            }
            else
            {
                temp = searchnode(prefix);
                temp.IsWord = false;
                return true;
            }
        }
    }
}
