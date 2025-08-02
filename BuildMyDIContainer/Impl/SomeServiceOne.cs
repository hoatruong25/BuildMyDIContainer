namespace BuildMyDIContainer.Impl;

public class SomeServiceOne : ISomeService
{
    // private readonly Guid _guid = Guid.NewGuid();
    private readonly IRandomGuidProvider _randomGuidProvider;

    public SomeServiceOne(IRandomGuidProvider randomGuidProvider)
    {
        _randomGuidProvider = randomGuidProvider;
    }
    
    public void Print()
    {
        Console.WriteLine(_randomGuidProvider.RandomGuid);
    }
}