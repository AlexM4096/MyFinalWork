using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputRule _currentRule;

    private string _input;
    private int _score;

    public UnityEvent<int> OnScoreChanged;
    
    private void Update()
    {
        InputUpdate();
    }

    private void InputUpdate()
    {
        _input = Input.inputString;
        if (_input != string.Empty && Input.anyKeyDown)
        {
            _score = RuleCheck();
            OnScoreChanged?.Invoke(_score);
        }
    }

    private int RuleCheck()
    {
        int amount = 0;
        
        foreach (char ch in _input)
        {
            if (_currentRule.RuleString.Contains(ch))
            {
                amount++;
            }
            else
            {
                amount--;
            }
        }

        return amount;
    }

    public void SetRule(InputRule rule, int ruleTime)
    {
        _currentRule = rule;
    }
}
