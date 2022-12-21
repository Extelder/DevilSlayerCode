using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(YandexSDK))]
public class Advertisment : MonoBehaviour
{
   [SerializeField] private float _delay = 0;
   private YandexSDK _yandexSdk;

   private void Awake()
   {
      _yandexSdk = GetComponent<YandexSDK>();
   }

   private void Start()
   {
      Invoke(nameof(ShowAd), _delay);
   }

   private void ShowAd()
   {
      _yandexSdk.ShowInterstitial();
   }
}
