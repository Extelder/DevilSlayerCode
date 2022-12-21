using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWavesActivator : MonoBehaviour
{
    [SerializeField] private PlayerGameState _playerGameState;
    [SerializeField] private EnemyWave[] _activators;

    private void Start()
    {
        StartCoroutine(InitializingWaves());
    }

    private IEnumerator InitializingWaves()
    {
        for (int i = 0; i < _activators.Length; i++)
        {
            _activators[i].Activate();
            yield return new WaitUntil(_activators[i].WaveCompleate);
        }
        _playerGameState.Win();
    }
}