using System;
using System.Collections.Generic;
using System.Linq;
using ZooImitation.Abstract;
using ZooImitation.Enums;

namespace ZooImitation
{
    public class AnimalRepository
    {
        private IList<IAnimal> _animalList;

        public AnimalRepository()
        {
            _animalList = new List<IAnimal>();
        }

        public IList<IAnimal> Animals => _animalList;
        public int Count => _animalList.Count();

        /// <summary>
        /// Shows all animals in repositry to the console
        /// </summary>
        public void ShowAnimals()
        {
            Console.WriteLine(new string('-', 86));
            foreach (var animal in _animalList)
            {
                Console.WriteLine($"Type - {animal.GetType().Name},\t Name - {animal.Name},\t" +
                                  $"State - {animal.State},\t CurrentHealth - {animal.CurrentHealth},\t" +
                                  $"Max Health - {animal.DefaultHealth} ");
            }
            Console.WriteLine(new string('-', 86));
        }

        /// <summary>
        /// Adds animal to the repository, and logs information in the console
        /// </summary>
        /// <param name="animal">instance of IAnimal type</param>
        /// <param name="name">animal's name</param>
        public void Add(IAnimal animal, string name)
        {
            animal.Name = name;
            _animalList.Add(animal);
            var message = $"We added {animal.GetType().Name}, and named it {animal.Name}.";
            message.ConsoleWrite();
        }

        /// <summary>
        /// Feeds animal (Ill->Hungry->Full) and logs information in the console
        /// </summary>
        /// <param name="name">animal's name</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Feed(string name)
        {
            var animals = _animalList
                .Where(animal => animal.Name == name);
            var message = "";
            if (animals.Count() == 0)
            {
                message = $"Sorry, there are no animals in zoo with name {name}";
                message.ConsoleWrite();
            }
            foreach (var animal in animals)
            {
                switch (animal.State)
                {
                    case State.Ill:
                        animal.State = State.Hungry;
                        message = $"We fed {animal.GetType().Name} with name - {name} and it has become hungry!";
                        break;
                    case State.Hungry:
                        animal.State = State.Full;
                        message = $"We fed {animal.GetType().Name} with name - {name} and it is full now!";
                        break;
                    case State.Full:
                        message = $"{animal.GetType().Name} with name - {name} is full!";
                        break;
                    case State.Dead:
                        message = $"We fed {animal.GetType().Name} with name - {name} is dead!";
                        break;
                    default:
                        throw new NotImplementedException();
                }
                message.ConsoleWrite();
            }
        }

        /// <summary>
        /// Cures animal/animals with specified name/names and logs information in the console
        /// </summary>
        /// <param name="name">animal's name</param>
        public void Cure(string name)
        {
            var animals = _animalList.Where(animal => animal.Name == name);
            var message = "";
            if (animals.Count() == 0)
            {
                message = $"Sorry, there are no animals in zoo with name {name}";
                message.ConsoleWrite();
            }
            foreach (var animal in animals)
            {
                if (animal.CurrentHealth < animal.DefaultHealth)
                {
                    animal.CurrentHealth += 1;
                    message = $"Animal ({animal.GetType().Name}) {name} healed.";
                }
                else
                {
                    message = $"Animal {name} ({animal.GetType().Name}) has full health!";
                }
                message.ConsoleWrite();
            }
        }

        /// <summary>
        /// Kiks animals, which has dead state
        /// </summary>
        public void Kick()
        {
            var deadAnimals = _animalList.Select(animal => animal)
                .Where(animal => animal.State == State.Dead);
            var message = "";
            if (deadAnimals.Count() >= 1)
            {
                _animalList = _animalList.Except(deadAnimals).ToList();
                message = $"There are {deadAnimals.Count()} dead animals. We kicked them.";
                message.ConsoleWrite();
            }
            else
            {
                message = "Good news. There are no dead animals in the zoo.";
                message.ConsoleWrite();
            }
        }

        #region LINQ Methods

        /// <summary>
        /// Shows all animals by groups
        /// </summary>
        public void ShowAllAnimalsGroupedByType()
        {
            var queryResult = _animalList.GroupBy(a => a.GetType().Name)
                .Select(a => new
                {
                    AnimalType = a.Key,
                    Animals = a.Select(s => s)
                });
            foreach (var animal in queryResult)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{animal.AnimalType}");
                foreach (var group in animal.Animals)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{group.Name}");
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        /// <summary>
        /// Shows all animals with entered State
        /// </summary>
        /// <param name="state"></param>
        public void ShowAnimalsByState(State state)
        {
            var animalsQuery = _animalList.Where(animal => animal.State == state).ToList();
            animalsQuery.ShowQueryResult($"No animals whith state - {state}");
        }

        /// <summary>
        /// Shows ill tigers in the zoo
        /// </summary>
        public void ShowIllTigers()
        {
            var animalsQuery = _animalList.Where(animal => animal.State == State.Ill)
                  .Where(animal => animal.GetType().Name == "Tiger")
                  .ToList();
            animalsQuery.ShowQueryResult("There are no ill tigers!");
        }

        /// <summary>
        /// Shows elephants by their names
        /// </summary>
        /// <param name="name">elephant's name</param>
        public void ShowElephantByName(string name)
        {
            var animalsQuery = _animalList.Where(animal => animal.GetType().Name == "Elephant")
                .Where(animal => animal.Name == name)
                .ToList();
            animalsQuery.ShowQueryResult($"There are no elephants with name {name}");
        }

        /// <summary>
        /// Shows all names of hungry animals
        /// </summary>
        public void ShowNamesOfHungryAnimals()
        {
            var animalsQuery = _animalList.Where(animal => animal.State == State.Hungry)
                .Select(animal => animal.Name)
                .ToList();
            if (animalsQuery.Count > 0)
            {
                foreach (var name in animalsQuery)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(name);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("There are no hungry animals in the zoo!");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        /// <summary>
        /// Shows the healthiest animals by their type
        /// </summary>
        public void ShowTheHealthiestAnimalsByType()
        {
            var animalsQuery = _animalList.OrderByDescending(animal=>animal.CurrentHealth)
                .GroupBy(animal => animal.GetType().Name)
                .Select(a => new
                {
                    AnimalType = a.Key,
                    Animals = a.Select(animal => animal)
                });
            foreach (var animal in animalsQuery)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(animal.AnimalType);
                foreach (var group in animal.Animals)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{group.Name} + {group.CurrentHealth}/{group.DefaultHealth}");
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        /// <summary>
        /// Shows wolfs and bears with health more than 3
        /// </summary>
        public void ShowWolfsAndBearsWhereHealthMoreThan3()
        {
            var animalsQuery = _animalList.Where(animal => animal.CurrentHealth > 3)
                .Where(animal => animal.GetType().Name == "Wolf" || animal.GetType().Name == "Bear")
                .ToList();
            animalsQuery.ShowQueryResult("There are no wolfs and bears with health more than 3");
        }

        //public void ShowMaxMinHealthAnimal()
        //{
            
        //}

       /// <summary>
       /// Shows average health of all animals in the zoo
       /// </summary>
        public void ShowAverageHealth()
        {
            var average = _animalList.Average(a => a.CurrentHealth);
            Console.WriteLine($"Average health of all animals - {average}");
        }

        #endregion
    }
}