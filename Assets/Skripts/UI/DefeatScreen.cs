using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DefeatScreen : EndScreen
{
    [SerializeField] private Button _restartButton;

    public event UnityAction RestartClicked;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnRestartButtonClick()
    {
        RestartClicked?.Invoke();
    }
}
