using System.Xml.Linq;

namespace IocContainer;

public class IocContainer
{
    private readonly Dictionary<string, Type> _typeRegistry = new();
    private readonly Dictionary<string, List<(string Name, string Ref)>> _dependencyRegistry = new();
    private readonly Dictionary<string, object> _instanceRegistry = new();

    public void LoadConfig(string configFile)
    {
        var configPath = "../../../" + configFile;
        var config = XDocument.Load(configPath);

        foreach (var component in config.Root.Elements("component"))
        {
            var id = component.Attribute("id").Value;
            var type = component.Attribute("type").Value;
            
            _typeRegistry[id] = Type.GetType(type);
            
            var dependencies = new List<(string Name, string Ref)>();
            foreach (var dependency in component.Elements("dependency"))
            {
                var name = dependency.Attribute("name").Value;
                var reference = dependency.Attribute("ref").Value;
                dependencies.Add((name, reference));
            }

            _dependencyRegistry[id] = dependencies;
        }
    }

    public T Resolve<T>(string id)
    {
        if (_instanceRegistry.ContainsKey(id))
        {
            return (T)_instanceRegistry[id];
        }
        
        if (!_typeRegistry.ContainsKey(id))
        {
            throw new InvalidOperationException($"Component with ID {id} is not registered in the IOC Container");
        }

        var type = _typeRegistry[id];
        var constructor = type.GetConstructors()[0];
        var constructorParams = constructor.GetParameters();

        var dependencies = new List<object>();

        foreach (var param in constructorParams)
        {
            var dependency = _dependencyRegistry[id].Find(d => d.Name == param.Name);
            if (dependency.Equals(default))
                throw new InvalidOperationException($"Dependency {param.Name} is not configured for {id} in the IOC Container");
            dependencies.Add(Resolve<object>(dependency.Ref));
        }

        var instance = Activator.CreateInstance(type, dependencies.ToArray());
        _instanceRegistry[id] = instance;
        return (T)instance;
    }
}