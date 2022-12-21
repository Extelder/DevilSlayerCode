using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private void OnEnable() => Invoke("ReturnToPool", 3.5f);

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
