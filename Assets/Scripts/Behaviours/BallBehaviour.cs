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
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (_ballEntity.Has<ArrowComponent>())
            {
                collision.gameObject.GetComponentInChildren<FloorTriggerBehaviour>().SuccessCollision();
                _score.Entity.Get<ScoreComboComponent>();
            }
            else
            {
                _ballEntity.Get<BallCollisionComponent>();
                _score.Entity.Get<ScoreTakeComponent>();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            _score.Entity.Get<ScoreComboComponent>();
            _score.Entity.Get<ScoreTakeComponent>();

            var tower = other.GetComponentInParent<TowerBehaviour>();
            tower.Entity.Del<TowerComponent>();
            _ballEntity.Get<ShowMenuComponent>();

            var rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            _ballEntity.Del<BallComponent>();
            Debug.Log("ENDED");
        }
        else
        {
            _score.Entity.Get<ScoreComboComponent>();
            Debug.Log("triggered");
        }

    }
}
