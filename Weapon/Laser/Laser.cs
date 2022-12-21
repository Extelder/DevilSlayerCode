using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject _laser;

    public void ActivateLaser()
    {
        _laser.SetActive(true);
    }

    public void DisActivateLaser()
    {
        _laser.SetActive(false);
    }
}