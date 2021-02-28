using UnityEngine;
using UnityEngine.UI;

public class StartSession : MonoBehaviour
{
    [SerializeField] private TimerSwitchButton[] _timerSwitchButtons;
    [SerializeField] private TimerData[] _timerData;

    [SerializeField] private ShifterButtonsHomeScreeen _shifterButtonsHomeScreeen;
    [SerializeField] private Starter _starter;
    [SerializeField] private CanvasScaler _canvasScaler;

    [SerializeField] private float test;

    private void Awake()
    {
        _shifterButtonsHomeScreeen.Init(_timerSwitchButtons);
    }

    private void Start()
    {
        _shifterButtonsHomeScreeen.ShowButton();
        foreach (var timer in _timerData)
        {
            if (timer.IsLaunch)
            {
                _starter.StartTimer(timer);
            }            
        }
    }
}
