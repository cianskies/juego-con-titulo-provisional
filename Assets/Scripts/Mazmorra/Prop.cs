using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour, IRecbirDanho
{
    [Header("Cositas")]
    [SerializeField] private float _salud;
    private float _danhoRecibido;
    public void RecibirDanho(float danho)
    {
        ++_danhoRecibido;
        if(_danhoRecibido >= _salud) { 
            Destroy(gameObject);
        }
    }

    
}
