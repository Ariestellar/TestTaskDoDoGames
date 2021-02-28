using System;
using System.Collections;
using UnityEngine;

public static class TimerController
{
    public static IEnumerator Countdown(TimerData timerData)
    {
        timerData.IsLaunch = true;
        while (timerData.TotalTime > 0)
        {
            timerData.TotalTime = Mathf.Clamp(timerData.TotalTime - Time.deltaTime, 0, timerData.TotalTime);
            yield return null;
        }
        timerData.Stop?.Invoke();
        timerData.IsLaunch = false;
    }

    public static void Increase(TimerData timerData)
    {
        timerData.TotalTime += timerData.StepChanges;        
    }

    public static void Reduce(TimerData timerData)
    {
        timerData.TotalTime = Mathf.Clamp(timerData.TotalTime - timerData.StepChanges, 0, timerData.TotalTime);        
    }
}
