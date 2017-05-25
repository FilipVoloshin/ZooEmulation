using ZooImitation.Abstract;
using ZooImitation.Enums;

namespace ZooImitation.AnimalTypes
{
    public sealed class Bear : IAnimal
    {
        public Bear()
        {
            DefaultHealth = 6;
            CurrentHealth = 6;
            State = State.Full;
        }

        public int DefaultHealth { get; }
        public int CurrentHealth { get; set; }
        public State State { get; set; }
        public string Name { get; set; }
    }
}