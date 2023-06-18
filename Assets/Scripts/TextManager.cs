using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TextManager : MonoBehaviour
{
    private List<TextPrefab> _texts;
    private TextPrefab _text;
    private int _index;
    private Label _tmpText;

    public UnityEvent<TextPrefab> OnTextSet;

    private void Start()
    {
        _texts = Resources.LoadAll<TextPrefab>("TextPrefabs").ToList();
        _text = _texts[Random.Range(0, _texts.Count)];
        OnTextSet?.Invoke(_text);
        
        _tmpText = GetComponent<UIDocument>().rootVisualElement.Q<Label>();
        _tmpText.text = "";
    }

    public void UpdateText(int amount)
    {
        if (amount <= 0) return;
        if (amount + _index >= _text.Text.Length) return;
        _tmpText.text += _text.Text.Substring(_index, amount);
        _index += amount;
    }
}
