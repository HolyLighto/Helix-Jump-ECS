using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class ArrowBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            var ball = other.gameObject.GetComponent<BallBehaviour>();
            ball.BallEntity.Get<ArrowComponent>();
            var secondBall = ball.transform.GetChild(0);
            secondBall.gameObject.SetActive(true);
            var mesh = GetComponent<MeshRenderer>();
            mesh.enabled = false;
            Invoke("DeleteComponent", 2f);
        }
    }

    private void DeleteComponent()
    {
        var ball = GameObject.FindGameObjectWithTag("Ball");
        var component = ball.GetComponent<BallBehaviour>();
        ball.transform.GetChild(0).gameObject.SetActive(false);
        component.BallEntity.Del<ArrowComponent>();
        Destroy(gameObject);
    }
}
