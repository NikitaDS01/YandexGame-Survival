using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ButtonControl : IService
{
    [SerializeField] private Button _buttonLeft;
    [SerializeField] private Button _buttonRight;
    [SerializeField] private Button _buttonAction;
    private EventBus _eventBus;

    public void Init()
    {
        _eventBus = ServiceLocator.Singleton.Get<EventBus>();
        _buttonLeft.onClick.AddListener(ActionLeftPlayer);
        _buttonRight.onClick.AddListener(ActionRightPlayer);
        _buttonAction.onClick.AddListener(ActionPlayer);
    }
    private void ActionLeftPlayer()
    {
        _eventBus.Invoke<PlayerMoveSignal>(new PlayerMoveSignal(1));
    }
    private void ActionRightPlayer()
    {
        _eventBus.Invoke<PlayerMoveSignal>(new PlayerMoveSignal(-1));
    }
    private void ActionPlayer()
    {

    }
}
