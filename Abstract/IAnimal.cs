using ZooImitation.Enums;

namespace ZooImitation.Abstract
{
    public interface IAnimal
    {
        int DefaultHealth { get; }
        int CurrentHealth { get; set; }
        State State { get; set; }
        string Name { get; set; }
    }
}