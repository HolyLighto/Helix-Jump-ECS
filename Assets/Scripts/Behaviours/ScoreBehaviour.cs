using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class ScoreBehaviour : MonoBehaviour
{
    private EcsEntity _entity;
    public EcsEntity Entity
    {
        get => _entity;
        set => _entity = value;
    }
}
