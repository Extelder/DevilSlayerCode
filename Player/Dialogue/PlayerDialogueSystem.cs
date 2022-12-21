using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogueSystem : MonoBehaviour
{
    [SerializeField] private Text _dialogueText;
    private List<string> _sentences = new List<string>();
    private bool _dialoging = false;

    private void OnEnable()
    {
        StartCoroutine(Dialoging());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void AddStringsToDialogue(string[] sentences)
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            _sentences.Add(sentences[i]);
            _dialoging = true;
            Debug.Log(_sentences[i]);
        }
    }

    private IEnumerator Dialoging()
    {
        int i = 0;
        while (true)
        {
            _dialogueText.text = "...";
            yield return new WaitUntil(() => _dialoging);
            _dialogueText.text = _sentences[i];
            yield return new WaitForSeconds(5.5f);
            i++;
            Debug.Log(_sentences.Count);
            if (_sentences.Count - 1 < i)
                _dialoging = false;
        }
    }
}