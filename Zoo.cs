using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooImitation.Abstract;
using ZooImitation.Enums;

namespace ZooImitation
{
    class Zoo
    {
        private AnimalRepository _animals;

        public Zoo(AnimalRepository animals)
        {
            _animals = animals;
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
                throw new ArgumentNullException("Zero animals count!", "There are no animals in Zoo!");
        }

        public void StartSimulation()
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
    }
}
