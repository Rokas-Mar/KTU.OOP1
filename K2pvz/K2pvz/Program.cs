// Rokas Marcinkevičius IFF 2/10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices.WindowsRuntime;

namespace K2pvz
{
    static class TaskUtils
    {
        public static bool NoDigits(string line)
        {
            string digits = "1234567890";
            foreach(char digit in digits)
            {
                if(line.Contains(digit))
                {
                    return false;
                }
            }
            return true;
        }

        public static int NumberDifferentVowelsInLine(string line)
        {
            int count = 0;
            string vowels = "aeyuioąęėįųū";
            foreach(char vowel in vowels)
            {
                if(line.Contains(vowel))
                {
                    count++;
                }
            }
            return count;
        }

        public static string FindWord1Line(string line, string punctuation)
        {
            string longestWord = "";

            string[] words = line.Split(punctuation.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (NumberDifferentVowelsInLine(word) == 3)
                {
                    if(word.Length > longestWord.Length)
                    {
                        longestWord = word;
                    }
                }
            }
            longestWord = Regex.Match(line, $"([{punctuation}]+|^)({longestWord}([{punctuation}]+|$))").Groups[2].Value;
            return longestWord;
        }

        public static string EditLine(string line, string punctuation, string word)
        {
            if (line.Contains(word))
            {
                string newWord = Regex.Match(line, word + "[" + punctuation + "]+").ToString();
                line = Regex.Replace(line, word + "[" + punctuation + "]+", "");
                line = newWord + line;
            }
            return line;
        }

        public static string FindWord2Line(string line, string punctuation)
        {
            string lastWord = "";
            string[] words = line.Split(line.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (NoDigits(line))
                {
                    lastWord = Regex.Match(line, $"([{punctuation}]+|^)({word}([{punctuation}]+|$))").Groups[2].Value;
                }
            }
            return lastWord;
        }

        public static void PerformTask(string fd, string fr)
        {
            using (var fileStream = File.OpenRead(fd))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                using (var writer = File.CreateText(fr))
                {
                    String line;
                    string punctuation = streamReader.ReadLine();
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(FindWord1Line(line, punctuation));
                    }
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            const string fd = "Tekstas.txt";
            const string fr = "RedTekstas.txt";

            TaskUtils.PerformTask(fd, fr);
        }
    }
}
