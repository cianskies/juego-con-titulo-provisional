using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    private float _tiempo;
    private int _minutos, _segundos;
    public int Minutos { get { return _minutos; } }
    public int Segundos { get { return _segundos; } }




    private void Awake()
    {
        _tiempo = 0;
    }
    private void Update()
    {
        if(_tiempo > 0)
        {
            _tiempo -= (float)Time.deltaTime;
            _minutos = (int)(_tiempo / 60f);
            _segundos = (int)(_tiempo - _minutos * 60f);
            if ( _tiempo <= 0)
            {
                _tiempo = 0;
            }
        }
       
    }
    
    private void OnEnable()
    {
       Piso.EstablecerNuevoTiempoTemporizador += CambiarVariableTiempo;
    }
    private void OnDisable()
    {
        Piso.EstablecerNuevoTiempoTemporizador -= CambiarVariableTiempo;
    }
    private void CambiarVariableTiempo(float v)
    {
        _tiempo = v;
    }



 
}
