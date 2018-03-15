using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersAndStatements
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string ResidenceAddress { get; set; }
        protected List<Mark> marks { get; set; }
        public IReadOnlyList<Mark> Marks => marks;

        public Student(string firstName, string lastName, string phoneNumber, DateTime? birthDate = null
            , string residenceAddress = null, params Mark[] marks)  //  Optional, params, pass by value
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            ResidenceAddress = residenceAddress;
            this.marks = new List<Mark>();
            foreach (Mark mark in marks)
                AddMark(mark, out bool rewritten);
        }

        public void AddMark(string subjectName, byte value, out bool rewritten)         //  Pass by reference
            => AddMark(new Mark { SubjectName = subjectName, Value = value }, out rewritten);

        public void AddMark(Mark mark, out bool rewritten)
        {
            if (mark.Value > 10)
                throw new ArgumentException($"{nameof(mark.Value)} should be less than 10"); //  Throw
            rewritten = false;
            Mark cur = marks.FirstOrDefault(m => m.SubjectName == mark.SubjectName);
            if (cur != null)
            {
                rewritten = true;
                cur.Value = mark.Value;
            }
            else
                marks.Add(mark);
        }

        public float GetAvgMark()
        {
            if (marks.Count == 0)               //  if
                return float.NaN;
            else
            {
                var sum = 0f;                   //  Declaration, implicit type
                foreach (Mark mark in marks)    //  loop
                    sum += mark.Value;
                sum /= marks.Count;             //  Expression
                return sum;                     //  Return
            }
        }

        public void ResetAllMarks()
        {
            for (int i = 0; i < marks.Count; i++)
                marks[i].Value = 0;
        }
    }
}
