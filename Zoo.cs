using System;
using System.Threading;
using ZooImitation.Enums;

namespace ZooImitation
{
    class ZooIsEmptyException : Exception
    {
        public ZooIsEmptyException()
        {

        }
        public ZooIsEmptyException(string message)
            : base(message)
        {

        }
    }

    class Zoo
    {
        private AnimalRepository _animals;
        private Timer _timer;
        public Zoo(AnimalRepository animals, int timerSeconds)
        {
            _animals = animals;
            _timer = new Timer(e => StartSimulation(), null, TimeSpan.Zero, TimeSpan.FromSeconds(timerSeconds));
        }

        /// <summary>
        /// Gets a random number between zero and animals count
        /// </summary>
        /// <returns>random number</returns>
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
                throw new ZooIsEmptyException("All animals are dead!");
        }

        /// <summary>
        /// Starts simulation of the zoo
        /// </summary>
        private void StartSimulation()
        {
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
            catch (ZooIsEmptyException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
    }
}

