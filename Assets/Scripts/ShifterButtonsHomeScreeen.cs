using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class ShifterButtonsHomeScreeen : MonoBehaviour
{
    [SerializeField] private TimerSwitchButton[] _timerSwitchButtons;    

    private float _moveSpeed = 0.2f;
    private float _offsetForShowing = 0.5f;
    private float _offsetForHiding = 1.6f;
    private int _numberButtonsShifted = 0;

    public void Init(TimerSwitchButton[] timerSwitchButtons)
    {
        _timerSwitchButtons = timerSwitchButtons;        
    }

    public void ShowButton()
    {
        ShiftButtons(_offsetForShowing);
    }

    public void HideButton()
    {
        ShiftButtons(_offsetForHiding);
    }

    private void ShiftButtons(float offsetX)
    {        
        if (_numberButtonsShifted == _timerSwitchButtons.Length)
        {
            SetInteractable(true);
            _numberButtonsShifted = 0;
        }
        else
        {
            SetInteractable(false);
            _timerSwitchButtons[_numberButtonsShifted].Transform.DOPivotX(offsetX, _moveSpeed).
            OnComplete(() => ShiftButtons(offsetX));
            _numberButtonsShifted += 1;
        }
    }

    private void SetInteractable(bool value)
    {
        foreach (var timerSwitchButton in _timerSwitchButtons)
        {
            timerSwitchButton.Button.interactable = value;
        }        
    }
}
