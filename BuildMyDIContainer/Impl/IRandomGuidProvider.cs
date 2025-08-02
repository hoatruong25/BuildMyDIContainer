namespace BuildMyDIContainer.Impl;

public interface IRandomGuidProvider
{
    Guid RandomGuid { get; set; }
}

public class RandomGuidProvider : IRandomGuidProvider
{
    public Guid RandomGuid { get; set; } = Guid.NewGuid();
}