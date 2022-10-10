using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.Register.Step3
{
    class Vaccination
    {
        public int DogID { get; set; }
        public DateTime Date { get; set; }

        public Vaccination(int dogID, DateTime date)
        {
            this.DogID = dogID;
            this.Date = date;
        }
    }
}
