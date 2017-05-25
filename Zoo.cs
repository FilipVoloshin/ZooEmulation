using System;
using System.Threading;
using ZooImitation.Enums;

namespace ZooImitation
{
    class Zoo
    {
        private AnimalRepository _animals;
        private Timer _timer;
        public Zoo(AnimalRepository animals,int timerSeconds)
        {
            _animals = animals;
            _timer = new Timer(e => StartSimulation(), null, TimeSpan.Zero, TimeSpan.FromSeconds(timerSeconds));
        }

        private int GetRandomNumber()
        {
            var random = new Random();
            var animalsCount = _animals.Count;
            int randomValue;
            if (animalsCount > 0)
            {
                randomValue = random.Next(0, animalsCount);
                return randomValue;
            }
            else
                throw new ApplicationException("All animals are dead!");
        }

        private void StartSimulation()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            try
            {
                var randomNumber = GetRandomNumber();
                var randomAnimal = _animals.Animals[randomNumber];
                var message = "";
                switch (randomAnimal.State)
                {
                    case State.Full:
                        randomAnimal.State = State.Hungry;
                        message = $"{randomAnimal.GetType().Name} with name - {randomAnimal.Name} " +
                            $"became hungry!";
                        break;
                    case State.Hungry:
                        randomAnimal.State = State.Ill;
                        message = $"{randomAnimal.GetType().Name} with name - {randomAnimal.Name} " +
                            $"became ill!";
                        break;
                    case State.Ill:
                        if (randomAnimal.CurrentHealth > 0)
                        {
                            randomAnimal.CurrentHealth -= 1;
                            message = $"{randomAnimal.GetType().Name} with name - {randomAnimal.Name} " +
                                $"is ill and it loses one health point!";
                        }
                        else if (randomAnimal.CurrentHealth == 0)
                        {
                            randomAnimal.State = State.Dead;
                            _animals.Kick();
                        }
                        break;
                    case State.Dead:
                        _animals.Kick();
                        break;
                }
                message.ConsoleWrite();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
    }
}

