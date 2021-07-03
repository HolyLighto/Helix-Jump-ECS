using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjects : MonoBehaviour
{
    public BallBehaviour Ball;
    public TowerBehaviour Tower;
    public ScoreBehaviour Score;
    public GameObject UiPanel;
    void Start()
    {
        Ball = GameObject.FindObjectOfType<BallBehaviour>();
        Tower = GameObject.FindObjectOfType<TowerBehaviour>();
        Score = GameObject.FindObjectOfType<ScoreBehaviour>();
    }
}
