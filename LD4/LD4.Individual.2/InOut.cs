using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD4.Individual._2
{
    internal class InOut
    {
        public static void Process(string fin, string fout, string finfo)
        {
            bool isComment = false;
            string newLine;
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            using (var writerF = File.CreateText(fout))
            {
                using(var writeI = File.CreateText(finfo))
                { 
                    foreach (string line in lines)
                    {
                        if(line.Length > 0)
                        {
                            newLine = line;
                            if (TaskUtils.RemoveLineComments(line, out newLine) || TaskUtils.RemoveInlineComment(line, out newLine, ref isComment)
                                || TaskUtils.RemoveComment(line, out newLine, ref isComment) || isComment)
                            {
                                writeI.WriteLine(line);
                            }
                            if (newLine.Length > 0 & !isComment)
                            {
                                writerF.WriteLine(newLine);
                            }
                        }
                        else 
                        {
                            writerF.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
