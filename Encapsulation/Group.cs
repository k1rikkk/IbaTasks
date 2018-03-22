using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Group<T> where T : IAnimal
    {
        protected List<T> animals;
        public IReadOnlyList<T> Animals => animals;
        public int Count => animals.Count;

        public Group() => animals = new List<T>();
        public Group(int capacity) => animals = new List<T>(capacity);
        public Group(params T[] animals) => this.animals = new List<T>(animals);

        public T this[int index]
        {
            get => animals[index];
            set => animals[index] = value;
        }

        public void Add(T animal) => animals.Add(animal);
        public void AddRange(params T[] animals) => this.animals.AddRange(animals);
        public void Remove(T animal) => animals.Remove(animal);
    }
}
