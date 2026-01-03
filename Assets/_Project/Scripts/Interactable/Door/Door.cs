using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private int _killRequired;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(Tags.Player)) return;

        if (KillManager.Instance.HasReachedKills(_killRequired))
        {
            _canInteract = true;
            Debug.Log("Premi E per aprire la porta");
        }
        else
        {
            Debug.Log($"Hai bisogno di {_killRequired} uccisioni per aprirla, uccidi altri nemici o ricomincia il livello!");
            _audioPlayer.PlayClosedSound();
        }
    }
}
