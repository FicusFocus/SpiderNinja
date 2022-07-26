using UnityEngine;

public class CameraPositionSetter : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _yOffset = 2;
    [SerializeField] private float _zOffset = 10;

    private void Update()
    {
        if (_target == null)
            return;

        var targetPosition = _target.transform.position;
        targetPosition.z -= _zOffset;
        targetPosition.y += _yOffset;

        if (transform.position != targetPosition)
        {
            Move(targetPosition);
        }
    }

    private void Move(Vector3 targetPosition)
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
    }

    public void SetTarget(Player player)
    {
        _target = player;
    }
}
