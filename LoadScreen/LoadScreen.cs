using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    private void Awake()
    {
        WaitForScreen();
    }

    public IEnumerator WaitForScreen()
    {
        yield return new WaitForSeconds(5f);
    }
}
