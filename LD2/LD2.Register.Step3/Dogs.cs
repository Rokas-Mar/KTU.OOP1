﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.Register.Step3
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

        public int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - this.BirthDate.Year;
            if (this.BirthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        public static implicit operator List<object>(Dogs v)
        {
            throw new NotImplementedException();
        }

        public bool RequiresVaccination()
        {
            if(LastVaccinationDate.Equals(DateTime.MinValue))
            {
                return true;
            }
            return LastVaccinationDate.AddYears(vaccinationDuration).CompareTo(DateTime.Now) < 0;
        }
    }
}
