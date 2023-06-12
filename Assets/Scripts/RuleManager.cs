using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class RuleManager : MonoBehaviour
{
    [SerializeField] private List<InputRule> _rules;
    
    public UnityEvent<InputRule, int> OnRuleChange;

    private void Start()
    {
        StartCoroutine(ChooseNewRule());
    }

    private InputRule RandomRule()
    {
        if (_rules.Count == 0)
        {
            Debug.LogError("List of rules is empty!!!");
            return null;
        }

        InputRule rule = _rules[Random.Range(0, _rules.Count - 1)];
        return rule;
    }

    IEnumerator ChooseNewRule()
    {
        int ruleTime;
        InputRule rule;
        
        while (true)
        {
            ruleTime = Random.Range(5, 10);
            rule = RandomRule();
            OnRuleChange?.Invoke(rule, ruleTime);
            yield return new WaitForSeconds(ruleTime);
        }
    }
}
