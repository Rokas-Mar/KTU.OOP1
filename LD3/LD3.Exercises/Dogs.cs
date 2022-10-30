using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3.Exercises
{
    internal class Dogs
    {
        private const int vaccinationDuration = 1;
        public DateTime LastVaccinationDate { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public Dogs(int id, string name, string breed, DateTime birthName, Gender gender)
        {
            this.ID = id;
            this.Name = name;
            this.Breed = breed;
            this.BirthDate = birthName;
            this.Gender = gender;
        }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (this.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public static implicit operator List<object>(Dogs v)
        {
            throw new NotImplementedException();
        }

        public bool RequiresVaccination
        {
            get
            {
                if (LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddYears(vaccinationDuration).CompareTo(DateTime.Now) < 0;
            }
        }

        public override bool Equals(object other)
        {
            return this.ID == ((Dogs)other).ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public int CompareTo(Dogs other)
        {
            if (this.Gender == other.Gender)
            {
                return this.Breed.CompareTo(other.Breed);
            }
            else
            {
                return other.Gender.CompareTo(this.Gender);
            }
        }
    }
}
