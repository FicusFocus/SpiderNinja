using UnityEngine;
using TMPro;

public class CoinsCountSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinCounter;

    public void SetNewValue(int value)
    {
        _coinCounter.text = value.ToString();
    }
}
