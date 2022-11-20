using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD4.Individual._2
{
    internal class TaskUtils
    {
        public static bool RemoveLineComments(string line, out string newLine)
        {
            newLine = line;
            for(int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '/' && line[i + 1] == '/')
                {
                    newLine = line.Remove(i);
                    return true;
                }
            }
            return false;
        }

        public static bool CheckStartComment(string line)
        {
            for(int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '/' && line[i + 1] == '*')
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckEndComment(string line)
        {
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '*' && line[i + 1] == '/')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
