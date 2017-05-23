using ZooImitation.Abstract;
using ZooImitation.Enums;

namespace ZooImitation.AnimalTypes
{
    public sealed class Tiger : IAnimal
    {
        public Tiger()
        {
            DefaultHealth = 4;
            CurrentHealth = 4;
            State = State.Full;
        }

        public int DefaultHealth { get; }
        public int CurrentHealth { get; set; }
        public State State { get; set; }
        public string Name { get; set; }
    }
}