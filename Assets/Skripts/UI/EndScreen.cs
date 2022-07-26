using UnityEngine;

public abstract class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;

    public void SetPanelState(bool state)
    {
        _endPanel.SetActive(state);
    }
}
