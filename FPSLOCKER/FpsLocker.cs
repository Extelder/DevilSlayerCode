using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLocker : MonoBehaviour
{
    [SerializeField] private int _frameLocker;

    private void Start()
    {
        Application.targetFrameRate = _frameLocker;
    }
}
