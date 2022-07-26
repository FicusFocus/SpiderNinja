using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private CoinsCountSetter _coinsCountSetter;
    [SerializeField] private DirectionSetter _directionSetter;
    [SerializeField] private Transform _raycastStartPosition;
    [SerializeField] private RevardEffect _revardEffect;
    [SerializeField] private ParticleSystem _dieEffect;
    [SerializeField] private LayerMask _raycastMask;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _ninja;
    [SerializeField] private float _moveSpeedValue = 0.5f;
    [SerializeField] private float _rotationSpeed = 0.2f;


    private Vector3 _targetPosition;
    private bool _enRoute;
    private int _coins;
    private string _jumpTrigger = "Fall";
    private string _sitTrigger = "Sit";

    public event UnityAction<int> Finnished;
    public event UnityAction Died;

    private void OnEnable()
    {
        _directionSetter.Swiped += OnSwipe;
    }

    private void OnDisable()
    {
        _directionSetter.Swiped -= OnSwipe;
    }

    private void Update()
    {
        if (_enRoute)
        {
            _animator.SetTrigger(_jumpTrigger);
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeedValue * Time.deltaTime);
        }

        if (transform.position == _targetPosition)
        {
            _enRoute = false;
            _animator.SetTrigger(_sitTrigger);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            AddCoins(1);
            coin.Die();
            return;
        }

        if (other.TryGetComponent(out Enemy enemy))
            KillEnemy(enemy);
        else if (other.TryGetComponent(out TornObstacle obstacle))
            Die();
        else if (other.TryGetComponent(out FinnishTrigger finnis))
            Finnished?.Invoke(_coins);
    }

    private void Die()
    {
        Died?.Invoke();
        _dieEffect.Play();
        _ninja.gameObject.SetActive(false);
    }

    private void AddCoins(int coinCount)
    {
        if (coinCount <= 0)
            return;

        _coins += coinCount;
        _coinsCountSetter.SetNewValue(_coins);
    }

    private void KillEnemy(Enemy enemy)
    {
        _revardEffect.Play(_coinsCountSetter.transform);
        AddCoins(enemy.Reward);
        enemy.TakeDamage();
    }

    private void OnSwipe(Direction direction)
    {
        if (_enRoute)
            return;
        Rotate(direction);
        MoveTo(direction);
    }

    private void MoveTo(Direction direction)
    {
        var tragetDirection = Vector3.zero;

        switch (direction)
        {
            case Direction.Up:
                tragetDirection = Vector3.up;
                break;
            case Direction.Down:
                tragetDirection = Vector3.down;
                break;
            case Direction.Left:
                tragetDirection = Vector3.left;
                break;
            case Direction.Rigth:
                tragetDirection = Vector3.right;
                break;
        }

        _enRoute = true;

        Physics.Raycast(_raycastStartPosition.position, tragetDirection, out RaycastHit hitInfo, Mathf.Infinity, _raycastMask);
        _targetPosition = hitInfo.collider.transform.position;
    }

    private void Rotate(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                _ninja.DORotate(new Vector3(0, 180, 180), _rotationSpeed);
                break;
            case Direction.Down:
                _ninja.DORotate(new Vector3(0, 180, 0), _rotationSpeed);
                break;
            case Direction.Left:
                _ninja.DORotate(new Vector3(180, 0, - 90), _rotationSpeed);
                break;
            case Direction.Rigth:
                _ninja.DORotate(new Vector3(180, 0, 90), _rotationSpeed);
                break;
        }
    }

    public void Reset(Vector3 startPosition)
    {
        _dieEffect.Stop();
        transform.position = startPosition;
        _ninja.gameObject.SetActive(true);
        _coins = 0;
        _coinsCountSetter.SetNewValue(_coins);
        Rotate(Direction.Down);
    }
}
