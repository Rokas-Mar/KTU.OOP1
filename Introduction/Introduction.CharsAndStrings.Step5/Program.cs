using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.CharsAndStrings.Step5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string day;

            Console.WriteLine("Kokia siandien diena?");
            day = Console.ReadLine().ToLower();

            switch(day)
            {
                case "pirmadienis":
                    Console.WriteLine("Pirmadienis - sudetingiausia savaitės diena.");
                    break;
                case "antradienis":
                    Console.WriteLine("Antradienis – aktyviu veiksmu, Marso diena.");
                    break;
                case "treciadienis":
                    Console.WriteLine("Treciadienis – sandoriams sudaryti tinkamiausia diena.");
                    break;
                case "ketvirtadienis":
                    Console.WriteLine("Ketvirtadieni reiketu imtis visuomeniniu darbu.");
                    break;
                case "penktadienis":
                    Console.WriteLine("Penktadieni lengvai gimsta sedevrai, susitinka mylimieji.");
                    break;
                case "sestadienis":
                    Console.WriteLine("Sestadienis - savo problemu sprendimo diena.");
                    break;
                case "sekmadienis":
                    Console.WriteLine("Sekmadieni reiketu pradeti naujus darbus.");
                    break;
                    default:
                    Console.WriteLine("Tokios savaites dienos pas mus nebuna.");
                    break;
            }
        }
    }
}
