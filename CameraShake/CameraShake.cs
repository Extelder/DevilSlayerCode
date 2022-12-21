using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private CinemachineImpulseSource _impulseSource;

    private void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public virtual void Shake(float value)
    {
        _impulseSource.GenerateImpulse(new Vector3(value, 0f, 0f));
    }
}
