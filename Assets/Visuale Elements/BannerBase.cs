using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BannerBase<T> : VisualElement, IBanner where T: VisualElement, new()
{
    public T inside;
    public VisualElement top;
    public Action<IBanner> closeEvent;

    protected BannerBase()
    {
        top = new();
        top.AddToClassList("top");
        Add(top);

        inside = new T(); 
        inside.AddToClassList("inside");
        Add(inside);
        
        AddToClassList("banner");
    }

    protected BannerBase(Action<IBanner> action) : this()
    {
        closeEvent += action;
    }

    public void Resize(int width, int height)
    {
        style.width = width;
        style.height = height;
    }

    public void Resize(Vector2Int size)
    {
        Resize(size.x, size.y);
    }

    public Vector2Int Size()
    {
        return new Vector2Int((int)style.width.value.value, (int)style.height.value.value);
    }

    public void Reposition(int x, int y)
    {
        style.left = x;
        style.top = y;
    }

    public void Reposition(Vector2Int position)
    {
        Reposition(position.x, position.y);
    }

    public Vector2Int Position()
    {
        return new Vector2Int((int)style.left.value.value, (int)style.top.value.value);
    }
    

    public void SetActive(bool state)
    {
        style.display = state ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
