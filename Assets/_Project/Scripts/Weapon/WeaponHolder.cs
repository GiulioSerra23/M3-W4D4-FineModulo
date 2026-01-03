using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private Weapon _equippedWeapon;
    private AnimationParamHandler _animHandler;
    private AudioPlayer _audioPlayer;
    private bool _hasWeapon;

    public Weapon EquippedWeapon => _equippedWeapon;

    private void Awake()
    {
        _animHandler = GetComponent<AnimationParamHandler>();
        _audioPlayer = GetComponentInChildren<AudioPlayer>();
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        _equippedWeapon = Instantiate(newWeapon, transform);
        _audioPlayer.PlayEquipWeaponSound();
        HasWeapon(true);
    }

    public void DestroyWeapon()
    {
        Destroy(_equippedWeapon.gameObject);
        _audioPlayer.PlayUnequipWeaponSound();
        HasWeapon(false);
    }

    public void HasWeapon(bool hasWeapon)
    {
        _hasWeapon = hasWeapon;
        _animHandler.SetHasWeapon(_hasWeapon);
    }

    private void Update()
    {
        _equippedWeapon = GetComponentInChildren<Weapon>();
    }
}
