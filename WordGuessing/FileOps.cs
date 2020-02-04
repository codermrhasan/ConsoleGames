using System;
using System.IO;

namespace WordGuessing
{
    public class FileOps
    {
        public static void CreateGameFile()
        {
            string[] wordBook = {
                "Oscar", "Max", "Tiger", "Sam",
                "Misty", "Simba", "Coco", "Chloe",
                "Lucy", "Missy", "Molly", "Tigger",
                "Smokey", "Milo", "Cleo", "Sooty",
                "Monty", "Puss", "Kitty", "Felix" };
            string path = @"WordGame.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string line in wordBook)
                {
                    sw.WriteLine(line);
                }
            }
        }
        public static string[] ReadGameFile()
        {
            
            string[] totalWords = new string[20];

            /// Read all 20 words from file
            string path = @"WordGame.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                int i = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    totalWords[i] = s;
                    i++;
                }
            }


            /// Now select 10 random indexes for getting 10 
            /// random unique words
            int[] randomIndexes = new int[10];
            string[] wordList = new string[10];
            int j = 0;
            Random rand = new Random();
            while (true)
            {
                int index = rand.Next(20);
                if (Array.Exists(randomIndexes, e => e == index))
                {
                    continue;
                }
                if (j == 10)
                {
                    break;
                }
                wordList[j] = totalWords[index];
                randomIndexes[j] = index;
                j++;
            }

            /// Now we get our desired wordlist
            return wordList;
        }

    }
}
