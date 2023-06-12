using System;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

public class DefaultBanner : BannerBase<Image>
{
    private Button button;

    public DefaultBanner() : base()
    {
        button = new Button();
        button.AddToClassList("button");
        top.Add(button);
    }

    public DefaultBanner(Action<IBanner> action) : base(action)
    {
        button = new Button();
        button.AddToClassList("button");
        top.Add(button);
        
        button.clicked += () => closeEvent(this);
    }
}

// #region UXML
// [Preserve]
// public class UxmlFactory : UxmlFactory<DefaultBanner, UxmlTraits> { }
// [Preserve]
// public class UxmlTraits : VisualElement.UxmlTraits { }
// #endregion