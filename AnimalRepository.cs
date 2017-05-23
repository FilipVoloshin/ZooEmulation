using System;
using System.Collections.Generic;
using System.Linq;
using ZooImitation.Abstract;
using ZooImitation.Enums;

namespace ZooImitation
{
    public class AnimalRepository : IAnimalRepository
    {
        private IList<IAnimal> _animalList;

        public AnimalRepository()
        {
            _animalList = new List<IAnimal>();
        }

        public IList<IAnimal> GetAnimalsList => _animalList;
        public int Count => _animalList.Count();

        /// <summary>
        /// Adds animal to the repository
        /// </summary>
        /// <param name="animal">instance of IAnimal type</param>
        /// <param name="name">animal's name</param>
        public void Add(IAnimal animal, string name)
        {
            animal.Name = name;
            _animalList.Add(animal);
            Console.WriteLine($"We added {animal.GetType().Name}, and named it {animal.Name}.");
        }

        /// <summary>
        /// Feeds animal (Ill->Hungry->Full)
        /// </summary>
        /// <param name="name">animal's name</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Feed(string name)
        {
            var animals = _animalList
                .Where(animal => animal.Name == name);
            foreach (var animal in animals)
            {
                switch (animal.State)
                {
                    case State.Ill:
                        animal.State = State.Hungry;
                        Console.WriteLine($"We fed {name} and it has become hungry!");
                        break;
                    case State.Hungry:
                        animal.State = State.Full;
                        Console.WriteLine($"We fed {name} and it is full now!");
                        break;
                    case State.Full:
                        Console.WriteLine($"{name} is full!");
                        break;
                    case State.Dead:
                        Console.WriteLine($"{name} is dead!");
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Cures animal/animals with specified name
        /// </summary>
        /// <param name="name">animal's name</param>
        public void Cure(string name)
        {
            var animals = _animalList.Where(animal => animal.Name == name);
            foreach (var animal in animals)
            {
                if (animal.CurrentHealth < animal.DefaultHealth)
                {
                    animal.CurrentHealth += 1;
                    Console.WriteLine(animals.Count() > 1
                        ? $"{animals.Count()} animals named {name} healed."
                        : $"Animal {name} healed.");
                }
                else
                    Console.WriteLine(animals.Count() > 1
                        ? $"Animals named \"{name}\" ({animal.GetType().Name}) have full health!"
                        : $"Animal {name} ({animal.GetType().Name}) has full health!");
            }
        }

        /// <summary>
        /// Kiks animals, which has dead state
        /// </summary>
        public void Kick()
        {
            var deadAnimals = _animalList.Select(animal => animal)
                .Where(animal => animal.State == State.Dead);
            if (deadAnimals.Count() >= 1)
            {
                _animalList = _animalList.Except(deadAnimals).ToList();
                Console.WriteLine($"There are {deadAnimals.Count()} dead animals. We kicked them");
            }
            else
                Console.WriteLine($"Good news. There are no dead animals in the zoo.");
        }
    }
}