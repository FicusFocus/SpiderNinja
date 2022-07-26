using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DirectionSetter : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private float _minSwipeTime = 0.1f;
    [SerializeField] private float _maxSwipeTime = 0.5f;
    
    private bool _swipeStart;
    private float _currentSwipeTime;
    private Direction _swipeDirection;

    public event UnityAction<Direction> Swiped;

    private void Update()
    {
        if (_swipeStart)
        {
            _currentSwipeTime += Time.deltaTime;
        }
        else if(_currentSwipeTime >= _minSwipeTime && _currentSwipeTime <= _maxSwipeTime)
        {
            Swiped?.Invoke(_swipeDirection);
            _currentSwipeTime = 0;
        }
        else
        {
            _currentSwipeTime = 0;
        }
    }

    private void Swipe(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
            {
                _swipeStart = true;
                _swipeDirection = Direction.Rigth;
            }
            else
            {
                _swipeStart = true;
                _swipeDirection = Direction.Left;
            }
        }
        else
        {
            if (eventData.delta.y > 0)
            {
                _swipeStart = true;
                _swipeDirection = Direction.Up;
            }
            else
            {
                _swipeStart = true;
                _swipeDirection = Direction.Down;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {  
        Swipe(eventData);
    }

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnEndDrag(PointerEventData eventData)
    {
        _swipeStart = false;
    }
}
