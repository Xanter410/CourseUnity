using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas _toolsCanvas;
    [SerializeField] private TextMeshProUGUI _conditionText;
    [SerializeField] private Canvas _finalCanvas;
    [SerializeField] private TextMeshProUGUI _finalMessage;
    [SerializeField] private Timer _timer;
    [SerializeField] private DoorLock _doorLock;
    [SerializeField] private float _gameTime;

    private void Awake()
    {
        Init();
        NewGame();
    }

    public void OnClickReset()
    {
        NewGame();
    }

    public void OnPlayerWin()
    {
        SwithToFinalState("�����������!\n�� �������!");
    }
    public void OnPlayerLost()
    {
        SwithToFinalState("��������� :(\n�������� �����!");
    }


    private void Init()
    {
        _conditionText.text = "��� ������ �������� ��� ���� �� �������� 5 \n" +
            "��������� ������� ���� Pin3 �� ������ ����� 0, " +
            "������ ��������� �����, ���� Pin3 � Pin2 �� ������ ����� 0," +
            "������ ��������� �������, ���� �� ���������!";
    }

    private void NewGame()
    {
        _timer.Restart(_gameTime);
        _doorLock.Lockup();
        SwithToPlayCanvasState();
    }

    private void SwithToPlayCanvasState()
    {
        _toolsCanvas.enabled = true;
        _finalCanvas.enabled = false;
    }

    private void SwithToFinalState(string message)
    {
        _timer.Stop();
        _toolsCanvas.enabled = false;
        _finalCanvas.enabled = true;
        _finalMessage.text = message;
    }
}
