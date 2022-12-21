using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPartReset : MonoBehaviour
{
    private Vector3 _position;
    private Quaternion _rotation;
    private Vector3 _scale;
    private bool _enabled;

    private void Awake()
    {
        _position = transform.localPosition;
        _rotation = transform.localRotation;
        _scale = transform.localScale;
        _enabled = enabled;
    }

    private void OnEnable()
    {
        ResetAllAnimationData();
    }


    private void OnDisable()
    {
        ResetAllAnimationData();
    }

    private void ResetAllAnimationData()
    {
        transform.localPosition = _position;
        transform.localRotation = _rotation;
        transform.localScale = _scale;
        enabled = _enabled;
    }
}
