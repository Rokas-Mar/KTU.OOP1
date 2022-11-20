using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LD4.LD
{
    internal class Sentence
    {
        private string[] words;

        public int WordCount
        {
            get
            {
                return words.Length;
            }
        }

        public Sentence(string[] words)
        {
            this.words = words;
        }

        public Sentence()
        {
            words = new string[1];
        }

        public int SymCount()
        {
            return string.Join(" ", words).Length + 1;
        }

        public double SumSentenceNumbers()
        {
            double sum = 0;
            double num = 0;

            for(int i = 0; i < words.Length; i++)
            {
                double.TryParse(words[i], out num);
                sum += num;
            }
            return sum;
        }

        public List<int> AsignIndexes()
        {
            List<int> indexes = new List<int>();
            int pos = 0;
            indexes.Add(0);
            for(int i = 0; i < WordCount; i++)
            {
                pos += words[i].Length + 1;
                indexes.Add(pos);
            }
            return indexes;
        }

        public string Get(int index)
        {
            return words[index];
        }

        public static bool operator >(Sentence lSent, Sentence rSent)
        {
            return lSent.WordCount > rSent.WordCount;
        }

        public static bool operator <(Sentence lSent, Sentence rSent)
        {
            return lSent.WordCount < rSent.WordCount;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Join(" ", words) + '.';
        }
    }

}
