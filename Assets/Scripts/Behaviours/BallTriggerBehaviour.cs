using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTriggerBehaviour : MonoBehaviour
{
    private ScoreBehaviour _score;
    void Start()
    {
        _score = FindObjectOfType<ScoreBehaviour>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {

        }
    }
}
