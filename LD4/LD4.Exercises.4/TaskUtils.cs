using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace LD4.Exercises._4
{
    internal class TaskUtils
    {
        public static int Process(string fin, string Punctuation)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            int equal = 0;
            foreach(string line in lines)
            {
                if(line.Length > 0)
                {
                    equal += FirstEqualLast(line, Punctuation);
                }
            }
            return equal;
        }

        private static int FirstEqualLast(string line, string Punctuation)
        {
            string[] parts = Regex.Split(line, Punctuation);
            int equal = 0;
            foreach(string word in parts)
            {
                if (word.Length > 0)
                {
                    if (word[0] == word[word.Length - 1])
                    {
                        equal++;
                    }
                }
            }
            return equal;
        }
    }
}
