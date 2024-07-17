using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSignal
{
    private float _value;
    public PlayerMoveSignal(float value)
    {
        _value = value;
    }
    public float Value => _value;
}
