using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _particle;

    public void Spawn()
    {
        Instantiate(_particle, transform.position, Quaternion.identity);
    }
}