using UnityEngine;
using UnityEngine.UIElements;

public class RuleBannerTimerInside : VisualElement
{
    public Label _ruleText;
    private RuleBannerWithTimer _parent;
    private ProgressBar _timer;
    private float _remainingTime = 30;

    public RuleBannerTimerInside() : base()
    {
        VisualElement visualElement = new VisualElement();
        visualElement.AddToClassList("timer-container");
        
        _ruleText = new Label();
        _ruleText.AddToClassList("rule-text");
        visualElement.Add(_ruleText);

        _timer = new ProgressBar();
        _timer.AddToClassList("timer");
        visualElement.Add(_timer);
        
        Add(visualElement);
    }

    public void UpdateTime()
    {
        _remainingTime -= Time.deltaTime;
        if (_remainingTime < 0)
        {
            _parent.EndTimerAction();
        }
        else
        {
            _timer.value = _remainingTime;
        }
    }

    public void SetTimer(int time)
    {
        _timer.highValue = time;
        _remainingTime = time;
    }

    public void SetParent(RuleBannerWithTimer parent)
    {
        _parent = parent;
    }
}

// #region UXML
// [Preserve]
// public class UxmlFactory : UxmlFactory<RuleBannerTimerInside, UxmlTraits> { }
// [Preserve]
// public class UxmlTraits : VisualElement.UxmlTraits { }
// #endregion