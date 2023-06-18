using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputRule _currentRule;

    private string _input;
    private int _score;

    public UnityEvent<int> OnScoreChanged;
    public UnityEvent OnLanguageSwap;

    private void Update()
    {
        if (LanguageCheck)
            InputUpdate();
        else
            OnLanguageSwap?.Invoke();
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

    private bool LanguageCheck => Application.systemLanguage == SystemLanguage.Russian;

    public void SetRule(InputRule rule, int ruleTime)
    {
        _currentRule = rule;
    }
}
