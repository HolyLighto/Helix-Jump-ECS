using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class FloorBehaviour : MonoBehaviour
{
    private ScoreBehaviour _score;
    private void Start()
    {
        _score = FindObjectOfType<ScoreBehaviour>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            GetComponentInChildren<FloorTriggerBehaviour>().SuccessCollision();
            _score.Entity.Get<ScoreComboComponent>();
            Debug.Log("NICEE");
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ball"))
    //    {
    //        GetComponentInChildren<FloorTriggerBehaviour>().SuccessCollision();
    //        _score.Entity.Get<ScoreComboComponent>();
    //        Debug.Log("NICEE");
    //    }
    //}
}
