using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerTextField;
    [SerializeField] private UnityEvent _onTimeOver;

    private float _timeLeft;
    private bool isStopped;

    private void Update()
    {
        if (_timeLeft > 0 && !isStopped)
        {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft < 0)
            {
                _timeLeft = 0;
                _onTimeOver.Invoke();
            }
            _timerTextField.text = _timeLeft.ToString("#.##");
        }
    }

    public bool IsTimeOver
    {
        get { return _timeLeft <= 0; }
    }

    public void Restart(float duration)
    {
        _timeLeft = duration;
        isStopped = false;
    }
    public void Stop()
    {
        isStopped = true;
    }

}
