using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIBehaviour : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI _text;
    private float _currentScore;

    void Update()
    {
        _text.text = "Score: " + _currentScore;
    }

    public void ChangeText(float value)
    {
        _currentScore = value;
    }
}
