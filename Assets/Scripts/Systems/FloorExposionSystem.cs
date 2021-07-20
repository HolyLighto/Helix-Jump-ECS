using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorExposionSystem : IEcsRunSystem
{
    private EcsFilter<FloorExposionComponent> _filter;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref var floorExplosionComponent = ref _filter.Get1(i);

            var rb = floorExplosionComponent.Floor.GetComponent<Rigidbody>();
            var collider = floorExplosionComponent.Floor.GetComponentInParent<MeshCollider>();
            rb.isKinematic = false;
            collider.enabled = false;

            rb.AddForceAtPosition(new Vector3(Random.Range(0.1f, 1), 1, Random.Range(0.1f,1)) * floorExplosionComponent.ExplosionForce, floorExplosionComponent.ExplosionPosition);
            floorExplosionComponent.Floor.transform.parent = null;
            GameObject.Destroy(floorExplosionComponent.Floor, 3f);
        }
    }
}
