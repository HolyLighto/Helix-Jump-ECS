using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    private EcsFilter<TowerComponent> _filter;
    private SceneObjects _sceneObjects;
    public void Run()
    {
        foreach (var i in _filter)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _sceneObjects.Tower.Entity.Get<DragTowerComponent>();
            }

            if (Input.GetMouseButtonUp(0))
            {
                _sceneObjects.Tower.Entity.Del<DragTowerComponent>();
            }
        }
    }
}
