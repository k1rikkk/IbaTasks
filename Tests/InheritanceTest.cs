using Inheritance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class InheritanceTest
    {
        [TestMethod]
        public void Human_Props()
        {
            Human[] humans = new Human[]
            {
                new Boy { FirstName = "Kirill", LastName = "Kovalyov" },
                new Girl { FirstName = "Ann", LastName = "Ordo" }
            };
            Assert.AreEqual("Kirill Kovalyov, Ann Ordo", string.Join(", ", humans.Select(h => h.FullName)));
            Assert.AreEqual("Handshake, Hangs", string.Join(", ", humans.Select(h => h.Introduction)));
            Assert.AreEqual("Boy: Kirill Kovalyov, Girl: Ann Ordo", string.Join(", ", humans.Select(h => h.ToString())));
        }

        [TestMethod]
        public void Boy_Props()
        {
            Boy boy = new Boy { FirstName = "Kirill", LastName = "Kovalyov" };
            boy.PassMedicalExamination();
            Assert.AreNotEqual(null, boy.IsSuitableForArmy);
        }
    }
}
