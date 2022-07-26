using UnityEngine;
using DG.Tweening;

public class CoinTamplate : MonoBehaviour
{
    [SerializeField] private Vector3 _targetScale = Vector3.one;
    [SerializeField] private float _upScaleduration = 1f;

    private Transform _target;
    private float _speed;
    private bool _upScaleStarted = false;

    private void Update()
    {
        if (_target == null)
            return;

        if (_upScaleStarted == false)
        {
            transform.DOScale(_targetScale, _upScaleduration);
            _upScaleStarted = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
            Destroy(gameObject);
    }

    public void Init(Transform target, float coinsSpeed = 13)
    {
        _target = target;
        _speed = coinsSpeed;
    }
}
