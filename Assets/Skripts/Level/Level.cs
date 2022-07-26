using UnityEngine;

public abstract class Level : MonoBehaviour
{
    [SerializeField] private Transform _playerStartPosition;

    public Transform PlayerStartPosition => _playerStartPosition;
}
