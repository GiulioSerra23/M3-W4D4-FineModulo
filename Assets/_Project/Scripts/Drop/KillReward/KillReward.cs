using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KillReward 
{
    [SerializeField] private Pickup _rewardItemPrefab;
    [SerializeField] private int _killRequired;

    public Pickup RewardItemPrefab => _rewardItemPrefab;

    public int KillRequired => _killRequired;

    public bool IsGiven { get; set; }
}
