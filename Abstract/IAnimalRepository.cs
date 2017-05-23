namespace ZooImitation.Abstract
{
    public interface IAnimalRepository
    {
        void Add(IAnimal animal, string name);
        void Feed(string name);
        void Cure(string name);
        void Kick();
        int Count { get; }
    }
}