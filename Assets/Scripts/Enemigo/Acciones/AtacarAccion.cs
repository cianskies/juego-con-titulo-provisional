using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacarAccion : AccionFSM
{

    private ArmaEnemigo _armaEnemigo;
    private EnemigoFSM _enemigoFSM;
    private float _temporizadorUsoArma;
    private float _delay;

    private void Awake()
    {
        _armaEnemigo=GetComponent<ArmaEnemigo>();
        _enemigoFSM = GetComponent<EnemigoFSM>();
    }
    private void Start()
    {
        if (_armaEnemigo.Arma != null)
        {
            _temporizadorUsoArma = _armaEnemigo.Arma.Arma.Delay;
            _delay = _temporizadorUsoArma;
        }
    }
    public override void EjecutarAccionFSM()
    {
        if(_enemigoFSM.Jugador!=null)
        {
            _temporizadorUsoArma-=Time.deltaTime;
            if (_temporizadorUsoArma <= 0)
            {
                _armaEnemigo.UsarArma();
                _temporizadorUsoArma = _delay;
            }
            
        }
        
    }

   
}
