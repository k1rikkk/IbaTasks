using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParametersAndStatements;

namespace Tests
{
    [TestClass]
    public class ParametersAndStatementsStudentTest
    {
        [TestMethod]
        public void GetAvgMarks_Avg()
        {
            Mark[] marks = new Mark[]
            {
                new Mark { SubjectName = "1", Value = 9 },
                new Mark { SubjectName = "2", Value = 10 },
                new Mark { SubjectName = "3", Value = 9 }
            };
            Student student = new Student("Unset", "Unset", "Unset", marks: marks);
            string actual = Math.Round(student.GetAvgMark(), 2).ToString().Replace(',', '.');
            Assert.AreEqual("9.33", actual);
        }

        [TestMethod]
        public void ResetAllMarks_AllZero()
        {
            Mark[] marks = new Mark[]
            {
                new Mark { SubjectName = "1", Value = 9 },
                new Mark { SubjectName = "2", Value = 10 },
                new Mark { SubjectName = "3", Value = 9 }
            };
            Student student = new Student("Unset", "Unset", "Unset", marks: marks);
            student.ResetAllMarks();
            Assert.IsTrue(student.Marks[0].Value == 0 && student.Marks[1].Value == 0 && student.Marks[2].Value == 0);
        }

        [TestMethod]
        public void GetAvgMarks_Empty_Nan()
        {
            Student student = new Student("Unset", "Unset", "Unset");
            Assert.IsTrue(float.IsNaN(student.GetAvgMark()));
        }

        [TestMethod]
        public void AddMark_Same_Rewritten()
        {
            Student student = new Student("Unset", "Unset", "Unset");
            student.AddMark("Math", 9, out bool rewritten1);
            student.AddMark("Math", 10, out bool rewritten2);
            Assert.IsTrue(student.Marks[0].Value == 10 && student.Marks.Count == 1);
        }

        [TestMethod]
        public void AddMark_GreaterThanTen_Exception()
        {
            Student s1 = new Student("Unset", "Unset", "Unset");
            Mark mark = new Mark { SubjectName = "Math", Value = 12 };
            Assert.ThrowsException<ArgumentException>(() => s1.AddMark(mark, out bool rewritten));
        }
    }
}
