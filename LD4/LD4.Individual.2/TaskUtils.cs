using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LD4.Individual._2
{
    internal class TaskUtils
    {
        public static bool RemoveLineComments(string line, out string newLine)
        {
            newLine = line;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '/' && line[i + 1] == '/')
                {
                    newLine = line.Remove(i);
                    return true;
                }
            }
            return false;
        }

        public static bool RemoveInlineComment(string line, out string newLine, ref bool isComment)
        {
            bool foundComment = false;
            isComment = false;
            newLine = line;
            for (int i = 0; i < newLine.Length - 1; i++)
            {
                if (newLine[i] == '/' && newLine[i + 1] == '*')
                {
                    isComment = true;
                    foundComment = true;
                    for(int j = i; j < line.Length - 1; j++)
                    {
                        if(newLine[j] == '*' && newLine[j + 1] == '/')
                        {
                            newLine = newLine.Remove(i, j - i + 2);
                            isComment = false;
                            break;
                        }
                    }
                }
                if(isComment)
                {
                    newLine = newLine.Remove(i);
                }
            }
            return foundComment;
        }

        public static bool RemoveComment(string line, out string newLine)
        {
            newLine = line;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '*' && line[i + 1] == '/')
                {
                    newLine = line.Substring(i + 2);
                    return true;
                }
            }
            return false;
        }
    }
}
