using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action<float> Changed;
    public event Action Ended;

    private MonoBehaviour _timerRunner;

    private float _currentTime;
    private Coroutine _timeProcess;
    private bool _isEnded;

    public Timer(MonoBehaviour timerRunner)
    {
        _timerRunner = timerRunner;
    }

    public float Time => _currentTime;
    public bool IsEnded => _isEnded;

    public void Start(float time)
    {
        _isEnded = false;
        _timeProcess = _timerRunner.StartCoroutine(TimeProcess(time));
    }

    public void Stop()
    {
        _timerRunner.StopCoroutine(_timeProcess);
    }

    private IEnumerator TimeProcess(float time)
    {
        while (_currentTime <= time)
        {
            _currentTime += UnityEngine.Time.deltaTime;
            Changed?.Invoke(_currentTime);

            yield return null;
        }

        _isEnded = true;
        Ended?.Invoke();
    }
}