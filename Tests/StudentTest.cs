using System;
using Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void GetAvgMarks_Avg()
        {
            Student student = new Student
            {
                Marks = new Mark[]
                {
                    new Mark { Value = 9 },
                    new Mark { Value = 9 },
                    new Mark { Value = 10 }
                }
            };
            string actual = Math.Round(student.GetAvgMark(), 2).ToString().Replace(',', '.');
            Assert.AreEqual("9.33", actual);
        }

        [TestMethod]
        public void ResetAllMarks_AllZero()
        {
            Student student = new Student
            {
                Marks = new Mark[]
                {
                    new Mark { Value = 9 },
                    new Mark { Value = 9 },
                    new Mark { Value = 10 }
                }
            };
            student.ResetAllMarks();
            Assert.IsTrue(student.Marks[0].Value == 0 && student.Marks[1].Value == 0 && student.Marks[2].Value == 0);
        }

        [TestMethod]
        public void GetAvgMarks_Empty_Nan()
        {
            Student s1 = new Student();
            Student s2 = new Student { Marks = new Mark[] { } };
            Assert.IsTrue(float.IsNaN(s1.GetAvgMark()) && float.IsNaN(s2.GetAvgMark()));
        }

        [TestMethod]
        public void ResetAllMarks_Empty_NoException()
        {
            Student s1 = new Student();
            Student s2 = new Student { Marks = new Mark[] { } };
            s1.ResetAllMarks();
            s2.ResetAllMarks();
            Assert.IsTrue(true);
        }
    }
}
