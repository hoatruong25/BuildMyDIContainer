using BuildMyDIContainer.DependencyInjection;
using BuildMyDIContainer.Impl;

namespace BuildMyDIContainer;

class Program
{
    static void Main(string[] args)
    {
        var services = new DiServiceCollection();

        RandomGuidGenerator? test = null;
        
        services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();
        services.RegisterTransient<ISomeService, SomeServiceOne>();
        
        var container = services.GenerateContainer();

        var service1 = container.GetService<ISomeService>();
        var service2 = container.GetService<ISomeService>();
        
        service1.Print();
        service2.Print();
    }
}

