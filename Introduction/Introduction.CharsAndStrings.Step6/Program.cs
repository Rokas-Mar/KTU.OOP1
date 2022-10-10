using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.CharsAndStrings.Step6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> weekDays = new Dictionary<string, string>()
            {
                {"pirmadienis", "Pirmadienis - sudetingiausia savaites diena."},
                {"antradienis", "Antradienis – aktyviu veiksmu, Marso diena."},
                {"treciadienis", "Treciadienis – sandoriams sudaryti tinkamiausia diena."},
                {"ketvirtadienis", "Ketvirtadieni reiketu imtis visuomeniniu darbu."},
                {"penktadienis", "Penktadieni lengvai gimsta sedevrai, susitinka mylimieji."},
                {"sestadienis", "Sestadienis - savo problemu sprendimo diena."},
                {"sekmadienis", "Sekmadieni reiketu pradeti naujus darbus, kurti planus."}
            };

            Console.WriteLine("Kokia siandien savaites diena?");
            string day = Console.ReadLine().ToLower();
            if (weekDays.ContainsKey(day))
                Console.WriteLine("{0}", weekDays[day]);
            else
                Console.WriteLine("Tokios savaites dienos pas mus nebuna.");
        }
    }
}
