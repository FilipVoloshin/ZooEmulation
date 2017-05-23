using ZooImitation.Abstract;
using ZooImitation.Enums;

namespace ZooImitation.AnimalTypes
{
    public sealed class Fox : IAnimal
    {
        public Fox()
        {
            DefaultHealth = 3;
            CurrentHealth = 3;
            State = State.Full;
        }

        public int DefaultHealth { get; }
        public int CurrentHealth { get; set; }
        public State State { get; set; }
        public string Name { get; set; }
    }
}