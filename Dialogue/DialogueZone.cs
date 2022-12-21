using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DialogueZone : Dialogue
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerDialogueSystem>(out PlayerDialogueSystem _playerDialogueSystem))
        {
            StartDialogue();
            Destroy(gameObject);
        }
    }
}