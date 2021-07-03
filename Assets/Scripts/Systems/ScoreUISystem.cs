using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUISystem : IEcsRunSystem, IEcsInitSystem
{
    private EcsFilter<ScoreComponent, ScoreTakeComponent> _filter;
    private ScoreUIBehaviour _score;
    
    public void Init()
    {
        _score = GameObject.FindObjectOfType<ScoreUIBehaviour>();
    }
    public void Run()
    {
        foreach(var i in _filter)
        {
            ref var scoreComponent = ref _filter.Get1(i);

            _score.ChangeText(scoreComponent.CurrentScore);
        }
    }
}
