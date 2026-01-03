using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    [SerializeField] private List<KillReward> _killRewards;

    public static KillManager Instance { get; private set; }  // Ho fatto l'instanza perchè è più comodo richiamare le funzioni di KillManager da altre classi, 
    private int _killCount;                                   // e così non ho bisogno di fare FindObjectOfType e appesantire il codice

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public bool HasReachedKills(int requireKills)
    {
        return _killCount >= requireKills;
    }

    private void CheckRewards(Vector2 dropPosition)
    {
        foreach (var reward in _killRewards)
        {
            if (!reward.IsGiven && HasReachedKills(reward.KillRequired))
            {
                Instantiate(reward.RewardItemPrefab, dropPosition, Quaternion.identity);
                reward.IsGiven = true;
            }           
        }
    }

    public void OnKill(Vector2 dropPosition)
    {
        _killCount++;
        Debug.Log($"Uccisioni: {_killCount}");

        CheckRewards(dropPosition);        
    }
}
