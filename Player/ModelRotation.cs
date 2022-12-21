using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ModelRotation : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnEnable()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _camera.localEulerAngles.y, transform.localEulerAngles.z);
        }).AddTo(_disposable);
    }

    private void OnDisable() => _disposable.Clear();
}
