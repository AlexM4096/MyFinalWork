using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Scriptable Object", fileName = "InputRule", order = 0)]
public class InputRule : ScriptableObject
{
    public string Name;
    public string RuleString;
    [TextArea] public string Description;
}
