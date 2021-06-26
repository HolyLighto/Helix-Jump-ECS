using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTowerSystem : IEcsRunSystem
{
    private EcsFilter<TowerComponent, DragTowerComponent> _filter;
    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var towerComponent = ref _filter.Get1(i);
            towerComponent.TowerModel.transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * towerComponent.RotationSpeed, 0);
        }
    }
}
