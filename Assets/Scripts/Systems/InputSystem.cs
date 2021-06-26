using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    GameObject _tower;
    public void Run()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var a = GameObject.FindObjectOfType<TowerBehaviour>();
            a.Entity.Get<DragTowerComponent>();
        }

        if(Input.GetMouseButtonUp(0))
        {
            var a = GameObject.FindObjectOfType<TowerBehaviour>();
            a.Entity.Del<DragTowerComponent>();
        }
    }
}
