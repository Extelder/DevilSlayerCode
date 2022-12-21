using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private PlayerDialogueSystem _playerDialogue;
    [SerializeField] private string[] _sentences;

    public void StartDialogue()
    {
        _playerDialogue.AddStringsToDialogue(_sentences);
        enabled = false;
    }
}
