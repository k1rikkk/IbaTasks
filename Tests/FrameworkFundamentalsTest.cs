using System;
using System.Collections.Generic;
using FrameworkFundamentals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FrameworkFundamentalsTest
    {
        [TestMethod]
        public void ListEmployeesSort_Randoms_BySalary()
        {
            List<Employee> employees = new List<Employee>();
            int count = 5;
            for (int i = 0; i < count; i++)
                employees.Add(new Employee
                {
                    FirstName = i.ToString(),
                    Salary = new Random().Next(0, 200000)
                });
            employees.Sort();
            bool ok = true;
            for (int i = 1; i < count; i++)
                if (employees[i].Salary < employees[i - 1].Salary)
                {
                    ok = false;
                    break;
                }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void ListEmployeesSort_BySalary()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { FirstName = "1", Salary = 150000 },
                new Employee { FirstName = "2", Salary = 200000 },
                new Employee { FirstName = "3", Salary = 100000 }
            };
            employees.Sort();
            Assert.IsTrue(employees[0].Salary == 100000 && employees[1].Salary == 150000 && employees[2].Salary == 200000);
        }
    }
}
