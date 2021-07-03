using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenuSystem : IEcsRunSystem
{
    private SceneObjects _sceneObjects;
    private EcsFilter<ShowMenuComponent> _filter;
    public void Run()
    {
        foreach(var i in _filter)
        {
            _sceneObjects.UiPanel.SetActive(true);
        }
    }
}
