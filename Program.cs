using System;
using System.Threading;
using ZooImitation.AnimalTypes;

namespace ZooImitation
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Animals hardcode create
            var animals = new AnimalRepository();
            var zoo = new Zoo(animals);

            animals.Add(new Fox(), "Foxxy");
            animals.Add(new Lion(), "Symba");
            animals.Add(new Tiger(), "Sharhan");

            #endregion

            try
            {
                do
                {
                    Console.WriteLine(new string('*', 22));
                    Console.WriteLine("Choose action:\n1. Add animal \n2. Feed animal\n" +
                        "3. Cure animal \n4. Remove dead animals\n5. Show all animals in zoo\n");
                    Console.WriteLine(new string('*', 22));

                    int variant = Convert.ToInt32(Console.ReadLine());

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
                                    Console.WriteLine("Unknown type of animal!");
                                    break;
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
                    }
                    if(animals.Count == 0)
                    {
                        Console.WriteLine("\n\n****All animals are dead!****");
                    }
                }
                while (animals.Count > 0);  
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
