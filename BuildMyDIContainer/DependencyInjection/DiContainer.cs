namespace BuildMyDIContainer.DependencyInjection;

public class DiContainer
{
    private List<ServiceDescriptor> _serviceDescriptors;
    public DiContainer(List<ServiceDescriptor> serviceDescriptors)
    {
        _serviceDescriptors = serviceDescriptors;
    }
    public T GetService<T>() where T : class
    {
        var descriptor = _serviceDescriptors.SingleOrDefault(x => x.ServiceType == typeof(T));

        if (descriptor == null)
        {
            throw new Exception($"Service of type {typeof(T).Name} isn't registered");
        }

        var result = descriptor.Implementation as T;

        if (result == null)
        {
            throw new Exception($"Implement of {typeof(T).Name} is null");       
        }

        return result;
    }
}