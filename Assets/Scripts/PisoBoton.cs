using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisoBoton : MonoBehaviour
{
    public static event Action EventoPulsarBoton;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventoPulsarBoton?.Invoke();
        }
    }
}
