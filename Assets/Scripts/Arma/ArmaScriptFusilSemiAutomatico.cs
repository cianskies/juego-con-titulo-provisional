using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScriptFusilSemiAutomatico : ArmaScriptPistola
{
    [SerializeField]protected float _cadenciaDisparo=0.1f;
    [SerializeField] protected float _cadenciaEntreDisparos = 0.3f;
    protected bool _sePuedeUsar=true;
    public override void UsarArma()
    {
        if(_sePuedeUsar)
        {
            _sePuedeUsar = false;
            StartCoroutine(DispararConCadencia());
            
        }
        
    }

    protected IEnumerator DispararConCadencia()
    {
        for (int i = 0; i < 3; i++)
        {
            base.UsarArma();
            yield return new WaitForSeconds(_cadenciaDisparo);
        }
        yield return new WaitForSeconds(_cadenciaEntreDisparos);
        _sePuedeUsar =true;
    }

}
