using Encapsulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class AnimalTest
    {
        [TestMethod]
        public void Group_AddRange()
        {
            Group<IDomesticMammal> mammals = new Group<IDomesticMammal>(new IDomesticMammal[]
            {
                new Cat { Name = "Garfield" },
                new Cat { Name = "Simba" },
                new Dog { Name = "Sosiska" }
            });
            Group<IPoultry> poultry = new Group<IPoultry>(new IPoultry[]
            {
                new Chicken { Name = "Tamka" },
                new Duck { Name = "Komsomolka" }
            });
            Group<ICarrying> carrying = new Group<ICarrying>(new ICarrying[]
            {
                new Horse { Name = "Abdulla" },
                new Camel { Name = "Vano" }
            });
            Group<Animal> animals = new Group<Animal>();
            animals.AddRange(mammals.Animals.Cast<Animal>().ToArray());
            animals.AddRange(poultry.Animals.Cast<Animal>().ToArray());
            animals.AddRange(carrying.Animals.Cast<Animal>().ToArray());
            Assert.AreEqual(7, animals.Count);
        }

        [TestMethod]
        public void Group_Add()
        {
            Group<IPoultry> poultry = new Group<IPoultry>(new IPoultry[]
            {
                new Chicken { Name = "Tamka" },
                new Duck { Name = "Komsomolka" }
            });
            poultry.Add(new Duck { Name = "Parovoz" });
            Assert.AreEqual("Parovoz", ((Duck)poultry[poultry.Count - 1]).Name);
        }
    }
}
