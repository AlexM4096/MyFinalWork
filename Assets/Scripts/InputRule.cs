using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Scriptable Object/Input Rule", fileName = "InputRule", order = 0)]
public class InputRule : ScriptableObject
{
    public string Name;
    [TextArea] public string RuleString;
    [TextArea] public string Description;
    public Vector2Int Duration;
}
