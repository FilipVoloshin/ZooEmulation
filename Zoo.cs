using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooImitation.Abstract;

namespace ZooImitation
{
    class Zoo
    {
        private IAnimalRepository _animals;
        public Zoo(IAnimalRepository animals)
        {
            _animals = animals;
        }

        public int GetRandomNumber()
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
    }
}
