using UnityEngine;
using UnityEngine.Events;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private Pin _pin1;
    [SerializeField] private Pin _pin2;
    [SerializeField] private Pin _pin3;
    [SerializeField] private UnityEvent _onDoorUnlocked;

    public bool IsUnlocked
    {
        get { return _pin1.IsUnlocked && _pin2.IsUnlocked && _pin3.IsUnlocked; }
    }

    public void Lockup()
    {
        _pin1.Lock();
        _pin2.Lock();
        _pin3.Lock();
    }

    public void PinShift(int offset_pin1, int offset_pin2, int offset_pin3)
    {
        _pin1.Change(offset_pin1);
        _pin2.Change(offset_pin2);
        _pin3.Change(offset_pin3);

        if (IsUnlocked)
        {
            _onDoorUnlocked.Invoke();
        }
    }
}

