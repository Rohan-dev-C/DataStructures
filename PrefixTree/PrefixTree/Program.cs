namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tries trie = new Tries();

            trie.Insert("heaven");
            trie.Insert("hey");
            trie.Insert("hello");
            trie.Insert("havana");
            trie.Insert("he");
            trie.Insert("babe");
            trie.Insert("baby");

            bool searched = trie.Contains("hello");

        }
    }
}