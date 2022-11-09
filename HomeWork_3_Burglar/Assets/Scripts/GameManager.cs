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
        SwithToFinalState("Поздравляем!\nТы победил!");
    }
    public void OnPlayerLost()
    {
        SwithToFinalState("Поражение :(\nПопробуй снова!");
    }


    private void Init()
    {
        _conditionText.text = "Для победы установи все пины на значение 5 \n" +
            "Используй молоток пока Pin3 не станет равен 0, " +
            "дальше используй дрель, пока Pin3 и Pin2 не станут равны 0," +
            "дальше используй отмычку, пока не выиграешь!";
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
