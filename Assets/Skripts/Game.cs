using UnityEngine;

public class Game :  MonoBehaviour
{
    [SerializeField] private DefeatScreen _defeatScreen;
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private LevelLoader _loader;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
        _player.Finnished += OnPlayerFinnished;
        _defeatScreen.RestartClicked += OnRestartClicked;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
        _player.Finnished -= OnPlayerFinnished;
        _defeatScreen.RestartClicked -= OnRestartClicked;
    }

    private void Start()
    {
        _winScreen.SetPanelState(false);
        _defeatScreen.SetPanelState(false);
        _loader.LoadLevel();
        _player.Reset(_loader.PlayerStartPosition.position);
    }

    private void OnRestartClicked()
    {
        _loader.LoadLevel();
        _player.Reset(_loader.PlayerStartPosition.position);
        _winScreen.SetPanelState(false);
        _defeatScreen.SetPanelState(false);
    }

    private void OnPlayerDied()
    {
        _defeatScreen.SetPanelState(true);
    }

    private void OnPlayerFinnished(int coinsCount)
    {
        _winScreen.SetPanelState(true);
        _winScreen.SetRewardValue(coinsCount);
    }
}
