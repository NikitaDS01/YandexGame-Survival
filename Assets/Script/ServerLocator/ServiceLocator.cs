using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    private readonly Dictionary<System.Type, IService> _services;
    public ServiceLocator()
    {
        _services = new Dictionary<System.Type, IService>();
    }

    private static ServiceLocator _current = null;
    public static ServiceLocator Singleton => _current;
    public static void Init()
    {
        if( _current == null )
            _current = new ServiceLocator();
    }
    public static void Clear()
    {
        ServiceLocator.Singleton._services.Clear();
    }
    public T Get<T>() where T : IService
    {
        var type = typeof(T);
        if (this.ContainType<T>())
            return (T)_services[type];

        Debug.LogError($"���� {type.Name} �� ����������");
        throw new System.Exception();
    }
    public void Register<T>(T service) where T : IService
    {
        var type = typeof(T);
        if (this.ContainType<T>())
            Debug.LogError($"���� {type.Name} ����������");
        _services.Add(type, service);
    }
    public void Unregister<T>() where T : IService
    {
        var type = typeof(T);
        if (!this.ContainType<T>())
            Debug.LogError($"���� {type.Name} �� ����������");
        _services.Remove(type);        
    }
    public bool ContainType<T>()
    {
        return _services.ContainsKey(typeof(T));
    }
}
