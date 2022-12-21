using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _damage;
    [SerializeField] private float _spread = 60;
    [SerializeField] private GameObject _damageEffectPrefab;
    [SerializeField] private int _bulletsPerShoot;
    [SerializeField] private bool _returnDamageEffect;

    public event Action Shooted;

    public static event Action<HitBox> OnHitEnemy;

    public bool CanFire = true;

    public void Shoot()
    {
        if (CanFire == false)
            return;

        Shooted?.Invoke();
        for (int i = 0; i < _bulletsPerShoot; i++)
        {
            RaycastHit hit = PerformRaycastHit();
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<HitBox>(out HitBox hitBox))
                {
                    hitBox.Hit(_damage);
                    OnHitEnemy?.Invoke(hitBox);
                    if (_returnDamageEffect)
                        Instantiate(_damageEffectPrefab, hit.point, Quaternion.identity, hitBox.transform);
                }
            }
        }
    }

    public virtual RaycastHit PerformRaycastHit()
    {
        RaycastHit hit;
        Vector3 random = transform.rotation * (Random.insideUnitCircle / _spread);
        Physics.Raycast(_camera.position, _camera.forward + random, out hit, _distance);
        return hit;
    }


    public virtual float GetDamage() => _damage;

    public void AddToDamageValue(float value)
    {
        if (_damage + value <= 0)
        {
            _damage = 0;
            return;
        }

        _damage += value;
    }
}