using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _spellDestroyPerticle;
    
    private Rigidbody _rigidbody;
    private Transform _player;

    private void Start()
    {
        _player = Player.Instance.transform;
        _rigidbody = GetComponent<Rigidbody>();
        Invoke(nameof(OnDeath), 5f);
    }

    private void Update()
    {
        _rigidbody.velocity += transform.forward * _speed;
    }

    private void FixedUpdate()
    {
        transform.LookAt(_player);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent<PlayerHealth>(out PlayerHealth health))
        {
            Attack(health);
            OnDeath();
        }
    }

    public virtual void Attack(Health health)
    {
        health.TakeDamage(_damage);
    }
    
    public virtual void OnDeath()
    {
        Instantiate(_spellDestroyPerticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
