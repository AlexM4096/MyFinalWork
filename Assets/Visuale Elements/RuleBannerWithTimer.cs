using System;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

public class RuleBannerWithTimer : BannerBase<RuleBannerTimerInside>
{
    public RuleBannerWithTimer() : base() {}
    
    public RuleBannerWithTimer(Action<IBanner> action) : base(action)
    {
        inside.SetParent(this);

        GameManger.OnUpdate += Update;
    }

    public void EndTimerAction()
    {
        closeEvent(this);
    }

    private void Update()
    {
        inside.UpdateTime();
    }

    public void SetRule(InputRule rule, int time)
    {
        inside._ruleText.text = rule.Description;
        inside.SetTimer(time);
    }
}

#region UXML
[Preserve]
public class UxmlFactory : UxmlFactory<RuleBannerWithTimer, UxmlTraits> { }
[Preserve]
public class UxmlTraits : VisualElement.UxmlTraits { }
#endregion