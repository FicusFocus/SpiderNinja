using UnityEngine;
using UnityEngine.Events;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Level _level1;
    [SerializeField] private Player _player;
    [SerializeField] private DirectionSetter _directionSetter;

    private Level _curentLoadLevel;

    public Transform PlayerStartPosition => _curentLoadLevel.PlayerStartPosition;

    public void LoadLevel()
    {
        if (_curentLoadLevel == null)
        {
            _curentLoadLevel = Instantiate(_level1, this.transform);
        }
        else
        {
            Destroy(_curentLoadLevel.gameObject);
            _curentLoadLevel = Instantiate(_level1, this.transform);
        }
    }
}

