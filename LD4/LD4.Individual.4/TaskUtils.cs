using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace LD4.Individual._4
{
    internal class TaskUtils
    {
        public static void Process(string fin, string fout, string punctuation, string word)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            using(var writer = File.CreateText(fout))
            {
                foreach(string line in lines)
                {
                    StringBuilder newLine = new StringBuilder();
                    RemoveWord(line, punctuation, word, newLine);
                    writer.WriteLine(newLine);
                }
            }
        }

        private static void RemoveWord(string line, string punctuation, string word, StringBuilder newLine)
        {
            int ind = line.IndexOf(word);
            while(ind != -1)
            {
                if (punctuation.IndexOf(line[ind + word.Length]) != -1)
                {
                    newLine = newLine.Remove(1, 3);
                }
            }
        }
    }
}
