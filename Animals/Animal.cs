using ZooImitation.Abstract;
using ZooImitation.Enums;

namespace ZooImitation.Animals
{
    public class Animal : IAnimal
    {
        public int DefaultHealth { get; set; }
        public int CurrentHealth { get; set; }
        public State State { get; set; } = State.Full;
        public string Name { get; set; }
    }
}
