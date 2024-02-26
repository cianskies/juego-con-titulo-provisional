using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalidaPiso : MonoBehaviour
{
    public static event Action EventoSuperarNivel;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventoSuperarNivel?.Invoke();
        }
    }
}
