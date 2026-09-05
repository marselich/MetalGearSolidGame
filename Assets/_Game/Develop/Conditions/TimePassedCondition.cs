using System;

public class TimePassedCondition : IConditionable
{
    public event Action<float> TimeChanged
    {
        add => _timer.Changed += value;
        remove => _timer.Changed -= value;
    }

    private Timer _timer;

    public TimePassedCondition(Timer timer, float time)
    {
        _timer = timer;

        _timer.Start(time);
    }

    public bool IsCompleted => _timer.IsEnded;

    public void Dispose() { }
}