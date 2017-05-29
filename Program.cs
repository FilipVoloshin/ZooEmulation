using System;
using System.Threading;
using ZooImitation.Animals;
using ZooImitation.Enums;

namespace ZooImitation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            #region Animals hardcode create
            var animals = new AnimalRepository();
            animals.Add(new Lion(), "Leva");
            animals.Add(new Fox(), "Kolobok");
            animals.Add(new Wolf(), "Bobik");
            animals.Add(new Tiger(), "Sharhan");
            animals.Add(new Tiger(), "Polosatik");
            animals.Add(new Elephant(), "Vuhatiy");
            Thread.Sleep(1000);
            #endregion

            var zoo = new Zoo(animals, 5);

            while (animals.Count != 0)
            {
                Console.WriteLine(new string('*', 22));
                Console.WriteLine("Choose action:\n1. Add animal \n2. Feed animal\n" +
                    "3. Cure animal \n4. Remove dead animals\n5. Show all animals in zoo\n" +
                    "6. LINQ operations");
                Console.WriteLine(new string('*', 22));
                try
                {
                    var variant = Convert.ToInt32(Console.ReadLine());
                    switch (variant)
                    {
                        case 1:
                            Console.WriteLine($"Choose animal\'s type:\n " +
                                $"1.Bear\n 2.Elephant\n 3.Fox\n 4.Lion\n 5.Tiger\n 6.Wolf");
                            int animalType = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter pets name:\t");
                            var name = Console.ReadLine();
                            switch (animalType)
                            {
                                case 1:
                                    animals.Add(new Bear(), name);
                                    break;
                                case 2:
                                    animals.Add(new Elephant(), name);
                                    break;
                                case 3:
                                    animals.Add(new Fox(), name);
                                    break;
                                case 4:
                                    animals.Add(new Lion(), name);
                                    break;
                                case 5:
                                    animals.Add(new Tiger(), name);
                                    break;
                                case 6:
                                    animals.Add(new Wolf(), name);
                                    break;
                                default:
                                    throw new ArgumentException("Unknown operation");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter animal\'s name which you want to feed:");
                            name = Console.ReadLine();
                            animals.Feed(name);
                            break;
                        case 3:
                            Console.WriteLine("Enter animal\'s name which you want to cure:");
                            name = Console.ReadLine();
                            animals.Cure(name);
                            break;
                        case 4:
                            animals.Kick();
                            break;
                        case 5:
                            animals.ShowAnimals();
                            break;
                        case 6: // Linq Operations
                            {
                                Console.WriteLine("Choose operation:\n1. Show all animals by their groups" +
                                    "\n2. Show animals by state:\n3. Show all ill tigers" +
                                    "\n4. Show animals with entered name\n5. Show names of hungry animals\n" +
                                    "6. Show the helthiest animals of each type\n" +
                                    "7. Show count of dead animals by their group\n" +
                                    "8. Show wolfs and bears with health more than 3\n" +
                                    "9. Show max health animal and min health animal\n" +
                                    "10. Show average health of all animals in the zoo");
                                int linqSwitchOperator = Convert.ToInt32(Console.ReadLine());
                                switch (linqSwitchOperator)
                                {
                                    case 1:
                                        {
                                            animals.ShowAllAnimalsGroupedByType();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Choose state: \n1. Full\n2. Hungry\n3. Ill");
                                            int state = Convert.ToInt32(Console.ReadLine());
                                            switch (state)
                                            {
                                                case 1:
                                                    animals.ShowAnimalsByState(State.Full);
                                                    break;
                                                case 2:
                                                    animals.ShowAnimalsByState(State.Hungry);
                                                    break;
                                                case 3:
                                                    animals.ShowAnimalsByState(State.Ill);
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            animals.ShowIllTigers();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Enter elephant\'s name:");
                                            string elephantName = Console.ReadLine();
                                            animals.ShowElephantByName(elephantName);
                                            break;
                                        }
                                    case 5:
                                        {
                                            animals.ShowNamesOfHungryAnimals();
                                            break;
                                        }
                                    case 6:
                                        {
                                            animals.ShowTheHealthiestAnimalsByType();
                                            break;
                                        }
                                    case 7:
                                        {
                                            animals.ShowCountOfDeadAnimals();
                                            break;
                                        }
                                    case 8:
                                        {
                                            animals.ShowWolfsAndBearsWhereHealthMoreThan3();
                                            break;
                                        }
                                    case 9:
                                        {
                                            animals.ShowMaxAndMin();
                                            break;
                                        }
                                    case 10:
                                        {
                                            animals.ShowAverageHealth();
                                            break;
                                        }
                                }
                                break;
                            }
                        default:
                            break;
                    }
                    if (animals.Count == 0)
                    {
                        Console.WriteLine("\n\n****All animals are dead!****");
                    }
                }
                catch(Exception e)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(e.Message);            
                }
                finally
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
    }
}

