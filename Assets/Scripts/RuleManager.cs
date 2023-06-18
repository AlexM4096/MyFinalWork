using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class RuleManager : MonoBehaviour
{
    [SerializeField] private List<InputRule> _rules;
    
    public UnityEvent<InputRule, int> OnRuleChange;

    private void Start()
    {
        _rules = Resources.LoadAll<InputRule>("InputRules").ToList();
        StartCoroutine(ChooseNewRule());
    }

    private InputRule RandomRule()
    {
        if (_rules.Count == 0)
        {
            Debug.LogError("List of rules is empty!!!");
            return null;
        }

        InputRule rule = _rules[Random.Range(0, _rules.Count)];
        return rule;
    }

    private IEnumerator ChooseNewRule()
    {
        int ruleTime;
        InputRule rule;
        
        while (true)
        {
            
            rule = RandomRule();
            ruleTime = Random.Range(rule.Duration.x, rule.Duration.y + 1);
            OnRuleChange?.Invoke(rule, ruleTime);
            yield return new WaitForSeconds(ruleTime);
        }
    }
}
