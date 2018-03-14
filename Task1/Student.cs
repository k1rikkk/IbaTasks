using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string ResidenceAddress { get; set; }
        public Mark[] Marks { get; set; }
        
        public float GetAvgMark() 
            => Marks == null || Marks.Count() == 0 ? float.NaN : Marks.Sum(m => m.Value) / (float)Marks.Count();

        public void ResetAllMarks()
        {
            if (Marks == null)
                return;
            foreach (Mark mark in Marks)
                mark.Value = 0;
        }
    }
}
