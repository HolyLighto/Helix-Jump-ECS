using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravitySystem : IEcsRunSystem
{
    private EcsFilter<BallComponent> _filter;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref var ballComponent = ref _filter.Get1(i);

            ballComponent.Rigidbody.AddForce(Vector3.down * 60, ForceMode.Acceleration);
        }
    }
}
