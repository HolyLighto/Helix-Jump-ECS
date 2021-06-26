using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJumpSystem : IEcsRunSystem
{
    EcsFilter<BallComponent, BallCollisionComponent> _filter;
    public void Run()
    {
        foreach(var i in _filter)
        {
            ref var ballComponent = ref _filter.Get1(i);
            ref var ballCollisionComponent = ref _filter.Get2(i);

            var ballRb = ballComponent.BallModel.GetComponent<Rigidbody>();
            ballRb.AddForce(Vector3.up * ballComponent.Speed, ForceMode.Impulse);
        }
    }
}
