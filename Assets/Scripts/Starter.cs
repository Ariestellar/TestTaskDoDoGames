using UnityEngine;

public class Starter : MonoBehaviour
{
    public void StartTimer(TimerData timerData)
    {
        StartCoroutine(TimerController.Countdown(timerData));
    }
}
