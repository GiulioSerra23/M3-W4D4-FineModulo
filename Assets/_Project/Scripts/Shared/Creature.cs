using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : Entity
{ 
    [SerializeField] protected string _name;
    [SerializeField] protected int _damage;

    protected LifeController _lifeController;
    protected TopDownMover2D _mover2D;
    protected AnimationParamHandler _animHandler;
    protected AudioPlayer _audioPlayer;

    protected int _pendingHits;
    protected bool _isDead;

    public bool CanMove => _pendingHits == 0 && !_isDead;

    public bool IsDead { get => _isDead; set => _isDead = value; }

    protected virtual void Awake()
    {
        _lifeController = GetComponent<LifeController>();
        _mover2D = GetComponent<TopDownMover2D>();
        _animHandler = GetComponent<AnimationParamHandler>();
        _audioPlayer = GetComponentInChildren<AudioPlayer>();
    }      

    public virtual void Hit(int damage)
    {
        if (_isDead) return;   

        _lifeController.TakeDamage(damage);
        _pendingHits++;
        _animHandler.SetIsHit();
        _audioPlayer.PlayHitSound();
    }

    public void EndHitFromAnimation()     // Ho creato questa funzione nel caso in cui si venisse hittati più volte in rapida successione,
    {                                     // allora gli hit si accumulano e la creatura non può muoversi finchè non finisce l'animazione di tutti gli hit
        _pendingHits--;
        if (_pendingHits < 0)
        {
            _pendingHits = 0;
        }        
    }

    public virtual void Die()
    {
        _isDead = true;
        _animHandler.SetIsDead();
        GetComponent<Collider2D>().enabled = false;
        _audioPlayer.PlayDeathSound();
    }
}