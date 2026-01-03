using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FunctionsAnimEvent : MonoBehaviour
{
    [SerializeField] private string _phrase;

    private Entity _entity;
    private Destroyable _destroyable;
    private WeaponHolder _weaponHolder;
    private Creature _creature;
    private AudioPlayer _audioPlayer;

    private void Awake()
    {
        _entity = GetComponentInParent<Entity>();
        _weaponHolder = GetComponentInParent<WeaponHolder>();
        _creature = GetComponentInParent<Creature>();
        _destroyable = GetComponentInParent<Destroyable>();
        _audioPlayer = _entity.GetComponentInChildren<AudioPlayer>();
    }

    public void Shoot()
    {
        _weaponHolder.EquippedWeapon.ShootFromAnimation();
        _audioPlayer.PlayAttackSound();
    }

    public void EndAttack()
    {
        _weaponHolder.EquippedWeapon.IsAttacking = false;
    }

    public void ResolveHit()
    {
        _creature.EndHitFromAnimation();
    }

    public void LeftFootSound()
    {
        _audioPlayer.PlayLeftFootSound();
    }

    public void RightFootSound()
    {
        _audioPlayer.PlayRightFootSound();
    }

    public void ShowText()
    {
        Debug.Log($"{_phrase}");
    }

    public void Destroy()  // Questa funzione viene chiamata dall'animazione di morte degli oggetti distruttibili
    {
        if (_destroyable != null)
        {
            _destroyable.DestroySelf();
        }
    }

    public void DestroyColliders()  // Questa funzione viene chiamata dall'animazione di tutti quegli oggetti che devono rimanere visibili, ma che non devono più interagire con il giocatore
    {
        foreach (var collider2D in GetComponentsInParent<Collider2D>())
        {
            Destroy(collider2D);
        }
    }

    public void RestartLevel()
    {
        GameOverManager.Instance.ReloadScene();
    }
}
