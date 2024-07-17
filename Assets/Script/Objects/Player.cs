using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player : IService, IServiceEvent
{
    [SerializeField] private GameObject _objectObject;
    [SerializeField, Min(0)] private float _speed;
    private Transform _transformPlayer;

    private EventBus _eventBus;

    public void Init()
    {
        _eventBus = ServiceLocator.Singleton.Get<EventBus>();
        _transformPlayer = _objectObject.GetComponent<Transform>();
    }

    public void DisableEvent()
    {
        _eventBus.Unsubcribe<PlayerMoveSignal>(MovePlayer);
    }

    public void EnableEvent()
    {
        _eventBus.Subscribe<PlayerMoveSignal>(MovePlayer);
    }
    public void MovePlayer(PlayerMoveSignal signal)
    {
        Vector2 target = new Vector2(signal.Value, 
                                     _transformPlayer.position.y);
        _transformPlayer.position = Vector2.MoveTowards(_transformPlayer.position,
                                                        target,
                                                        _speed * Time.deltaTime);
    }
}
