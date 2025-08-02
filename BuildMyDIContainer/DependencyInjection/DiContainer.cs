namespace BuildMyDIContainer.DependencyInjection;

public class DiContainer
{
    private List<ServiceDescriptor> _serviceDescriptors;
    public DiContainer(List<ServiceDescriptor> serviceDescriptors)
    {
        _serviceDescriptors = serviceDescriptors;
    }

    private object GetService(Type serviceType)
    {
        var descriptor = _serviceDescriptors.SingleOrDefault(x => x.ServiceType == serviceType);

        if (descriptor == null)
        {
            throw new Exception($"Service of type {serviceType.Name} isn't registered");
        }

        if (descriptor.Implementation != null)
        {
            return descriptor.Implementation;
        }

        var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

        if (actualType.IsAbstract || actualType.IsInterface)
        {
            throw new Exception($"Cannot instantiate abstract class or interface");       
        }
        
        var constructorInfo = actualType.GetConstructors().First();
        var constructorParams = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();

        var implementation = Activator.CreateInstance(actualType, constructorParams);
        
        if (descriptor.Lifetime == ServiceLifetime.Singleton)
        {
            descriptor.Implementation = implementation;
        }
        
        return implementation;
    }

    public T GetService<T>() where T : class
    {
        return (T)GetService(typeof(T));
    }
}