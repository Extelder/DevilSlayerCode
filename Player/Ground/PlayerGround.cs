using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGround : MonoBehaviour
{
    [field: SerializeField] public bool OnGround { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        OnGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        OnGround = false;
    }
}