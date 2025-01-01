using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MarkovDecisionProcess
{
    public class Word
    {
        public string thisWord;
        public string[] nextPossibleWords;
        public List<string> tempNextWordList = new List<string>();
        public List<int> OccurenceIndexs = new List<int>();
        public int Count;

        public Word(string word)
        {
            thisWord = word;
        }
    }

    public class MarkovChain
    {
        public string[] allWordsArray;
        public Dictionary<string, Word> wordList;
        public string startingWord;

        public MarkovChain(string[] fullTextWordArray)
        {
            allWordsArray = fullTextWordArray;
            wordList = new Dictionary<string, Word>(); 
            ReadArray();
        }
        Random random = new Random(3);
        public string startGenerating(string word, int count)
        {
            int randomIndex = random.Next(0, wordList[word].nextPossibleWords.Length);
            string nextWord = wordList[word].nextPossibleWords[randomIndex];
            Console.Write(nextWord);
            Console.Write(' ');
            if (count < 100) 
            {
                if(count%5 == 0)
                {
                    Console.WriteLine("");
                }
                startGenerating(nextWord, count);
                count++;
            }
            return nextWord;
        }

        public void ReadArray()
        {
            for (int i = 0; i < allWordsArray.Length - 1; i++)
            {
                var temp = new Word(allWordsArray[i].ToLower());
                if (wordList.ContainsKey(allWordsArray[i].ToLower()))
                {
                    temp = wordList[allWordsArray[i].ToLower()];
                    wordList.Remove(allWordsArray[i].ToLower()); 
                }
                wordList.Add(allWordsArray[i].ToLower(), temp);
                wordList[allWordsArray[i].ToLower()].OccurenceIndexs.Add(i);
                wordList[allWordsArray[i].ToLower()].nextPossibleWords = createNextWordArray(wordList[allWordsArray[i].ToLower()]);
            }
        }



        string[] createNextWordArray(Word word)
        {
            for (int i = word.OccurenceIndexs[word.OccurenceIndexs.Count-1]; i < allWordsArray.Length - 1; i++)
            {
                word.tempNextWordList.Add(allWordsArray[i + 1].ToLower());
            }
            return word.tempNextWordList?.ToArray<string>();
        }

    }
}
