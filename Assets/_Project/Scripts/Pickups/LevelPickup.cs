using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPickup : PickupEffects
{
    public override void OnPick(GameObject picker)
    {
        if (!picker.TryGetComponent<PlayerController>(out var player)) return;

        player.SetLevel();

        var weaponHolder = picker.GetComponentInChildren<WeaponHolder>();

        if (weaponHolder.EquippedWeapon != null)
        {
            weaponHolder.DestroyWeapon();
        }        

        Debug.Log("Sei aumentato di livello, la tua arma si è distrutta!");
    }
}
