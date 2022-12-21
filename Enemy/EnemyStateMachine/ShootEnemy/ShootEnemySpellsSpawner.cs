using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemySpellsSpawner : MonoBehaviour
{
    [SerializeField] private Transform _muzzle;
    [SerializeField] private Spell[] _spells;
    
    public void SpawnRandomSpell()
    {
        Instantiate(_spells[Random.Range(0, _spells.Length)], _muzzle.position, Quaternion.identity);
    }
}
