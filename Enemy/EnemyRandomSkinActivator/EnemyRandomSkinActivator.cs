using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyRandomSkinActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemySkins;

    private void Awake()
    {
        for (int i = 0; i < _enemySkins.Length; i++)
        {
            _enemySkins[i].SetActive(false);
        }
        _enemySkins[Random.Range(0, _enemySkins.Length)].SetActive(true);
    }
}
