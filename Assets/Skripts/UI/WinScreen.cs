using UnityEngine;
using TMPro;

public class WinScreen : EndScreen
{
    [SerializeField] private TMP_Text _rewardCount;

    public void SetRewardValue(int value)
    {
        _rewardCount.text = value.ToString();
    }
}
