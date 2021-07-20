using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameSystem : IEcsInitSystem
{
    EcsWorld _world;
    private Prefabs _prefabs;
    public void Init()
    {

        var tower = _world.NewEntity();
        ref var towerComponent = ref tower.Get<TowerComponent>();
        towerComponent.TowerModel = Object.Instantiate(_prefabs.CubePrefab, new Vector3(0, -5, 1.5f), Quaternion.identity);
        towerComponent.TowerModel.GetComponent<TowerBehaviour>().Entity = tower;
        var mesh = towerComponent.TowerModel.GetComponent<MeshRenderer>();
        towerComponent.RotationSpeed = 200f;

        var ball = _world.NewEntity();
        ref var ballComponent = ref ball.Get<BallComponent>();
        ballComponent.BallModel = Object.Instantiate(_prefabs.BallPrefab, new Vector3(0,mesh.bounds.size.y/2, 0), Quaternion.identity);
        ballComponent.BallModel.GetComponent<BallBehaviour>().BallEntity = ball;
        ballComponent.Speed = 15f;
        ballComponent.Rigidbody = ballComponent.BallModel.GetComponent<Rigidbody>();

        var score = _world.NewEntity();
        ref var scoreComponent = ref score.Get<ScoreComponent>();
        scoreComponent.BaseScoreValue = 1;
        scoreComponent.CurrentScore = 0;
        scoreComponent.Combo = 0;
        scoreComponent.ScoreModel = Object.Instantiate(_prefabs.ScorePrefab, Vector3.zero, Quaternion.identity);
        scoreComponent.ScoreModel.GetComponent<ScoreBehaviour>().Entity = score;
    }
}
