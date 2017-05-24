using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooImitation.AnimalTypes;

namespace ZooImitation
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalRepository animalRepo = new AnimalRepository();
            animalRepo.Add(new Bear(), "Filip");
            animalRepo.Add(new Elephant(), "Larisa");
            animalRepo.Add(new Fox(), "Larisa");
            animalRepo.Add(new Lion(), "Filip");
            animalRepo.Add(new Wolf(), "Filip");
            animalRepo.Add(new Tiger(), "Filip");
            animalRepo.Cure("Filip");
            animalRepo.Feed("Filip");

            animalRepo.Animals[3].CurrentHealth = 2;
            animalRepo.Animals[4].CurrentHealth = 1;
            animalRepo.Animals[5].CurrentHealth = 3;

            animalRepo.ShowAnimals();

            animalRepo.Cure("Filip");

            animalRepo.ShowAnimals();

            Console.ReadLine();
        }
    }
}
