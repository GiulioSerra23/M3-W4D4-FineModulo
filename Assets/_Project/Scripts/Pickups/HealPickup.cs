using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : PickupEffects
{
    [SerializeField] private int _healAmount;

    public override void OnPick(GameObject picker)
    {
        if (!picker.TryGetComponent<LifeController>(out var lifeController)) return;

        var audioPlayer = picker.GetComponentInChildren<AudioPlayer>();
        if (audioPlayer == null) return;

        lifeController.AddHp(_healAmount);
        audioPlayer.PlayHealSound();
    }
}
