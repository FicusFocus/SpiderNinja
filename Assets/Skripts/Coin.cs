using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _coinTexture;
    [SerializeField] private ParticleSystem _explosionEffect;

    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    public void Die()
    {
        _collider.enabled = false;
        _coinTexture.SetActive(false);
        _explosionEffect.Play();
        Destroy(gameObject, _explosionEffect.main.duration);
    }
}
