using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    private EcsEntity _entity;
    public EcsEntity Entity
    {
        get => _entity;
        set => _entity = value;
    }

}
