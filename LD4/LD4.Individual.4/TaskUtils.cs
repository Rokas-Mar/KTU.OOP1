using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace LD4.Individual._4
{
    internal class TaskUtils
    {
        public static void Process(string win, string fin, string fout, string punctuation)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            string[] words = File.ReadAllLines(win, Encoding.UTF8);
            using(var writer = File.CreateText(fout))
            {
                foreach (string line in lines)
                {
                    string newLine = RemoveWord(line, punctuation, words);
                    writer.WriteLine(newLine);
                }
            }
        }

        private static string RemoveWord(string line, string punctuation, string[] words)
        {
            foreach (string word in words)
            {
                string newWord = Regex.Escape(word);
                line = Regex.Replace(line, newWord + punctuation, string.Empty);
            }
            return line;
        }
    }
}
