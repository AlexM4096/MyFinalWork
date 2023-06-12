using UnityEngine;
using UnityEngine.UIElements;

public class TextManager : MonoBehaviour
{
    [SerializeField] [TextArea] private string _text;
    private int _index;
    private Label _tmpText;

    private void Start()
    {
        _tmpText = GetComponent<UIDocument>().rootVisualElement.Q<Label>();
        _tmpText.text = "";
    }

    public void UpdateText(int amount)
    {
        if (amount <= 0) return;
        _tmpText.text += _text.Substring(_index, amount);
        _index += amount;
    }
}
