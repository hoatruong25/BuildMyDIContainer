using BuildMyDIContainer.DependencyInjection;

namespace BuildMyDIContainer;

class Program
{
    static void Main(string[] args)
    {
        var services = new DiServiceCollection();

        services.RegisterSingleton(new RandomGuidGenerator());

        var container = services.GenerateContainer();

        var service1 = container.GetService<RandomGuidGenerator>();
        var service2 = container.GetService<RandomGuidGenerator>();
        
        Console.WriteLine(service1.Guild);
        Console.WriteLine(service2.Guild);
    }
}

