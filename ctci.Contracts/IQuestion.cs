namespace ctci.Contracts
{
    public abstract class Question
    {
        abstract public void Run();

        public string Name => GetType().ToString();
    }
}