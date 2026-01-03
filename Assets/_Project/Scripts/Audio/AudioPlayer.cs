using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _hitClips;
    [SerializeField] private AudioClip[] _deathClips;
    [SerializeField] private AudioClip[] _attackClips;
    [SerializeField] private AudioClip[] _openClips;
    [SerializeField] private AudioClip[] _closedClips;
    [SerializeField] private AudioClip[] _levelUpClips;
    [SerializeField] private AudioClip[] _healClips;
    [SerializeField] private AudioClip[] _equipWeaponClips;
    [SerializeField] private AudioClip[] _unequipWeaponClips;
    [SerializeField] private AudioClip _leftFootClip;
    [SerializeField] private AudioClip _rightFootClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayRandomAudio(AudioClip[] clips)
    {
        if (clips == null || clips.Length == 0) return;

        int randomIndex = Random.Range(0, clips.Length);

        _audioSource.PlayOneShot(clips[randomIndex]);
    }

    public void PlayAudio(AudioClip clip)
    {
        if (clip == null) return;

        _audioSource.PlayOneShot(clip);
    }

    public void PlayHitSound()
    {
        PlayRandomAudio(_hitClips);
    }

    public void PlayDeathSound()
    {
        PlayRandomAudio(_deathClips);
    }

    public void PlayAttackSound()
    {
        PlayRandomAudio(_attackClips);
    }

    public void PlayOpenSound()
    {
        PlayRandomAudio(_openClips);
    }

    public void PlayClosedSound()
    {
        PlayRandomAudio(_closedClips);
    }

    public void PlayLevelUpSound()
    {
        PlayRandomAudio(_levelUpClips);
    }

    public void PlayHealSound()
    {
        PlayRandomAudio(_healClips);
    }

    public void PlayEquipWeaponSound()
    {
        PlayRandomAudio(_equipWeaponClips);
    }

    public void PlayUnequipWeaponSound()
    {
        PlayRandomAudio(_equipWeaponClips);
    }

    public void PlayLeftFootSound()
    {
        PlayAudio(_leftFootClip);
    }

    public void PlayRightFootSound()
    {
        PlayAudio(_rightFootClip);
    }
}
