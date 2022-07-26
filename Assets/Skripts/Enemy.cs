using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dieEffect;
    [SerializeField] private GameObject _enemyTexture;
    [SerializeField] private int _revard;
    [SerializeField] private float _dieDelay = 5f;

    private Collider _collider;

    public int Reward => _revard;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    public void TakeDamage() 
    {
        _collider.enabled = false;
        _enemyTexture.SetActive(false);
        _dieEffect.Play();
        Destroy(gameObject, _dieDelay); 
    }
}
