namespace server.abstracts
{
    internal interface IDataGenerator
    {
        IEnumerable<string> Generate(int maxChar, int delay);
        IEnumerable<string> Generate(int maxChar, int delay,int count);
    }
}
