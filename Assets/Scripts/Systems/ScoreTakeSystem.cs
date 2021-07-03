using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTakeSystem : IEcsRunSystem
{
    private EcsFilter<ScoreComponent, ScoreTakeComponent> _addScoreFilter;
    private EcsFilter<ScoreComponent, ScoreComboComponent> _addComboFilter;
    public void Run()
    {
        foreach(var i in _addScoreFilter)
        {
            ref var scoreComponent = ref _addScoreFilter.Get1(i);

            if (scoreComponent.Combo > 0)
            {
                scoreComponent.CurrentScore += (scoreComponent.BaseScoreValue * (int)Mathf.Pow(scoreComponent.Combo, 2)) ;
                scoreComponent.Combo = 0;
                Debug.Log("CURRENT SCORE: " + scoreComponent.CurrentScore);
            }
        }

        foreach(var i in _addComboFilter)
        {
            ref var scoreComponent = ref _addComboFilter.Get1(i);

            scoreComponent.Combo += 1;
            Debug.Log("current combo: " + scoreComponent.Combo);
        }
    }
}
