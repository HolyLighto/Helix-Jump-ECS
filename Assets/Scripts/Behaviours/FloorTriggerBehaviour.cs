using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class FloorTriggerBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            SuccessCollision();
        }
    }

    public void SuccessCollision()
    {
        //Debug.Log("SUCCESS");
        var tower = GetComponentInParent<TowerBehaviour>();
        ref var component = ref tower.Entity.Get<FloorExposionComponent>();
        component.Floor = transform.parent.gameObject;
        var position = GameObject.Find("ExplosionPosition").transform.position;
        component.ExplosionPosition = new Vector3(Random.Range(-0.5f, 0.5f), position.y, Random.Range(-4f, 0));
        var mesh = GetComponent<MeshRenderer>();
        component.ExplosionForce = 500f;
        GetComponent<BoxCollider>().enabled = false;

        Debug.Log(component.Floor.name);
    }
}
