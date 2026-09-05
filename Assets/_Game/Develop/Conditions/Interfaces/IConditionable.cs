using System;

public interface IConditionable : IDisposable
{
    bool IsCompleted { get; }
}