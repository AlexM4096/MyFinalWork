using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Scriptable Object/Text Prefab", fileName = "TextPrefab", order = 1)]
public class TextPrefab : ScriptableObject
{
    public string Name;
    [TextArea] public string Text;
}
