using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace LD4.Individual._2
{
    internal class InOut
    {
        public static void Process(string fin, string fout)
        {
            bool isComment = false;

            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            using (var writerF = File.CreateText(fout))
            {
                foreach(string line in lines)
                {
                    string text = RemoveComment(line, ref isComment);
                    if (text != null)
                    {
                        writerF.WriteLine(text);
                    }
                }
            }
        }

        public static string RemoveComment(string line, ref bool isComment)
        {
            string newLine = line;

            for(int i = 0; i < newLine.Length - 1; i++)
            {
                if (!isComment)
                {
                    if (newLine[i] == '/' && newLine[i + 1] == '/')
                    {
                        newLine = newLine.Remove(i);
                        if (newLine == String.Empty)
                        {
                            return null;
                        }
                        return newLine;
                    }

                    if (newLine[i] == '/' && newLine[i + 1] == '*')
                    {
                        isComment = true;

                        for (int j = i; j < newLine.Length - 1; j++)
                        {
                            if (newLine[j] == '*' && newLine[j + 1] == '/')
                            {
                                newLine = newLine.Remove(i, j - i + 2);
                                i = 0;
                                isComment = false;
                                break;
                            }
                        }
                        if (isComment)
                        {
                            newLine = newLine.Remove(i);
                            if(newLine == String.Empty)
                            {
                                return null;
                            }
                            return newLine;
                        }
                    }
                }
                else if (newLine[i] == '*' && newLine[i + 1] == '/')
                {
                    isComment = false;
                    newLine = newLine.Substring(i + 2);
                    i = 0;
                    if(newLine == string.Empty)
                    {
                        return null;
                    }
                }
            }

            if (!isComment)
            {
                return newLine;
            }
            else
            {
                return null;
            }
        }
    }
}
