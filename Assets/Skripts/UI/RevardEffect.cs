using UnityEngine;

public class RevardEffect : MonoBehaviour
{
    [SerializeField] private CoinTamplate _coinTamplate;
    [SerializeField] private float _coinsSpeed;
    [SerializeField] private int _coinsCount = 4;

    private float _offset = 0.5f;

    public void Play(Transform targetForCoinstamlate)
    {
        for (int i = 0; i < _coinsCount; i++)
        {
            var randomPosition = transform.position;
            randomPosition.x += Random.Range(-_offset, +_offset);
            var newCoin = Instantiate(_coinTamplate, randomPosition, Quaternion.identity);
            newCoin.Init(targetForCoinstamlate, _coinsSpeed);            
        }
    }
}
