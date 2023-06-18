using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    private Label _label;
    
    private int _score;
    private int _maxScore;

    private void Start()
    {
        _label = GetComponent<UIDocument>().rootVisualElement.Q<Label>("Score");
    }

    public void OnScoreChanged(int amount)
    {
        if (amount <= 0) return;
        
        _score += amount;
        _score = Mathf.Clamp(_score, 0, _maxScore);
        SetValue();
    }

    public void SetMaxScore(TextPrefab prefab)
    {
        _maxScore = prefab.Text.Length;
        _label.text = "0/" + _maxScore.ToString();
    }

    private void SetValue()
    {
        _label.text = _score.ToString() + "/" + _maxScore.ToString();
    }
}
