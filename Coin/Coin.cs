using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerWallet>(out PlayerWallet wallet))
        {
            wallet.AddCoins(5);
            Pickup();
        }
    }

    public void Pickup()
    {
        Instantiate(_pickupEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}