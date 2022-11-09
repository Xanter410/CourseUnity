using TMPro;
using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] private DoorLock _doorLock;
    [SerializeField] private TextMeshProUGUI _nameTextField;
    [SerializeField] private TextMeshProUGUI _infoTextField;
    [SerializeField] private string _name;
    [SerializeField, Range(-2, 2)] private int _offset1;
    [SerializeField, Range(-2, 2)] private int _offset2;
    [SerializeField, Range(-2, 2)] private int _offset3;

    private void Awake()
    {
        _nameTextField.text = _name;
        _infoTextField.text = $"Ёффект:\n{_offset1} | {_offset2} | {_offset3}";
    }

    public void OnClick()
    {
        _doorLock.PinShift(_offset1, _offset2, _offset3);
    }
}
