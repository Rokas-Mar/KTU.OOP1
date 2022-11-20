using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;

namespace LD4.LD
{
    internal class TaskUtils
    {
        public static void Process(string fin, string fout)
        {
            using (var fileStream = File.OpenRead(fin))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                Sentence longestSentence = new Sentence();
                int index = 1;
                int longestIndex = -1;
                double sum = 0;

                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] sentences = line.Split('.');
                    foreach (string sentence in sentences)
                    {
                        Sentence seperatedSentence = new Sentence(sentence.Split(' '));
                        if (longestSentence < seperatedSentence)
                        {
                            longestIndex = index;
                            longestSentence = seperatedSentence;
                        }

                        sum += seperatedSentence.SumSentenceNumbers();
                    }
                    index++;
                }
                Console.WriteLine(longestSentence.ToString());
                Console.WriteLine("Sakinio eilute: " + longestIndex);
                Console.WriteLine("Symboliu skaicius: " + longestSentence.SymCount());
                Console.WriteLine("sum = " + sum);
            }
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
                    Sentence seperatedLine = new Sentence(Regex.Split(line, " +"));
                    if(longestLine < seperatedLine)
                    {
                        longestLine = seperatedLine;
                    }
                }
            }

            return longestLine;
        }

        public static List<int> GetAlignmentIndexes(string fin, string fout)
        {
            Sentence longestLine = GetLongestLine(fin);
            List<int> indexes = longestLine.AsignIndexes();

            for(int i = 0; i < indexes.Count; i++)
            {
                Console.WriteLine(indexes[i]);
            }

            using (var fileStream = File.OpenRead(fin))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    int lineLength = 0;
                    Sentence currentLine = new Sentence(Regex.Split(line, " +"));
                    for(int i = 0; i < currentLine.WordCount; i++)
                    {
                        int currentIndex = currentLine.Get(i).Length + 1;
                        int longestIndex = longestLine.Get(i).Length + 1;
                        if (longestIndex < currentIndex)
                        {
                            indexes[i + 1] += currentIndex - longestIndex;
                            lineLength = currentIndex - longestIndex;
                            for (int j = i + 2; j < longestLine.WordCount + 1; j++)
                            {
                                indexes[j] += lineLength;
                            }
                        }
                    }
                }
                for (int i = 0; i < indexes.Count; i++)
                {
                    Console.WriteLine(indexes[i]);
                }
            }

            return indexes;
        }
    }
}
