using TMPro;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pinTextFieled;
    [SerializeField] private int _minPinPosition;
    [SerializeField] private int _maxPinPosition;
    [SerializeField] private int _lockPinPosition;
    [SerializeField] private int _unlockPinPosition;
    private int _position;

    private void Awake()
    {
        if (_lockPinPosition == -1)
        {
            _lockPinPosition = Random.Range(0, 11);
        }
    }

    public bool IsUnlocked
    {
        get { return _position == _unlockPinPosition; }
    }

    public void Lock()
    {
        UpdatePosition(_lockPinPosition);
    }

    public void Change(int offset)
    {
        UpdatePosition(_position + offset);
    }

    private void UpdatePosition(int newPosition)
    {
        _position = Mathf.Clamp(newPosition, _minPinPosition, _maxPinPosition);

        _pinTextFieled.text = _position.ToString();
    }
}
