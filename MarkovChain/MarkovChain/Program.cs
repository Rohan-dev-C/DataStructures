using Microsoft.VisualBasic.FileIO;

namespace MarkovDecisionProcess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string txt = File.ReadAllText("C:\\Users\\Rohan.sampath\\source\\repos\\MarkovDecisionProcess\\MarkovDecisionProcess\\text1.txt"); 
            string[] words = txt.Split([' ', '\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
            MarkovChain MDP = new MarkovChain(words);
            string bruh = Console.ReadLine(); 
            MDP.startGenerating(bruh, 0); 
        }
    }
}
