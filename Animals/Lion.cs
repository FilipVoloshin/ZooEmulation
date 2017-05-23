using ZooImitation.Abstract;
using ZooImitation.Enums;

namespace ZooImitation.AnimalTypes
{
    public sealed class Lion : IAnimal
    {
        public Lion()
        {
            DefaultHealth = 5;
            CurrentHealth = 5;
            State = State.Full;
        }

        public int DefaultHealth { get; }
        public int CurrentHealth { get; set; }
        public State State { get; set; }
        public string Name { get; set; }
    }
}