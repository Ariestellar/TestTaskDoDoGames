using System;
using UnityEngine;

[CreateAssetMenu()]
public class TimerData : ScriptableObject
{       
    [Range(1,100)][SerializeField] private int _stepChanges;
    [SerializeField] private float _totalTime;
    [SerializeField] private bool _isLaunch;

    public Action Stop;

    public float TotalTime { get => _totalTime; set => _totalTime = value; }
    public int StepChanges { get => _stepChanges;}
    public bool IsLaunch { get => _isLaunch; set => _isLaunch = value; }
}
