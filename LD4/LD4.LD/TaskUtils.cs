using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Runtime.CompilerServices;
using System.Configuration;

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
                    Sentence longestSentence = new Sentence();
                    int index = 1;
                    int longestIndex = -1;
                    int sum = 0;
                    int numCount = 0;

                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (Regex.IsMatch(line, "[.?!]"))
                        {
                            newSentence += line;
                            string[] sentences = Regex.Split(newSentence, "[.?!]");

                            foreach (string sentence in sentences)
                            {
                                Sentence seperatedSentence = new Sentence(Regex.Split(sentence, "[ ]+"));
                                seperatedSentence.RemoveEmpty();
                                if (longestSentence < seperatedSentence)
                                {
                                    longestIndex = index;
                                    longestSentence = seperatedSentence;
                                }

                                sum += seperatedSentence.SumSentenceNumbers();
                                numCount += GetNumCount(seperatedSentence);
                            }
                            index++;
                            newSentence = "";
                        }
                        else
                        {
                            newSentence += line + " ";
                        }
                    }

                    string longestSent = longestSentence.ToString();
                    int symbolCount = longestSentence.SymCount();
                    writeI.WriteLine(longestSent);
                    writeI.WriteLine("Sakinio eilutė: {0}", longestIndex);
                    writeI.WriteLine("Žodžių skaičius: {0}", longestSentence.Length);
                    writeI.WriteLine("Symbolių skaičius: {0}", symbolCount);
                    writeI.WriteLine("Tekste esančių skaitmenų kiekis = {0}, suma = {1}", numCount, sum);
                }
            }
        }

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
                        currentLength = currentLine.Get(i).Length;
                        if (wordLengths[i] < currentLength)
                        {
                            wordLengths[i] = currentLength;
                        }
                    }
                }
            }

            return wordLengths;
        }

        public static void Align(string fin, string fout, string spacing)
        {
            List<int> indexes = GetAlignmentIndexes(fin);

            using (var fileStream = File.OpenRead(fin))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                using (var writeI = File.CreateText(fout))
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
                            int currentLength = currentWord.Length + (7 * freq);
                            while (currentLength < indexes[i])
                            {
                                currentLine.AddSpace(i);
                                currentLength++;
                            }
                        }
                        writeI.WriteLine(currentLine.ToStringAligned(spacing));
                    }
                }
            }
        }

        public static string RemoveSymbols(string line)
        {
            while (Regex.IsMatch(line, "([^a-zA-Z1-9 ])\\1"))
            {
                line = Regex.Replace(line, "([^a-zA-Z1-9 ])\\1", "$1");
            }
            return line;
        }

        public static string RemoveSym(string word)
        {
            while (Regex.IsMatch(word, "([^a-zA-Z1-9 ])"))
            {
                word = Regex.Replace(word, "([^a-zA-Z1-9 ])", string.Empty);
            }
            return word;
        }
    }
}
