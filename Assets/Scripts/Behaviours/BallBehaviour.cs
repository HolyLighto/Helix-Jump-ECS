using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private EcsEntity _ballEntity;
    private ScoreBehaviour _score;
    public EcsEntity BallEntity
    {
        get => _ballEntity;
        set => _ballEntity = value;
    }

    private void Start()
    {
        _score = FindObjectOfType<ScoreBehaviour>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _ballEntity.Get<BallCollisionComponent>();
        _score.Entity.Get<ScoreTakeComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _score.Entity.Get<ScoreComboComponent>();
        Debug.Log("triggered");

    }
}
