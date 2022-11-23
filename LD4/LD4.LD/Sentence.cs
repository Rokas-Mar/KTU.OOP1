using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text.RegularExpressions;

namespace LD4.LD
{
    /// <summary>
    /// Sentence class working with sentence words
    /// </summary>
    internal class Sentence
    {
        private string[] Words;
        public int Length = 0;

        public Sentence(string[] words)
        {
            Words = words;
            Length = words.Count();
        }

        public Sentence()
        {
            Words = new string[0];
            Length = 0;
        }

        /// <summary>
        /// Adds word to sentence
        /// </summary>
        /// <param name="word">word to add</param>
        public void Add(string word)
        {
            Length++;
            this.Words[Length] = word;
        }

        /// <summary>
        /// removes indexed element
        /// </summary>
        /// <param name="index">element index to remove</param>
        public void Remove(int index)
        {
            for(int i = index; i < Length - 1; i++)
            {
                Words[i] = Words[i + 1];
            }
            Length--;
        }

        /// <summary>
        /// Gets count of only words in Sentence element
        /// </summary>
        /// <returns>number of words contained in Sentence element</returns>
        public int GetWordCount()
        {
            int count = 0;

            foreach(string word in Words)
            {
                if (Regex.IsMatch(word, "[a-zA-Z0-9ąčęėįšųūžĄČĘĖĮŠŲŪŽ]+"))
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Finds symbol count of sentence
        /// </summary>
        /// <returns>symbol count of sentence</returns>
        public int SymCount()
        {
            return string.Join(" ", Words).Trim().Length + 1;
        }

        /// <summary>
        /// Counts sum of all sentence numbers
        /// </summary>
        /// <returns>Sum of all words made out of numbers only</returns>
        public int SumSentenceNumbers()
        {
            int sum = 0;

            foreach(string word in Words)
            {
                string newWord = TaskUtils.RemoveSym(word);
                if (Regex.IsMatch(newWord, @"^\d+$"))
                {
                    int num = Convert.ToInt32(newWord);
                    for(int j = 0; j < newWord.Length; j++)
                    {
                        sum += num % 10;
                        num /= 10;
                    }
                }
            }
            return sum;
        }

        /// <summary>
        /// Assigns word lengths to every word
        /// </summary>
        /// <returns>List of lengths</returns>
        public List<int> AsignLengths()
        {
            int length;
            List<int> lengths = new List<int>();
            for (int i = 0; i < Length; i++)
            {
                int freq = Regex.Matches(Words[i], "[\t]").Count;
                length = Words[i].Length + 7 * freq;
                lengths.Add(length);
            }
            return lengths;
        }

        /// <summary>
        /// Gets indexed element
        /// </summary>
        /// <param name="index">index of element</param>
        /// <returns>Indexed element</returns>
        public string Get(int index)
        {
            return Words[index];
        }

        /// <summary>
        /// Adds space to word to match alignment
        /// </summary>
        /// <param name="index">which word to add space to</param>
        public void AddSpace(int index)
        {
            Words[index] += " ";
        }

        /// <summary>
        /// override of operator >
        /// </summary>
        /// <param name="lSent">Sentence class element</param>
        /// <param name="rSent">Sentence class element</param>
        /// <returns>true if lSent has greater word count to rSent</returns>
        public static bool operator >(Sentence lSent, Sentence rSent)
        {
            return lSent.Length > rSent.Length;
        }

        /// <summary>
        /// override of operator <
        /// </summary>
        /// <param name="lSent">Sentence class element</param>
        /// <param name="rSent">Sentence class element</param>
        /// <returns>true if lSent has lesser word count to rSent</returns>
        public static bool operator <(Sentence lSent, Sentence rSent)
        {
            return lSent.Length < rSent.Length;
        }

        /// <summary>
        /// overrides Equals
        /// </summary>
        /// <param name="obj">object class element</param>
        /// <returns>true if obj equals to base</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// GetHashCode override
        /// </summary>
        /// <returns>Hash code of base object</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// ToString override, joins words with spaces
        /// </summary>
        /// <returns>string element of joined words</returns>
        public override string ToString()
        {
            return string.Join(" ", Words).Trim() + ".";
        }

        /// <summary>
        /// ToString override, joins words with spacing
        /// </summary>
        /// <returns>string element of aligned words</returns>
        public string ToStringAligned(string spacing)
        {
            return string.Join(spacing, Words);
        }
    }
}
