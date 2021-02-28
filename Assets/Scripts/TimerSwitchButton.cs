using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(RectTransform))]
public class TimerSwitchButton : MonoBehaviour
{
    [SerializeField] private ShifterButtonsHomeScreeen _shifterButtonsHomeScreeen;
    [SerializeField] private TimerView _timerView;
    [SerializeField] private TimerData _timerData;

    private Button _button;
    private RectTransform _transform;

    public RectTransform Transform { get => _transform;}
    public Button Button { get => _button;}

    private void Awake()
    {
        _button = GetComponent<Button>();
        _transform = GetComponent<RectTransform>();        
        _button.onClick.AddListener(ShowTimer);
        _timerData.Stop += SingsButton;
    }

    private void ShowTimer()
    {
        _timerView.Init(_timerData, _shifterButtonsHomeScreeen);        
    }

    private void SingsButton()
    {
        _button.image.DOColor(Color.yellow, 0.5f).OnComplete(() => _button.image.DOColor(Color.white, 0.5f));
    }
}
