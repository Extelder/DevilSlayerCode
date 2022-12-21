using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;

    public void Activate()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].SetActive(true);
        }
    }

    public bool WaveCompleate()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] != null)
            {
                return false;
            }
        }

        return true;
    }
}