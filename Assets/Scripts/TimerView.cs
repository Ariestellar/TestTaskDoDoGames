using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimerView : MonoBehaviour
{    
    [SerializeField] private Starter _starter;   

    [SerializeField] private Button _start;
    [SerializeField] private Text _textButtonStart;
    [SerializeField] private Button _increase;
    [SerializeField] private Button _reduce;
    [SerializeField] private Text _text;

    private ShifterButtonsHomeScreeen _shifterButtonsHomeScreeen;
    private TimerData _currentData;
    private Formatter _formatter;
    
    private void Awake()
    {        
        _start.onClick.AddListener(ButtonStart);
        _increase.onClick.AddListener(ButtonIncrease);
        _reduce.onClick.AddListener(ButtonReduce);
    }

    public void Init(TimerData currentData, ShifterButtonsHomeScreeen shifterButtonsHomeScreeen)
    {
        _currentData = currentData;
        _shifterButtonsHomeScreeen = shifterButtonsHomeScreeen;
        _formatter = new Formatter();        
        Show();
    }

    private void Update()
    {
        if (_currentData.IsLaunch)
        {
            UpdateValue();
        }        
    }
    private void UpdateValue()
    {
        _text.text = _formatter.GetFormattedTime(_currentData.TotalTime);
        ChangeTextButton();
    }

    private void Show()
    {
        UpdateValue();
        this.gameObject.SetActive(true);
        transform.DOScale(new Vector3(0.8f,0.8f,1), 0.5f).OnComplete(()=> _start.interactable = true);
        _shifterButtonsHomeScreeen.HideButton();
    }
 
    private void ButtonStart()
    {
        _start.interactable = false;
        if (_currentData.TotalTime != 0)
        {
            _starter.StartTimer(_currentData);
        }
        transform.DOScale(new Vector3(0, 0, 0), 0.5f).OnComplete(()=> this.gameObject.SetActive(false));        
        _shifterButtonsHomeScreeen.ShowButton();              
    }

    private void ButtonIncrease()
    {
        TimerController.Increase(_currentData);
        UpdateValue();
    }

    private void ButtonReduce()
    {
        TimerController.Reduce(_currentData);
        UpdateValue();
    }

    private void ChangeTextButton()
    {
        if (_currentData.IsLaunch || _currentData.TotalTime == 0)
        {
            _textButtonStart.text = "СКРЫТЬ";
        }
        else
        {
            _textButtonStart.text = "ПУСК";
        }
    }
}
