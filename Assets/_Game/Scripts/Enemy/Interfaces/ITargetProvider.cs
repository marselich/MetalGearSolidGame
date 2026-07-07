using UnityEngine;

public interface ITargetProvider
{
    Transform Target { get; set; }
    bool HasTarget();
}