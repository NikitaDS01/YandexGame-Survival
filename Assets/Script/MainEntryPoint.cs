using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ButtonControl _buttonControl;
    private List<IService> _services;
    private EventBus _eventBus;
    private void Awake()
    {
        _services = new List<IService>();
        _eventBus = new EventBus();

        this.AddService();
        this.Registry();
        this.Init();
        this.EnableEvent();
    }
    private void AddService()
    {
        _services.Add(_eventBus);
        _services.Add(_player);
        _services.Add(_buttonControl);
    }
    private void OnDestroy()
    {
        ServiceLocator.Clear();
        this.DisableEvent();
    }
    private void Registry()
    {
        ServiceLocator.Init();
        ServiceLocator.Singleton.Register(_eventBus);
        ServiceLocator.Singleton.Register(_player);
    }
    private void Init()
    {
        foreach (var item in _services)
            item.Init();
    }
    private void Update()
    {
        foreach (var item in _services)
            item.Update();
    }
    private void EnableEvent()
    {
        var list = _services.OfType<IServiceEvent>();
        foreach(var  item in list)
            item.EnableEvent();
    }
    private void DisableEvent()
    {
        var list = _services.OfType<IServiceEvent>();
        foreach (var item in list)
            item.DisableEvent();
    }
}
