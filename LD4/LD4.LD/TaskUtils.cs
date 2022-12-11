using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace LD4.LD
{
    internal class TaskUtils
    {
        /// <summary>
        /// Analyzes text, picks out longest sentence, longest sentence word count, symbol count, numbers in text count, and their sum
        /// </summary>
        /// <param name="fin">initial txt file</param>
        /// <param name="fout">txt file to print to</param>
        public static void Process(string fin, string fout)
        {
            using (var fileStream = File.OpenRead(fin))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                using (var writeI = File.CreateText(fout))
                {
                    string newSentence = "";
                    Sentence longestSeperatedSentence = new Sentence();
                    string longestSentence = "";
                    int index = 1;
                    int newIndex = index;
                    int longestIndex = -1;
                    int sum = 0;
                    int numCount = 0;

                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (Regex.IsMatch(line, "[.?!]"))
                        {
                            newSentence += line;
                            string[] sentences = Regex.Split(newSentence, @"(?<=[.?!])");

                            foreach (string sentence in sentences)
                            {
                                Sentence seperatedSentence = new Sentence(Regex.Split(sentence, "([^a-zA-Z0-9ąčęėįšųūžĄČĘĖĮŠŲŪŽ]+)"));
                                if (longestSeperatedSentence < seperatedSentence)
                                {
                                    longestIndex = newIndex;
                                    longestSeperatedSentence = seperatedSentence;
                                    longestSentence = sentence;
                                }

                                sum += seperatedSentence.SumSentenceNumbers();
                                numCount += GetNumCount(seperatedSentence);
                            }
                            newSentence = "";
                        }
                        else
                        {
                            newSentence += line + " ";
                            if(line != String.Empty)
                            {
                                newIndex = index;
                            }
                        }
                        index++;
                    }
                    var info = new FileInfo(fin);
                    if (info.Length > 0)
                    {
                        int wordCount = longestSeperatedSentence.GetWordCount();
                        writeI.WriteLine(longestSentence);
                        writeI.WriteLine("Sakinio eilutė: {0}", longestIndex);
                        writeI.WriteLine("Žodžių skaičius: {0}", wordCount);
                        writeI.WriteLine("Symbolių skaičius: {0}", longestSentence.Length);
                        writeI.WriteLine("Tekste esančių skaičių kiekis = {0}, suma = {1}", numCount, sum);
                    }
                    else
                    {
                        writeI.WriteLine("Failas yra tuščias");
                    }
                }
            }
        }

        /// <summary>
        /// Finds words made out of numbers only and counts them
        /// </summary>
        /// <param name="sentence">Sentence element</param>
        /// <returns>count of words made of numbers only</returns>
        public static int GetNumCount(Sentence sentence)
        {
            int count = 0;

            for(int i = 0; i < sentence.Length; i++)
            {
                string word = RemoveSym(sentence.Get(i));
                if(Regex.IsMatch(word, @"^\d+$"))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Finds the longest line
        /// </summary>
        /// <param name="fin">input text</param>
        /// <returns>Returns Sentence element containing longest line words</returns>
        public static Sentence GetLongestLine(string fin)
        {
            List<int> wordIndex = new List<int>();
            Sentence longestLine = new Sentence();
            using (var fileStream = File.OpenRead(fin))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    line = TaskUtils.RemoveSymbols(line);
                    Sentence seperatedLine = new Sentence(Regex.Split(line, "[ ]+"));
                    if (longestLine < seperatedLine)
                    {
                        longestLine = seperatedLine;
                    }
                }
            }

            return longestLine;
        }

        /// <summary>
        /// Counts positions which words should be aligned with
        /// </summary>
        /// <param name="fin">input text</param>
        /// <returns>List element of word length indexes</returns>
        public static List<int> GetAlignmentIndexes(string fin)
        {
            int currentLength;
            Sentence longestLine = GetLongestLine(fin);
            List<int> wordLengths = longestLine.AsignLengths();

            using (var fileStream = File.OpenRead(fin))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    line = TaskUtils.RemoveSymbols(line);
                    Sentence currentLine = new Sentence(Regex.Split(line, "[ ]+"));
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        string currentWord = currentLine.Get(i);
                        int freq = Regex.Matches(currentWord, "[\t]").Count;
                        currentLength = currentWord.Length + 7 * freq;
                        if (wordLengths[i] < currentLength)
                        {
                            wordLengths[i] = currentLength;
                        }
                    }
                }
            }

            return wordLengths;
        }

        /// <summary>
        /// aligns text to their indexed positions
        /// </summary>
        /// <param name="fin">input text</param>
        /// <param name="fout">output text</param>
        /// <param name="spacing">how to space words</param>
        public static void Align(string fin, string fout, string spacing)
        {
            List<int> indexes = GetAlignmentIndexes(fin);

            using (var fileStream = File.OpenRead(fin))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                using (var writeI = File.CreateText(fout))
                {
                    String line;
                    string punctuation = streamReader.ReadLine();
                    Console.WriteLine(punctuation);
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        line = TaskUtils.RemoveSymbols(line);
                        Sentence currentLine = new Sentence(Regex.Split(line, "[ ]+"));
                        for (int i = 0; i < currentLine.Length; i++)
                        {
                            string currentWord = currentLine.Get(i);
                            int freq = Regex.Matches(currentWord, "[\t]").Count;
                            int currentLength = currentWord.Length + 7 * freq;
                            while (currentLength < indexes[i])
                            {
                                currentLine.AddSpace(i);
                                currentLength++;
                            }
                        }
                        writeI.WriteLine(currentLine.ToString(spacing));
                    }
                }
            }
        }

        /// <summary>
        /// removes symbols from the whole line, leaving just one of each kind
        /// </summary>
        /// <param name="line">line which will have symbols removed</param>
        /// <returns>line with symbols apart from one of each kind removed</returns>
        public static string RemoveSymbols(string line)
        {
            while (Regex.IsMatch(line, "([^a-zA-Z0-9ąčęėįšųūžĄČĘĖĮŠŲŪŽ ])\\1"))
            {
                line = Regex.Replace(line, "([^a-zA-Z0-9ąčęėįšųūžĄČĘĖĮŠŲŪŽ ])\\1", "$1");
            }
            return line;
        }

        /// <summary>
        /// removes all symbols from word
        /// </summary>
        /// <param name="word">word to analyze</param>
        /// <returns>word with deleted symbols</returns>
        public static string RemoveSym(string word)
        {
            while (Regex.IsMatch(word, "([^a-zA-Z0-9ąčęėįšųūžĄČĘĖĮŠŲŪŽ ])"))
            {
                word = Regex.Replace(word, "([^a-zA-Z0-9ąčęėįšųūžĄČĘĖĮŠŲŪŽ ])", string.Empty);
            }
            return word;
        }
    }
}
