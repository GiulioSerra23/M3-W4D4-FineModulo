using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : PickupEffects
{
    [SerializeField] private Weapon _weapon;

    public override void OnPick(GameObject picker)
    {
        if (!picker.TryGetComponent<WeaponHolder>(out var weaponHolder)) return;

        weaponHolder.EquipWeapon(_weapon);
    }
}
